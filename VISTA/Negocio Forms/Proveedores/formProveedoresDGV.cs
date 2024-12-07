using Controladora;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VISTA.Negocio_Forms.Proveedores
{
    public partial class formProveedoresDGV : Form
    {

        #region Mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void formProveedoresDGV_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        public formProveedoresDGV()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ControladoraProveedor.Instancia.RecuperarProveedores();
        }

        private void ConfigurarBusqueda()
        {
            cmbBuscarPor.Items.Add("Nombre y Apellido");
            cmbBuscarPor.Items.Add("DNI");
            cmbBuscarPor.Items.Add("Razón Social");
            cmbBuscarPor.Items.Add("Email");
            cmbBuscarPor.SelectedIndex = 0;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            formProveedoresAM formProveedoresAM = new formProveedoresAM();
            formProveedoresAM.ShowDialog();
            ActualizarGrilla();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                var proveedorSeleccionado = (Proveedor)dataGridView1.CurrentRow.DataBoundItem;
                formProveedoresAM formProveedoresAM = new formProveedoresAM(proveedorSeleccionado);
                formProveedoresAM.ShowDialog();
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor para modificarlo.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                var proveedorSeleccionado = (Proveedor)dataGridView1.CurrentRow.DataBoundItem;
                var confirmacion = MessageBox.Show("¿Está seguro que desea eliminar el proveedor?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    var mensaje = ControladoraProveedor.Instancia.EliminarProveedor(proveedorSeleccionado);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarGrilla();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor para eliminarlo.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTextoBuscar.Text))
            {
                var listaProveedores = ControladoraProveedor.Instancia.RecuperarProveedores();
                var proveedoresEncontrados = listaProveedores.Where(p =>
                    p.NombreyApellido.ToLower().Contains(txtTextoBuscar.Text.ToLower()) ||
                    p.RazonSocial.ToLower().Contains(txtTextoBuscar.Text.ToLower()) ||
                    p.CUIT.Contains(txtTextoBuscar.Text)
                );

                if (proveedoresEncontrados.Any())
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = proveedoresEncontrados.ToList();
                }
                else
                {
                    ActualizarGrilla();
                }
            }
            else
            {
                ActualizarGrilla();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

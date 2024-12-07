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
using VISTA.Negocio_Forms.Proveedores;

namespace VISTA.Negocio_Forms
{
    public partial class formProductoDGV : Form
    {

        #region Mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void formProductoDGV_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        public formProductoDGV()
        {
            InitializeComponent();
            dgvProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            dgvProducto.DataSource = null;
            dgvProducto.DataSource = ControladoraProducto.Instancia.RecuperarProductos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            formProductoAM formProductoAM = new formProductoAM();
            formProductoAM.ShowDialog();
            ActualizarGrilla();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvProducto.Rows.Count > 0)
            {
                var productoSeleccionado = (Producto)dgvProducto.CurrentRow.DataBoundItem;
                formProductoAM formProductoAM = new formProductoAM(productoSeleccionado);
                formProductoAM.ShowDialog();
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("Seleccione un producto para modificarlo.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProducto.Rows.Count > 0)
            {
                var productoSeleccionado = (Producto)dgvProducto.CurrentRow.DataBoundItem;
                var confirmacion = MessageBox.Show("¿Está seguro que desea eliminar el producto?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    var mensaje = ControladoraProducto.Instancia.EliminarProducto(productoSeleccionado);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarGrilla();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto para eliminarlo.");
            }
        }

        private void txtTextoBuscar_Enter(object sender, EventArgs e)
        {
            if (txtTextoBuscar.Text == "Buscar por código o descripción...")
            {
                txtTextoBuscar.Text = "";
                txtTextoBuscar.ForeColor = Color.Black;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

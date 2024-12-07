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

namespace VISTA.Negocio_Forms
{
    public partial class formClienteDGV : Form
    {
        #region Mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")] //importo las librerias necesarias para mover la ventana
        private extern static void ReleaseCapture(); //metodo para mover la ventana
        [DllImport("User32.DLL", EntryPoint = "SendMessage")] //importo las librerias necesarias para mover la ventana
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void formClienteDGV_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        public formClienteDGV()
        {
            InitializeComponent();
            dgvCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            dgvCliente.DataSource = null;
            dgvCliente.DataSource = ControladoraCliente.Instancia.RecuperarClientes();
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
            formClienteAM formClienteAM = new formClienteAM();
            formClienteAM.ShowDialog();
            ActualizarGrilla();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvCliente.SelectedRows.Count > 0)
            {
                var clienteSeleccionado = (Cliente)dgvCliente.CurrentRow.DataBoundItem;
                formClienteAM formClienteAM = new formClienteAM(clienteSeleccionado);
                formClienteAM.ShowDialog();
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCliente.SelectedRows.Count > 0)
            {
                var clienteSeleccionado = (Cliente)dgvCliente.CurrentRow.DataBoundItem;
                var confirmacion = MessageBox.Show("¿Está seguro que desea eliminar el cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    var mensaje = ControladoraCliente.Instancia.EliminarCliente(clienteSeleccionado);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarGrilla();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTextoBuscar.Text))
            {
                var listaClientes = ControladoraCliente.Instancia.RecuperarClientes();
                var filtro = txtTextoBuscar.Text.ToLower();

                switch (cmbBuscarPor.SelectedItem.ToString())
                {
                    case "Nombre y Apellido":
                        dgvCliente.DataSource = listaClientes.Where(c => c.NombreyApellido.ToLower().Contains(filtro)).ToList();
                        break;
                    case "DNI":
                        dgvCliente.DataSource = listaClientes.Where(c => c.DNI.ToString().Contains(filtro)).ToList();
                        break;
                    case "Razón Social":
                        dgvCliente.DataSource = listaClientes.Where(c => c.RazonSocial.ToLower().Contains(filtro)).ToList();
                        break;
                    case "Email":
                        dgvCliente.DataSource = listaClientes.Where(c => c.Usuario.Email.ToLower().Contains(filtro)).ToList();
                        break;
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

        private void formClienteDGV_Load(object sender, EventArgs e)
        {

        }
    }
}

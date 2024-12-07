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
    public partial class formProveedoresAM : Form
    {
        private Proveedor proveedor;
        private bool modificar = false;

        public formProveedoresAM()
        {
            InitializeComponent();
            proveedor = new Proveedor();
        }

        #region Mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void formProveedoresAM_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        public formProveedoresAM(Proveedor proveedorModificar)
        {
            InitializeComponent();
            proveedor = proveedorModificar;
            modificar = true;
        }

        private void formProveedoresAM_Load(object sender, EventArgs e)
        {
            if (modificar)
            {
                lblAgregaroModificar.Text = "Modificar Proveedor";

                txtNombreApellido.Text = proveedor.NombreyApellido;
                txtDNI.Text = proveedor.DNI.ToString();
                txtEmail.Text = proveedor.Email;
                txtTelefono.Text = proveedor.Telefono;
                txtDireccion.Text = proveedor.Domicilio;
                txtRazonSocial.Text = proveedor.RazonSocial;
                txtCUIT.Text = proveedor.CUIT;
                dtpFechaNacimiento.Value = proveedor.FechaNacimiento;
            }
            else
            {
                lblAgregaroModificar.Text = "Agregar Proveedor";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (modificar)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro de que desea modificar el proveedor?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        proveedor.NombreyApellido = txtNombreApellido.Text;
                        proveedor.DNI = long.Parse(txtDNI.Text);
                        proveedor.Email = txtEmail.Text;
                        proveedor.Telefono = txtTelefono.Text;
                        proveedor.Domicilio = txtDireccion.Text;
                        proveedor.RazonSocial = txtRazonSocial.Text;
                        proveedor.CUIT = txtCUIT.Text;
                        proveedor.FechaNacimiento = dtpFechaNacimiento.Value;

                        var mensaje = ControladoraProveedor.Instancia.ModificarProveedor(proveedor);
                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    proveedor.NombreyApellido = txtNombreApellido.Text;
                    proveedor.DNI = long.Parse(txtDNI.Text);
                    proveedor.Email = txtEmail.Text;
                    proveedor.Telefono = txtTelefono.Text;
                    proveedor.Domicilio = txtDireccion.Text;
                    proveedor.RazonSocial = txtRazonSocial.Text;
                    proveedor.CUIT = txtCUIT.Text;
                    proveedor.FechaNacimiento = dtpFechaNacimiento.Value;

                    var mensaje = ControladoraProveedor.Instancia.AgregarProveedor(proveedor);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtNombreApellido.Text))
            {
                MessageBox.Show("El campo Nombre y Apellido no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtDNI.Text))
            {
                MessageBox.Show("El campo DNI no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("El campo Email no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                MessageBox.Show("El campo Teléfono no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("El campo Dirección no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtRazonSocial.Text))
            {
                MessageBox.Show("El campo Razón Social no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtCUIT.Text))
            {
                MessageBox.Show("El campo CUIT no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dtpFechaNacimiento.Value > DateTime.Now)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser mayor a la fecha actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea cancelar la carga de datos?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}

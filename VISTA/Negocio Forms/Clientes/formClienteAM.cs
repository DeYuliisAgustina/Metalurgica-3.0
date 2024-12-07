using Entidades;
using Controladora;
using System.Runtime.InteropServices;

namespace VISTA.Negocio_Forms
{
    public partial class formClienteAM : Form
    {
        private Cliente cliente;
        private bool modificar = false;

        public formClienteAM()
        {
            InitializeComponent();
            cliente = new Cliente();
        }

        #region Mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")] //importo las librerias necesarias para mover la ventana
        private extern static void ReleaseCapture(); //metodo para mover la ventana
        [DllImport("User32.DLL", EntryPoint = "SendMessage")] //importo las librerias necesarias para mover la ventana
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void formClienteAM_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        public formClienteAM(Cliente clienteModificar)
        {
            InitializeComponent();
            cliente = clienteModificar;
            modificar = true;
        }

        private void formClienteAM_Load(object sender, EventArgs e)
        {
            if (modificar)
            {
                lblAgregaroModificar.Text = "Modificar Cliente";

                txtRazonSocial.Text = cliente.RazonSocial;
                txtNombreApellido.Text = cliente.NombreyApellido;
                txtDNI.Text = cliente.DNI.ToString();
                txtEmail.Text = cliente.Email;
                txtTelefono.Text = cliente.Telefono;
                txtDireccion.Text = cliente.Domicilio;
                dtpFechaNacimiento.Value = cliente.FechaNacimiento;
            }
            else
            {
                lblAgregaroModificar.Text = "Agregar Cliente";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea cancelar la carga de datos?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (modificar)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro de que desea modificar el cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        cliente.RazonSocial = txtRazonSocial.Text;
                        cliente.NombreyApellido = txtNombreApellido.Text;
                        cliente.DNI = long.Parse(txtDNI.Text);
                        cliente.Email = txtEmail.Text;
                        cliente.Telefono = txtTelefono.Text;
                        cliente.Domicilio = txtDireccion.Text;
                        cliente.FechaNacimiento = dtpFechaNacimiento.Value;

                        var mensaje = ControladoraCliente.Instancia.ModificarCliente(cliente);
                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    cliente.RazonSocial = txtRazonSocial.Text;
                    cliente.NombreyApellido = txtNombreApellido.Text;
                    cliente.DNI = long.Parse(txtDNI.Text);
                    cliente.Email = txtEmail.Text;
                    cliente.Telefono = txtTelefono.Text;
                    cliente.Domicilio = txtDireccion.Text;
                    cliente.FechaNacimiento = dtpFechaNacimiento.Value;

                    var mensaje = ControladoraCliente.Instancia.AgregarCliente(cliente);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }

        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtRazonSocial.Text))
            {
                MessageBox.Show("El campo Razón Social no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtNombreApellido.Text))
            {
                MessageBox.Show("El campo Nombre y Apellido no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtDNI.Text) || !long.TryParse(txtDNI.Text, out _))
            {
                MessageBox.Show("El campo DNI debe contener un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (dtpFechaNacimiento.Value > DateTime.Now)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser mayor a la fecha actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

    }
}

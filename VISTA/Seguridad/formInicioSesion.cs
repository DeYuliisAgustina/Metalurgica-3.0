using Controladora;
using Entidades.Seguridad;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using VISTA.UI_Admin;

namespace VISTA
{
    public partial class formInicioSesion : Form
    {
        public static Usuario UsuarioActual { get; private set; }

        public formInicioSesion()
        {
            InitializeComponent();
        }
        
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtNombreUsuario.Text) || string.IsNullOrEmpty(txtClave.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                // Verificar si es un administrador
                var administradores = ControladoraSeguridad.Instancia.RecuperarAdministradores();
                var esAdmin = administradores.Any(a =>
                    a.Usuario != null &&
                    a.Usuario.NombreUsuario == txtNombreUsuario.Text &&
                    a.Usuario.Clave == txtClave.Text);

                if (esAdmin)
                {
                    UsuarioActual = new Usuario { NombreUsuario = txtNombreUsuario.Text };
                    MessageBox.Show($"¡Bienvenido Administrador!", "Inicio de Sesión Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formMenuPrincipal formMenuPrincipal = new formMenuPrincipal();
                    formMenuPrincipal.Show();
                    this.Hide();
                    return;
                }
                // Si no es admin, verificar si es un usuario normal
                Usuario usuario = new Usuario
                {
                    NombreUsuario = txtNombreUsuario.Text,
                    Clave = txtClave.Text
                };
                string resultado = ControladoraSeguridad.Instancia.IniciarSesion(usuario);
                if (resultado == "Inicio de sesión exitoso")
                {
                    UsuarioActual = usuario;
                    MessageBox.Show($"¡Bienvenido {usuario.NombreUsuario}!", "Inicio de Sesión Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formMenuPrincipal formMenuPrincipal = new formMenuPrincipal();
                    formMenuPrincipal.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar sesión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblOlvidarContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formRecuperarClave formRecuperarClave = new formRecuperarClave();
            formRecuperarClave.ShowDialog();
        }
        
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

    }
}

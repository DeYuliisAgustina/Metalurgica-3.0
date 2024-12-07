using Controladora;
using Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VISTA.UI_Admin;

namespace VISTA
{
    public partial class formGestionarUsuarios : Form
    {

        public formGestionarUsuarios()
        {
            InitializeComponent();
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            formUsuario formUsuario = new formUsuario();
            formUsuario.ShowDialog();
        }

        private void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            
        }

        private void btnResetearUsuario_Click(object sender, EventArgs e)
        {
            if (dgvGestionarUsuarios.CurrentRow != null)
            {
                var usuarioSeleccionado = (Usuario)dgvGestionarUsuarios.CurrentRow.DataBoundItem;
                var resultado = ControladoraSeguridad.Instancia.RecuperarClave(usuarioSeleccionado);
                MessageBox.Show(resultado);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un usuario para resetear su clave");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}

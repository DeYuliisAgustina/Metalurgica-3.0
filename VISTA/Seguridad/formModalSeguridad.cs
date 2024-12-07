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

namespace VISTA.Seguridad
{
    public partial class formModalSeguridad : Form
    {
        public formModalSeguridad()
        {
            InitializeComponent();
        }

        private void btnSeguridad_Click(object sender, EventArgs e)
        {
            formGestionarGrupos formGestionarGrupos = new formGestionarGrupos();
            formGestionarGrupos.ShowDialog();
        }

        private void btnGestionarUsuarios_Click(object sender, EventArgs e)
        {
            formGestionarUsuarios formGestionarUsuarios = new formGestionarUsuarios();
            formGestionarUsuarios.ShowDialog();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

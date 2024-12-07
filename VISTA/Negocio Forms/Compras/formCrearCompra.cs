using Controladora;
using Entidades;
using Entidades.EstadoNotaCompra_State;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VISTA.Negocio_Forms.Compras
{
    public partial class formCrearCompra : Form
    {

        public formCrearCompra()
        {
            InitializeComponent();
        }

        private void formCrearCompra_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            var formDetalle = new formDetalleNotaCompra();
            formDetalle.ShowDialog();
        }

        private void btnModificarDetalle_Click(object sender, EventArgs e)
        {
            formDetalleNotaCompra formDetalleNotaCompra = new formDetalleNotaCompra();
            formDetalleNotaCompra.ShowDialog();
        }

        private void btnCancelarCompra_Click(object sender, EventArgs e)
        {
            //preguntar si esta seguro de cancelar la compra y si esta seguro se cancelar la compra
            DialogResult dialogResult = MessageBox.Show("¿Está seguro de cancelar la compra?", "Cancelar Compra", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void btnCrearCompra_Click(object sender, EventArgs e)
        {
          
        }


    }
}

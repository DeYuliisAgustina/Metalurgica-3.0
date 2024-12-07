using Entidades;
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
    public partial class formDetalleNotaCompra : Form
    {
        private DetalleNotaCompra DetalleNotaCompra;
        private bool modificar = false;

        public formDetalleNotaCompra()
        {
            InitializeComponent();
            DetalleNotaCompra = new DetalleNotaCompra();

        }

        public formDetalleNotaCompra(DetalleNotaCompra DetalleNotaCompraModificar)
        {
            InitializeComponent();
            DetalleNotaCompra = DetalleNotaCompraModificar;
            modificar = true;
        }

        private void formDetalleNotaCompra_Load(object sender, EventArgs e)
        {
            if (modificar)
            {
                lblAgregaroModificar.Text = "Modificar Detalle";
                txtPrecioUnitario.Text = DetalleNotaCompra.PrecioUnitario.ToString();
                numCantidad.Text = DetalleNotaCompra.Cantidad.ToString();
                txtPrecioUnitario.Text = DetalleNotaCompra.PrecioUnitario.ToString();
            }
            else
            {
                lblAgregaroModificar.Text = "Agregar Detalle";
            }


        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            formProductoDGV formProductoDGV = new formProductoDGV();
            formProductoDGV.ShowDialog();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

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

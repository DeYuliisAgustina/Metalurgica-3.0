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
    public partial class formProductoAM : Form
    {
        private Producto producto;
        private bool modificar = false;

        public formProductoAM()
        {
            InitializeComponent();
            producto = new Producto();

        }

        #region mover la ventana
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

        public formProductoAM(Producto productoModificar)
        {
            InitializeComponent();
            producto = productoModificar;
            modificar = true;
        }

        private void formProductoAM_Load(object sender, EventArgs e)
        {
            if (modificar)
            {
                lblAgregaroModificar.Text = "Modificar Producto";
                txtCodigoProducto.Text = producto.Codigo;
                txtNombreProducto.Text = producto.Descripcion;
                txtCategoriaProducto.Text = producto.Categoria;
                txtDescripcionProducto.Text = producto.Descripcion;
                txtPrecio.Text = producto.Precio.ToString();

            }
            else
            {
                lblAgregaroModificar.Text = "Agregar Producto";
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
                    DialogResult result = MessageBox.Show("¿Está seguro que desea modificar el producto?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        producto.Codigo = txtCodigoProducto.Text;
                        producto.Descripcion = txtDescripcionProducto.Text;
                        producto.Categoria = txtCategoriaProducto.Text;
                        producto.Nombre = txtNombreProducto.Text;
                        producto.Precio = decimal.Parse(txtPrecio.Text);

                        var mensaje = ControladoraProducto.Instancia.ModificarProducto(producto);
                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    producto.Codigo = txtCodigoProducto.Text;
                    producto.Descripcion = txtDescripcionProducto.Text;
                    producto.Categoria = txtCategoriaProducto.Text;
                    producto.Nombre = txtNombreProducto.Text;
                    producto.Precio = decimal.Parse(txtPrecio.Text);


                    var mensaje = ControladoraProducto.Instancia.AgregarProducto(producto);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }

        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtCodigoProducto.Text))
            {
                MessageBox.Show("El código del producto no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtDescripcionProducto.Text))
            {
                MessageBox.Show("La descripción del producto no puede estar vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtCategoriaProducto.Text))
            {
                MessageBox.Show("La categoría del producto no puede estar vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}

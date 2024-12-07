using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VISTA.Negocio_Forms;
using VISTA.Negocio_Forms.Compras;
using VISTA.Negocio_Forms.Proveedores;
using VISTA.Negocio_Forms.Ventas;
using VISTA.Seguridad;

namespace VISTA
{
    public partial class formMenuPrincipal : Form
    {
        public formMenuPrincipal()
        {
            InitializeComponent();
            ConfigurarVisibilidadBtnSeguridad();
        }

        private void ConfigurarVisibilidadBtnSeguridad()
        {
            // Verificar si hay un usuario actual
            if (formInicioSesion.UsuarioActual != null)
            {
                // El botón solo será visible si el usuario es "Admin"
                if (formInicioSesion.UsuarioActual.NombreUsuario == "Admin")
                {
                    btnSeguridad.Visible = true;
                    lblAdminoUsuario.Text = "Administrador";
                }
                else
                {
                    btnSeguridad.Visible = false;
                    lblAdminoUsuario.Text = "Usuario";
                }
            }
            else
            {
                btnSeguridad.Visible = false; // Si no hay usuario, ocultar el botón
                lblAdminoUsuario.Text = ""; // Dejar el label vacío si no hay usuario
            }
        }
            #region Control SubMenus
            bool menuAbiertoCompras = false;
        bool menuAbiertoVentas = false;
        bool menuAbiertoProductos = false;
        bool menuAbiertoMiPerfil = false;

        private void menuTransition_Tick(object sender, EventArgs e)
        {
            // Cerrar todos los menús excepto el actual
            if (menuActual == "Productos")
            {
                // Cerrar Compras si está abierto
                if (menuAbiertoCompras)
                {
                    menuContainerCompras.Height -= 10;
                    if (menuContainerCompras.Height <= 61)
                    {
                        menuAbiertoCompras = false;
                    }
                }
                // Cerrar Ventas si está abierto
                if (menuAbiertoVentas)
                {
                    menuContainerVentas.Height -= 10;
                    if (menuContainerVentas.Height <= 61)
                    {
                        menuAbiertoVentas = false;
                    }
                }
                // Manejar el menú de Productos
                if (!menuAbiertoProductos)
                {
                    menuContainerProductos.Height += 10;
                    if (menuContainerProductos.Height >= 185)
                    {
                        menuTransition.Stop();
                        menuAbiertoProductos = true;
                    }
                }
                else
                {
                    menuContainerProductos.Height -= 10;
                    if (menuContainerProductos.Height <= 61)
                    {
                        menuTransition.Stop();
                        menuAbiertoProductos = false;
                    }
                }
            }
            else if (menuActual == "Compras")
            {
                // Cerrar Productos si está abierto
                if (menuAbiertoProductos)
                {
                    menuContainerProductos.Height -= 10;
                    if (menuContainerProductos.Height <= 61)
                    {
                        menuAbiertoProductos = false;
                    }
                }
                // Cerrar Ventas si está abierto
                if (menuAbiertoVentas)
                {
                    menuContainerVentas.Height -= 10;
                    if (menuContainerVentas.Height <= 61)
                    {
                        menuAbiertoVentas = false;
                    }
                }
                // Manejar el menú de Compras
                if (!menuAbiertoCompras)
                {
                    menuContainerCompras.Height += 10;
                    if (menuContainerCompras.Height >= 183)
                    {
                        menuTransition.Stop();
                        menuAbiertoCompras = true;
                    }
                }
                else
                {
                    menuContainerCompras.Height -= 10;
                    if (menuContainerCompras.Height <= 61)
                    {
                        menuTransition.Stop();
                        menuAbiertoCompras = false;
                    }
                }
            }
            else if (menuActual == "Ventas")
            {
                // Cerrar Productos si está abierto
                if (menuAbiertoProductos)
                {
                    menuContainerProductos.Height -= 10;
                    if (menuContainerProductos.Height <= 61)
                    {
                        menuAbiertoProductos = false;
                    }
                }
                // Cerrar Compras si está abierto
                if (menuAbiertoCompras)
                {
                    menuContainerCompras.Height -= 10;
                    if (menuContainerCompras.Height <= 61)
                    {
                        menuAbiertoCompras = false;
                    }
                }
                // Manejar el menú de Ventas
                if (!menuAbiertoVentas)
                {
                    menuContainerVentas.Height += 10;
                    if (menuContainerVentas.Height >= 183)
                    {
                        menuTransition.Stop();
                        menuAbiertoVentas = true;
                    }
                }
                else
                {
                    menuContainerVentas.Height -= 10;
                    if (menuContainerVentas.Height <= 61)
                    {
                        menuTransition.Stop();
                        menuAbiertoVentas = false;
                    }
                }
            }
            else if (menuActual == "MiPerfil")
            {
                // Cerrar Productos si está abierto
                if (menuAbiertoProductos)
                {
                    menuContainerProductos.Height -= 10;
                    if (menuContainerProductos.Height <= 61)
                    {
                        menuAbiertoProductos = false;
                    }
                }
                // Cerrar Compras si está abierto
                if (menuAbiertoCompras)
                {
                    menuContainerCompras.Height -= 10;
                    if (menuContainerCompras.Height <= 61)
                    {
                        menuAbiertoCompras = false;
                    }
                }
                // Cerrar Ventas si está abierto
                if (menuAbiertoVentas)
                {
                    menuContainerVentas.Height -= 10;
                    if (menuContainerVentas.Height <= 36)
                    {
                        menuAbiertoVentas = false;
                    }
                }
                // Manejar el menú de MiPerfil
                if (!menuAbiertoMiPerfil)
                {
                    menuMiPerfilContainer.Height += 10;
                    if (menuMiPerfilContainer.Height >= 110)
                    {
                        menuTransition.Stop();
                        menuAbiertoMiPerfil = true;
                    }
                }
                else
                {
                    menuMiPerfilContainer.Height -= 10;
                    if (menuMiPerfilContainer.Height <= 36)
                    {
                        menuTransition.Stop();
                        menuAbiertoMiPerfil = false;
                    }

                }
            }
        }

        string menuActual = "";
        #endregion

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            menuActual = "Productos";
            menuTransition.Start();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            menuActual = "Compras";
            menuTransition.Start();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            menuActual = "Ventas";
            menuTransition.Start();
        }

        private void btnMiPerfil_Click(object sender, EventArgs e)
        {
            menuActual = "MiPerfil";
            menuTransition.Start();

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            //abrir formulario de clientesDGV
            formClienteDGV formClientesDGV = new formClienteDGV();
            formClientesDGV.ShowDialog();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            formProveedoresDGV formProveedoresDGV = new formProveedoresDGV();
            formProveedoresDGV.ShowDialog();

        }

        private void btnCrearProductos_Click(object sender, EventArgs e)
        {
            //abrir formulario de formProductosAM
            formProductoAM formProductosAM = new formProductoAM();
            formProductosAM.ShowDialog();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            formProductoDGV formProductosDGV = new formProductoDGV();
            formProductosDGV.ShowDialog();

        }

        private void formMenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnMisDatos_Click(object sender, EventArgs e)
        {

        }

        private void btnCambiarClave_Click(object sender, EventArgs e)
        {
            formCambiarClave formCambiarClave = new formCambiarClave();
            formCambiarClave.ShowDialog();

        }

        private void btnHistorialCompras_Click(object sender, EventArgs e)
        {
            formNotasCompra formNotasCompra = new formNotasCompra();
            formNotasCompra.ShowDialog();
        }

        private void btnCrearNotaCompra_Click(object sender, EventArgs e)
        {
            formCrearCompra formCrearCompra = new formCrearCompra();
            formCrearCompra.ShowDialog();
        }

        private void btnHistorialVentas_Click(object sender, EventArgs e)
        {
            formNotasVenta formNotasVenta = new formNotasVenta();
            formNotasVenta.ShowDialog();

        }

        private void btnCrearNotaVenta_Click(object sender, EventArgs e)
        {
            formCrearVenta formCrearVenta = new formCrearVenta();
            formCrearVenta.ShowDialog();
        }

        private void btnSeguridad_Click(object sender, EventArgs e)
        {
            formModalSeguridad formModalSeguridad = new formModalSeguridad();
            formModalSeguridad.ShowDialog();
        }
    }
}

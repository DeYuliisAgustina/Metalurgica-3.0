using Entidades;
using Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class ControladoraProducto
    {
        Context context;

        private ControladoraProducto()
        {
            context = new Context();
        }

        private static ControladoraProducto instancia;

        public static ControladoraProducto Instancia
        {

            get
            {
                if (instancia == null)
                    instancia = new ControladoraProducto();
                return instancia;
            }
        }

        public ReadOnlyCollection<Producto> RecuperarProductos()
        {
            Context.Instancia.Productos.ToList().AsReadOnly();
            return Context.Instancia.Productos.ToList().AsReadOnly();
        }

        public string AgregarProducto(Producto producto)
        {
            try
            {
                var listaProductos = Context.Instancia.Productos.ToList().AsReadOnly();
                var productosEncontrado = listaProductos.FirstOrDefault(producto => producto.ProductoId == producto.ProductoId);
                if (productosEncontrado == null)
                {
                    Context.Instancia.Productos.Add(producto);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"El producto se agregó correctamente";
                    }
                    else return $"El producto  no se ha podido agregar";
                }
                else
                {
                    return $"El producto  ya existe";
                }

            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string ModificarProducto(Producto producto)
        {
            try
            {
                var listaProductos = Context.Instancia.Productos.ToList().AsReadOnly();
                var productosEncontrado = listaProductos.FirstOrDefault(producto => producto.ProductoId == producto.ProductoId || producto.Codigo.ToLower() == producto.Codigo.ToLower());
                if (productosEncontrado != null)
                {
                    Context.Instancia.Productos.Update(producto);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"El producto se modificó correctamente";
                    }
                    else return $"El producto no se ha podido modificar";
                }
                else
                {
                    return $"El producto no existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string EliminarProducto(Producto producto)
        {
            try
            {
                var listaProductos = Context.Instancia.Productos.ToList().AsReadOnly();
                var productosEncontrado = listaProductos.FirstOrDefault(producto => producto.ProductoId == producto.ProductoId || producto.Codigo.ToLower() == producto.Codigo.ToLower());
                if (productosEncontrado != null)
                {
                    Context.Instancia.Productos.Remove(producto);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"El producto se eliminó correctamente";
                    }
                    else return $"El producto no se ha podido eliminar";
                }
                else
                {
                    return $"El producto no existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

       
    }
}

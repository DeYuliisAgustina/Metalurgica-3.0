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
    public class ControladoraProveedor
    {
        Context context;

        private ControladoraProveedor()
        {
            context = new Context();
        }

        private static ControladoraProveedor instancia;

        public static ControladoraProveedor Instancia
        {

            get
            {
                if (instancia == null)
                    instancia = new ControladoraProveedor();
                return instancia;
            }
        }

        public ReadOnlyCollection<Proveedor> RecuperarProveedores()
        {
            Context.Instancia.Proveedores.ToList().AsReadOnly();
            return Context.Instancia.Proveedores.ToList().AsReadOnly();
        }

        public string AgregarProveedor(Proveedor proveedor)
        {
            try
            {
                var listaProveedores = Context.Instancia.Proveedores.ToList().AsReadOnly();
                var proveedorEncontrado = listaProveedores.FirstOrDefault(s => s.NombreyApellido.ToLower() == proveedor.NombreyApellido.ToLower());
                if (proveedorEncontrado == null)
                {
                    Context.Instancia.Proveedores.Add(proveedor);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"El proveedor se agregó correctamente";
                    }
                    else return $"El proveedor  no se ha podido agregar";
                }
                else
                {
                    return $"El proveedor  ya existe";
                }

            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string ModificarProveedor(Proveedor proveedor)
        {
            try
            {
                var listaProveedores = Context.Instancia.Proveedores.ToList().AsReadOnly();
                var proveedorEncontrado = listaProveedores.FirstOrDefault(c => c.ProveedorId == proveedor.ProveedorId || c.NombreyApellido.ToLower() == proveedor.NombreyApellido.ToLower());
                if (proveedorEncontrado != null)
                {
                    Context.Instancia.Proveedores.Update(proveedor);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"El proveedor se modificó correctamente";
                    }
                    else return $"El proveedor no se ha podido modificar";
                }
                else
                {
                    return $"El proveedor no existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string EliminarProveedor(Proveedor proveedor) 
        { 
            try
            {
                var listaProveedores = Context.Instancia.Proveedores.ToList().AsReadOnly();
                var proveedorEncontrado = listaProveedores.FirstOrDefault(c => c.ProveedorId == proveedor.ProveedorId);
                if (proveedorEncontrado != null)
                {
                    Context.Instancia.Proveedores.Remove(proveedor);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"El proveedor se eliminó correctamente";
                    }
                    else return $"El proveedor no se ha podido eliminar";
                }
                else
                {
                    return $"El proveedor no existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }


    }
}

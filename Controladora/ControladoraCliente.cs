using Modelo;
using Entidades;
using System.Collections.ObjectModel;

namespace Controladora
{
    public class ControladoraCliente
    {
        Context context;

        private ControladoraCliente()
        {
            context = new Context();
        }

        private static ControladoraCliente instancia;

        public static ControladoraCliente Instancia
        {

            get
            {
                if (instancia == null)
                    instancia = new ControladoraCliente();
                return instancia;
            }
        }

        public ReadOnlyCollection<Cliente> RecuperarClientes()
        {
            Context.Instancia.Clientes.ToList().AsReadOnly();
            return Context.Instancia.Clientes.ToList().AsReadOnly();
        }

        public string AgregarCliente(Cliente cliente)
        {
            try
            {
                var listaClientes = Context.Instancia.Clientes.ToList().AsReadOnly();
                var clienteEncontrado = listaClientes.FirstOrDefault(s => s.NombreyApellido.ToLower() == cliente.NombreyApellido.ToLower());
                if (clienteEncontrado == null)
                {
                    Context.Instancia.Clientes.Add(cliente);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"El cliente se agregó correctamente";
                    }
                    else return $"El cliente no se ha podido agregar";
                }
                else
                {
                    return $"El cliente ya existe";
                }

            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string ModificarCliente(Cliente cliente)
        {
            try
            {
                var listaClientes = Context.Instancia.Clientes.ToList().AsReadOnly();
                var clienteEncontrado = listaClientes.FirstOrDefault(c => c.ClienteId == cliente.ClienteId || c.NombreyApellido.ToLower() == cliente.NombreyApellido.ToLower());
                if (clienteEncontrado != null)
                {
                    Context.Instancia.Clientes.Update(cliente);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"El cliente se modificó correctamente";
                    }
                    else return $"El cliente no se ha podido modificar";
                }
                else
                {
                    return $"El cliente no existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string EliminarCliente(Cliente cliente)
        {
            try
            {
                var listaClientes = Context.Instancia.Clientes.ToList().AsReadOnly();
                var clienteEncontrado = listaClientes.FirstOrDefault(c => c.ClienteId == cliente.ClienteId);
                if (clienteEncontrado != null)
                {
                    Context.Instancia.Clientes.Remove(cliente);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"El cliente se eliminó correctamente";
                    }
                    else return $"El cliente no se ha podido eliminar";
                }
                else
                {
                    return $"El cliente no existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }
    }
}

using Modelo;
using Entidades;
using System.Collections.ObjectModel;
using Entidades.EstadoNotaCompra_State;
using System.Linq;

namespace Controladora
{
    public class ControladoraNotaCompra
    {
        Context context;

        private ControladoraNotaCompra()
        {
            context = new Context();
        }

        private static ControladoraNotaCompra instancia;

        public static ControladoraNotaCompra Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new ControladoraNotaCompra();
                return instancia;
            }
        }

        // Método para crear una nueva nota de compra
        public string CrearNotaCompra(NotaCompra notaCompra)
        {
            try
            {
                // Validaciones básicas
                if (notaCompra.Proveedor == null)
                    return "Debe seleccionar un proveedor";

                if (notaCompra.DetalleNotaCompra == null || !notaCompra.DetalleNotaCompra.Any())
                    return "Debe agregar al menos un detalle a la nota de compra";

                // Inicializar el estado como Pendiente usando el patrón State
                notaCompra.CambiarEstado(new EstadoPendiente());

                // Agregar la nota de compra
                Context.Instancia.NotaCompras.Add(notaCompra);
                int resultado = Context.Instancia.SaveChanges();

                return resultado > 0
                    ? "Nota de compra creada exitosamente"
                    : "Error al crear la nota de compra";
            }
            catch (Exception ex)
            {
                return $"Error al crear la nota de compra: {ex.Message}";
            }
        }

        // Método para modificar una nota de compra existente
        public string ModificarNotaCompra(NotaCompra notaCompra)
        {
            try
            {
                var notaExistente = Context.Instancia.NotaCompras
                    .FirstOrDefault(n => n.NotaCompraId == notaCompra.NotaCompraId);

                if (notaExistente == null)
                    return "La nota de compra no existe";

                // Solo permitir modificaciones en estado Pendiente
                if (notaExistente.ObtenerEstado() != "Pendiente")
                    return "Solo se pueden modificar notas de compra en estado Pendiente";

                Context.Instancia.NotaCompras.Update(notaCompra);
                int resultado = Context.Instancia.SaveChanges();

                return resultado > 0
                    ? "Nota de compra modificada exitosamente"
                    : "Error al modificar la nota de compra";
            }
            catch (Exception ex)
            {
                return $"Error al modificar la nota de compra: {ex.Message}";
            }
        }

        // Método para eliminar una nota de compra
        public string EliminarNotaCompra(NotaCompra notaCompra)
        {
            try
            {
                var notaExistente = Context.Instancia.NotaCompras
                    .FirstOrDefault(n => n.NotaCompraId == notaCompra.NotaCompraId);

                if (notaExistente == null)
                    return "La nota de compra no existe";

                // Solo permitir eliminación en estado Pendiente
                if (notaExistente.ObtenerEstado() != "Pendiente")
                    return "Solo se pueden eliminar notas de compra en estado Pendiente";

                Context.Instancia.NotaCompras.Remove(notaCompra);
                int resultado = Context.Instancia.SaveChanges();

                return resultado > 0
                    ? "Nota de compra eliminada exitosamente"
                    : "Error al eliminar la nota de compra";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar la nota de compra: {ex.Message}";
            }
        }

        // Métodos para cambios de estado utilizando el patrón State
        public string ProcesarNotaCompra(NotaCompra notaCompra)
        {
            try
            {
                notaCompra.Procesar();
                Context.Instancia.SaveChanges();
                return "Nota de compra procesada exitosamente";
            }
            catch (Exception ex)
            {
                return $"Error al procesar la nota de compra: {ex.Message}";
            }
        }

        public string PagarNotaCompra(NotaCompra notaCompra)
        {
            try
            {
                notaCompra.Pagar();
                Context.Instancia.SaveChanges();
                return "Nota de compra pagada exitosamente";
            }
            catch (Exception ex)
            {
                return $"Error al pagar la nota de compra: {ex.Message}";
            }
        }

        public string AnularNotaCompra(NotaCompra notaCompra)
        {
            try
            {
                notaCompra.Anular();
                Context.Instancia.SaveChanges();
                return "Nota de compra anulada exitosamente";
            }
            catch (Exception ex)
            {
                return $"Error al anular la nota de compra: {ex.Message}";
            }
        }

        public string FinalizarNotaCompra(NotaCompra notaCompra)
        {
            try
            {
                notaCompra.Finalizar();
                Context.Instancia.SaveChanges();
                return "Nota de compra finalizada exitosamente";
            }
            catch (Exception ex)
            {
                return $"Error al finalizar la nota de compra: {ex.Message}";
            }
        }

        // Métodos de recuperación de datos
        public ReadOnlyCollection<NotaCompra> RecuperarNotaCompras()
        {
            return Context.Instancia.NotaCompras.ToList().AsReadOnly();
        }

        public ReadOnlyCollection<Proveedor> RecuperarProveedores()
        {
            return Context.Instancia.Proveedores.ToList().AsReadOnly();
        }
    }
}
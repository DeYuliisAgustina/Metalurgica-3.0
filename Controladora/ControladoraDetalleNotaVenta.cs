using Entidades;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class ControladoraDetalleNotaVenta
    {
        public string AgregarDetalle(NotaCompra notaCompra, DetalleNotaCompra detalle)
        {
            try
            {
                // Validaciones
                if (detalle.Cantidad <= 0)
                    return "La cantidad debe ser mayor a 0";

                if (detalle.PrecioUnitario <= 0)
                    return "El precio unitario debe ser mayor a 0";

                if (detalle.Producto == null)
                    return "Debe seleccionar un producto";

                // Calcular subtotal
                detalle.Subtotal = detalle.PrecioUnitario * detalle.Cantidad;

                // Solo permitir agregar detalles si la nota está en estado Pendiente o EnProceso
                string estadoActual = notaCompra.ObtenerEstado();
                if (estadoActual != "Pendiente" && estadoActual != "EnProceso")
                    return "Solo se pueden agregar detalles a notas en estado Pendiente o En Proceso";

                notaCompra.DetalleNotaCompra.Add(detalle);
                int resultado = Context.Instancia.SaveChanges();

                return resultado > 0
                    ? "Detalle agregado exitosamente"
                    : "Error al agregar el detalle";
            }
            catch (Exception ex)
            {
                return $"Error al agregar el detalle: {ex.Message}";
            }
        }

        // Método para modificar un detalle existente
        public string ModificarDetalle(NotaCompra notaCompra, DetalleNotaCompra detalle)
        {
            try
            {
                // Validaciones similares a las de agregar
                if (detalle.Cantidad <= 0)
                    return "La cantidad debe ser mayor a 0";

                if (detalle.PrecioUnitario <= 0)
                    return "El precio unitario debe ser mayor a 0";

                // Verificar estado de la nota
                string estadoActual = notaCompra.ObtenerEstado();
                if (estadoActual != "Pendiente" && estadoActual != "EnProceso")
                    return "Solo se pueden modificar detalles de notas en estado Pendiente o En Proceso";

                // Recalcular subtotal
                detalle.Subtotal = detalle.PrecioUnitario * detalle.Cantidad;

                Context.Instancia.Update(detalle);
                int resultado = Context.Instancia.SaveChanges();

                return resultado > 0
                    ? "Detalle modificado exitosamente"
                    : "Error al modificar el detalle";
            }
            catch (Exception ex)
            {
                return $"Error al modificar el detalle: {ex.Message}";
            }
        }

        // Método para eliminar un detalle
        public string EliminarDetalle(NotaCompra notaCompra, DetalleNotaCompra detalle)
        {
            try
            {
                // Verificar estado de la nota
                string estadoActual = notaCompra.ObtenerEstado();
                if (estadoActual != "Pendiente" && estadoActual != "EnProceso")
                    return "Solo se pueden eliminar detalles de notas en estado Pendiente o En Proceso";

                Context.Instancia.Remove(detalle);
                int resultado = Context.Instancia.SaveChanges();

                return resultado > 0
                    ? "Detalle eliminado exitosamente"
                    : "Error al eliminar el detalle";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar el detalle: {ex.Message}";
            }
        }

        // Método para calcular el total de una nota de compra
        public decimal CalcularTotal(NotaCompra notaCompra)
        {
            return notaCompra.DetalleNotaCompra.Sum(d => d.Subtotal);
        }

    }
}

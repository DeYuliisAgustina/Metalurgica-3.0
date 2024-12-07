using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.EstadoNotaCompra_State
{
    public class EstadoPendiente : IEstadoNotaCompra
    {
        public void Procesar(NotaCompra notaCompra)
        {
            notaCompra.CambiarEstado(new EstadoEnProceso());
            Console.WriteLine($"Nota de compra #{notaCompra.NroNotaCompra} en proceso");
        }

        public void Pagar(NotaCompra notaCompra)
        {
            Console.WriteLine("Error: La nota debe estar en proceso para ser pagada");
        }

        public void Anular(NotaCompra notaCompra)
        {
            notaCompra.CambiarEstado(new EstadoAnulada());
            Console.WriteLine($"Nota de compra #{notaCompra.NroNotaCompra} anulada");
        }

        public void Finalizar(NotaCompra notaCompra)
        {
            Console.WriteLine("Error: La nota debe estar pagada para finalizar");
        }

        public string ObtenerNombreEstado()
        {
            return "Pendiente";
        }

    }

}

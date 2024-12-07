using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.EstadoNotaCompra_State
{
    public class EstadoPagada : IEstadoNotaCompra
    {
        public void Procesar(NotaCompra notaCompra)
        {
            Console.WriteLine("Error: La nota ya está pagada");
        }

        public void Pagar(NotaCompra notaCompra)
        {
            Console.WriteLine("Error: La nota ya está pagada");
        }

        public void Anular(NotaCompra notaCompra)
        {
            Console.WriteLine("Error: No se puede anular una nota pagada");
        }

        public void Finalizar(NotaCompra notaCompra)
        {
            notaCompra.CambiarEstado(new EstadoFinalizada());
            Console.WriteLine($"Nota de compra #{notaCompra.NroNotaCompra} finalizada");
        }

        public string ObtenerNombreEstado()
        {
            return "Pagada";
        }
    }
}

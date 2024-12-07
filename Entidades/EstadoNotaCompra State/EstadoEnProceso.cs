using Entidades.EstadoNotaCompra_State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EstadoEnProceso : IEstadoNotaCompra
    {
        public void Procesar(NotaCompra notaCompra)
        {
            Console.WriteLine("Error: La nota ya está en proceso");
        }

        public void Pagar(NotaCompra notaCompra)
        {
            notaCompra.CambiarEstado(new EstadoPagada());
            Console.WriteLine($"Nota de compra #{notaCompra.NroNotaCompra} pagada");
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
            return "EnProceso";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.EstadoNotaCompra_State
{
    public class EstadoAnulada : IEstadoNotaCompra
    {
        public void Procesar(NotaCompra notaCompra)
        {
            Console.WriteLine("Error: No se puede procesar una nota anulada");
        }

        public void Pagar(NotaCompra notaCompra)
        {
            Console.WriteLine("Error: No se puede pagar una nota anulada");
        }

        public void Anular(NotaCompra notaCompra)
        {
            Console.WriteLine("Error: La nota ya está anulada");
        }

        public void Finalizar(NotaCompra notaCompra)
        {
            Console.WriteLine("Error: No se puede finalizar una nota anulada");
        }

        public string ObtenerNombreEstado()
        {
            return "Anulada";
        }
    }
}

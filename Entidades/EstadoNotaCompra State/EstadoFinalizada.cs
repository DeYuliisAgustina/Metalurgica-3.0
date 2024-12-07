using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.EstadoNotaCompra_State
{
    public class EstadoFinalizada : IEstadoNotaCompra
    {
        public void Procesar(NotaCompra notaCompra)
        {
            Console.WriteLine("Error: La nota ya está finalizada");
        }
        public void Pagar(NotaCompra notaCompra)
        {
            Console.WriteLine("Error: La nota ya está finalizada");
        }
        public void Anular(NotaCompra notaCompra)
        {
            Console.WriteLine("Error: No se puede anular una nota finalizada");
        }
        public void Finalizar(NotaCompra notaCompra)
        {
            Console.WriteLine("Error: La nota ya está finalizada");
        }
        public string ObtenerNombreEstado()
        {
            return "Finalizada";
        }
    }
}

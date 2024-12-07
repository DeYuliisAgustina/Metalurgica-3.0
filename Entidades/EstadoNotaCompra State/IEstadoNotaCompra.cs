using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IEstadoNotaCompra
    {
        void Procesar(NotaCompra notaCompra);
        void Pagar(NotaCompra notaCompra);
        void Anular(NotaCompra notaCompra);
        void Finalizar(NotaCompra notaCompra);
        string ObtenerNombreEstado();
    }
}

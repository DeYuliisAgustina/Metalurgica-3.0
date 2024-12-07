using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleNotaVenta
    {
        public int DetalleNotaVentaId { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public int Cantidad { get; set; }

        public Producto Producto { get; set; }
    }
}

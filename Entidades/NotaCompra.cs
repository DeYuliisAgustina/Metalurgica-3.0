using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class NotaCompra
    {
        public int NotaCompraId { get; set; }
        public int NroNotaCompra { get; set; }
        public DateTime Fecha { get; set; }

        private IEstadoNotaCompra _estado; //uso del patron State

        public Cliente Cliente { get; set; }
        public Proveedor Proveedor { get; set; }
        public List<Producto> ListaProductos { get; set; }
        public List<DetalleNotaCompra> DetalleNotaCompra { get; set; }


        public enum TipoMedioPago {Efectivo, Transferencia, Cheque}
        public TipoMedioPago MedioPago { get; set; }

        public void CambiarEstado(IEstadoNotaCompra nuevoEstado)
        {
            _estado = nuevoEstado;
        }

        public string ObtenerEstado()
        {
            return _estado.ObtenerNombreEstado();
        }

        public void Procesar()
        {
            _estado.Procesar(this);
        }

        public void Anular()
        {
            _estado.Anular(this);
        }

        public void Finalizar()
        {
            _estado.Finalizar(this);
        }

        public void Pagar()
        {
            _estado.Pagar(this);
        }

    }
}

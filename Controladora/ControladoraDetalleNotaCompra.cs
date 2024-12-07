using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class ControladoraDetalleNotaCompra
    {
        Context context;

        private ControladoraDetalleNotaCompra()
        {
            context = new Context();
        }

        private static ControladoraDetalleNotaCompra instancia;

        public static ControladoraDetalleNotaCompra Instancia
        {

            get
            {
                if (instancia == null)
                    instancia = new ControladoraDetalleNotaCompra();
                return instancia;
            }
        }
    }
}

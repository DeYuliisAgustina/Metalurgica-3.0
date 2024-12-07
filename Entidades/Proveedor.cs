using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Proveedor : Persona
    {
        public int ProveedorId { get; set; }
        public string RazonSocial { get; set; }
        public string CUIT { get; set; }
    }
}

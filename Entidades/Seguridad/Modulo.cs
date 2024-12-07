using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Seguridad
{
    public class Modulo
    {
        public int ModuloId { get; set; }
        public string Nombre { get; set; }

        public List<Formulario> Formularios { get; set; }
    }
}

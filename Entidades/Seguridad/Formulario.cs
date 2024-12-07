using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Seguridad
{
    public class Formulario
    {
        public int FormularioId { get; set; }
        public string Nombre { get; set; }

        public Modulo Modulo { get; set; }
        public List<Accion> Acciones { get; set; }
    }
}

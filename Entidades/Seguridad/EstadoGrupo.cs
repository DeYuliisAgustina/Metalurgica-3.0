using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Seguridad
{
    public class EstadoGrupo
    {
        public int EstadoGrupoId { get; set; }
        public string Nombre { get; set; }

        public List<Grupo> Grupos { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Seguridad
{
    public class EstadoUsuario
    {
        public int EstadoUsuarioId { get; set; }
        public string Nombre { get; set; }

        public List<Usuario> Usuarios { get; set; }

    }
}

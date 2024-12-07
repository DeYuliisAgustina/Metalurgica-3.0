using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Seguridad
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string Email { get; set; }

        public EstadoUsuario EstadoUsuario { get; set; }
        public Persona Persona { get; set; }

        public List<Componente> Perfil { get; set; } = new List<Componente>();

        public void AgregarPermiso(Componente componente)
        {
            Perfil.Add(componente);
        }

        public void EliminarPermiso(Componente componente)
        {
            Perfil.Remove(componente);
        }
    }
}

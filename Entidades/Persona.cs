using Entidades.Seguridad;

namespace Entidades
{
    public class Persona 
    {
        public int PersonaId { get; set; }
        public string NombreyApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public long DNI { get; set; }
        public string Telefono { get; set; }
        public string Domicilio { get; set; }
        public string Email { get; set; }

        public Usuario Usuario { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Seguridad
{
    public class Accion : Componente
    {
        public int AccionId { get; set; }

        public Formulario Formulario { get; set; }

        public override void AgregarHijo(Componente componente)
        {
            throw new NotImplementedException();
        }

        public override void EliminarHijo(Componente componente)
        {
            throw new NotImplementedException();
        }

        public override void Display(int depth)
        {
            throw new NotImplementedException();
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente : Persona
    {
        public int ClienteId { get; set; }
        public string RazonSocial { get; set; }
    }
}

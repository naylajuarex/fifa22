using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fifa.Core
{
    public class Habilidad
    {
        public byte idHabilidad { get; set; }
        public string nHabilidad { get; set; }
        public string descripcion { get; set; }

        public Habilidad(string nHabilidad, string descripcion)
        {
            this.nHabilidad = nHabilidad;
            this.descripcion = descripcion;
        }


    }
}
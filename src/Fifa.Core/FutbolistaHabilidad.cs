using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fifa.Core
{
    public class FutbolistaHabilidad
    {
        public int idFutbolista { get; set; }
        public byte idHabilidad { get; set; }

        public FutbolistaHabilidad(byte idHabilidad)
        {
            this.idHabilidad = idHabilidad;
        }

        public FutbolistaHabilidad()
        {

        }
    }
}
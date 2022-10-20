using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fifa.Core
{
    public class FutbolistaHabilidad
    {
        public int idFutbolista { get; set; }
        public ushort idHabilidad { get; set; }

        public FutbolistaHabilidad(ushort idHabilidad)
        {
            this.idHabilidad = idHabilidad;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fifa.Core
{
    public class FutbolistaHabilidad
    {
        public Futbolista idFutbolista { get; set; }
        public Habilidad idHabilidad { get; set; }

        public FutbolistaHabilidad(Futbolista idFutbolista, Habilidad idHabilidad)
        {
            this.idFutbolista = idFutbolista;
            this.idHabilidad = idHabilidad;
        }

        public FutbolistaHabilidad()
        {

        }
    }
}
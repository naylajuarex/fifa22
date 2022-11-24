using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fifa.Core
{
    public class Posesion
    {
        public byte idJugador { get; set; }
        public byte idFutbolista { get; set; }

        public Posesion(byte idJugador, byte idFutbolista)
        {
            this.idFutbolista = idFutbolista;
            this.idJugador = idJugador;
        }
        public Posesion()
        {
        }
    }

}
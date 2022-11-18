using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fifa.Core
{
    public class Posesion
    {
        public Jugador idJugador { get; set; }
        public Futbolista idFutbolista { get; set; }

        public Posesion(Jugador idJugador, Futbolista idFutbolista)
        {
            this.idFutbolista = idFutbolista;
            this.idJugador = idJugador;
        }
        public Posesion()
        {
        }
    }

}
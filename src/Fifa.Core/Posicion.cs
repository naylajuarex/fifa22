using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fifa.Core
{
    public class Posicion
    {
        public byte ubiCampo { get; set; }
        public string nPosicion { get; set; }

        public Posicion(byte ubiCampo, string nPosicion)
        {
            this.nPosicion = nPosicion;
            this.ubiCampo = ubiCampo;
        }

        public Posicion()
        {

        }
    }
}
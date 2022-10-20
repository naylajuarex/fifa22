using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fifa.Core
{
    public class Futbolista
    {
        public ushort idFutbolista { get; set; }
        public byte ubiCampo { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime nacimiento { get; set; }
        public byte velocidad { get; set; }
        public byte remate { get; set; }
        public byte pase { get; set; }
        public byte defensa { get; set; }

        public Futbolista(byte ubiCampo, string nombre, string apellido, DateTime nacimiento, byte velocidad, byte remate, byte pase, byte defensa)
        {
            this.ubiCampo = ubiCampo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacimiento = nacimiento;
            this.velocidad = velocidad;
            this.remate = remate;
            this.pase = pase;
            this.defensa = defensa;
        }


    }
}
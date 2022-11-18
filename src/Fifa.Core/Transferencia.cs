using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fifa.Core
{
    public class Transferencia
    {
        public DateTime fyhPublicado { get; set; }
        public Jugador idVendedor { get; set; }
        public Jugador idComprador { get; set; }
        public uint precio { get; set; }
        public DateTime fyhTerminado { get; set; }
        public Futbolista idFutbolista { get; set; }
        public Transferencia() { }
        public Transferencia(DateTime fyhPublicdo, DateTime fyhTerminado, Jugador idVendedor, Jugador idComprador, Futbolista idFutbolista, uint precio)
        {
            this.fyhPublicado = fyhPublicdo;
            this.fyhTerminado = fyhTerminado;
            this.idVendedor = idVendedor;
            this.idComprador = idComprador;
            this.idFutbolista = idFutbolista;
            this.precio = precio;
        }

    }



}
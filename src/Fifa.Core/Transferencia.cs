using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fifa.Core
{
    public class Transferencia
    {
        public DateTime fyhPublicado { get; set; }
        public uint idVendedor { get; set; }
        public uint idComprador { get; set; }
        public uint precio { get; set; }
        public DateTime fyhTerminado { get; set; }
        public ushort idFutbolista { get; set; }
    }
}
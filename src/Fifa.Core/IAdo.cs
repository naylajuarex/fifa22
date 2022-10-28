using System.Collections.Generic;
using Fifa22.Core;

namespace Fifa22.Core.Ado
{
    public interface IAdo
    {
        void AltaFutbolista(Futbolista futbolista);
        List<Futbolista> ObtenerFutbolista();
    }
}
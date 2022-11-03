using Fifa.Core;

namespace Fifa22.Core.Ado
{
    public interface IAdo
    {
        void AltaJugador(Jugador jugador);
        List<Jugador> ObtenerJugador();
    }
}
using Fifa.Core;

namespace Fifa22.Core.Ado
{
    public interface IAdo
    {
        void AltaJugador(Jugador jugador);
        List<Jugador> ObtenerJugador();
        Jugador ObtenerJugadorPorId(byte id);
        void AltaHabilidad(Habilidad habilidad);
        List<Habilidad> ObtenerHabilidad();

        void AltaFutbolista(Futbolista futbolista);
        List<Futbolista> ObtenerFutbolista();
        Futbolista ObtenerFutbolistaPorId(byte id);

        void AltaPosicion(Posicion posicion);
        List<Posicion> ObtenerPosicion();
        Posicion ObtenerPosicionPorId(byte id);


    }
}
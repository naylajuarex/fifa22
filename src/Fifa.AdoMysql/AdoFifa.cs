using et12.edu.ar.AGBD.Ado;
using Fifa.Core;
using Fifa22.Core.Ado;

namespace Fifa.AdoMysql;
public class AdoFifa : IAdo
{
    public AdoAGBD AdoAGBD { get; set; }
    public MapJugador MapJugador { get; set; }

    public AdoFifa(AdoAGBD adoAGBD)
    {
        AdoAGBD = adoAGBD;
        MapJugador = new MapJugador(adoAGBD);
    }

    public void AltaJugador(Jugador jugador)
        => MapJugador.AltaJugador(jugador);

    public List<Jugador> ObtenerJugador()
        => MapJugador.ColeccionDesdeTabla();
}
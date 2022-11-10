using et12.edu.ar.AGBD.Ado;
using Fifa.AdoMysql;
using Fifa.Core;

namespace Fifa.AdoMysql.Test;

public class MapJugadorTest
{
    public AdoFifa Ado { get; set; }
    public MapJugadorTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoFifa(adoAGBD);
    }

    [Fact]
    public void AltaJugador()
    {
        var jugador = new Jugador(1, "Fernando", "Flores", "Fernanfloo", "fernanelcrack", 10);
        Ado.AltaJugador(jugador);
        Assert.Equal((uint)1, jugador.idJugador);
    }

    [Theory]
    [InlineData(2, "FernanElFail")]

    public void TraerJugadores(byte id, string nombre)
    {
        var jugadores = Ado.ObtenerJugador();
        Assert.Contains(jugadores, r => r.idJugador == id && r.Nombre == nombre);
    }
}
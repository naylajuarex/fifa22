using et12.edu.ar.AGBD.Ado;
using Fifa.AdoMysql;
using Fifa.Core;

namespace Fifa.AdoMysql.Test;

public class MapPosesionTest
{
    public AdoFifa Ado { get; set; }
    public MapPosesionTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoFifa(adoAGBD);
    }
    [Fact]
    public void AltaPosesion()
    {
        var posesion = new Posesion();
        Ado.AltaPosesion(posesion);
        Assert.Equal(1, posesion.idFutbolista);
    }

    [Theory]
    [InlineData(1, "pancho", "meu")]
    public void TraerPosiciones(Jugador idJugador, Futbolista idFutbolista)
    {
        var posesion = Ado.ObtenerPosesion();
        Assert.Contains(posesion, P => P.idJugador == idJugador && P.idFutbolista == idFutbolista);
    }
}
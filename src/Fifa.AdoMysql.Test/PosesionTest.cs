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
        var posesion = new Posesion(Ado.ObtenerJugadorPorId(1), Ado.ObtenerFutbolistaPorId(15));
        Ado.AltaPosesion(posesion);
        Assert.Equal(15, posesion.idFutbolista.idFutbolista);
    }

    [Theory]
    [InlineData(1, 14)]
    public void TraerPosiciones(byte idJugador, byte idFutbolista)
    {
        var posesion = Ado.ObtenerPosesion();
        Assert.Contains(posesion, P => P.idJugador.idJugador == idJugador && P.idFutbolista.idFutbolista == idFutbolista);
    }
}
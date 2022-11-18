using et12.edu.ar.AGBD.Ado;
using Fifa.AdoMysql;
using Fifa.Core;

namespace Fifa.AdoMysql.Test;

public class MapPosicionTest
{
    public AdoFifa Ado { get; set; }
    public MapPosicionTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoFifa(adoAGBD);
    }
    [Fact]
    public void AltaPosicion()
    {
        var posicion = new Posicion(1, "delantero");
        Ado.AltaPosicion(posicion);
        Assert.Equal(1, posicion.ubiCampo);
    }

    [Theory]
    [InlineData(1, "delantero")]
    public void TraerPosiciones(byte ubiCampo, string nPosicion)
    {
        var posiciones = Ado.ObtenerPosicion();
        Assert.Contains(posiciones, P => P.ubiCampo == ubiCampo && P.nPosicion == nPosicion);
    }
}
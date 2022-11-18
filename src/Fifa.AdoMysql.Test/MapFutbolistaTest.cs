using et12.edu.ar.AGBD.Ado;
using Fifa.AdoMysql;
using Fifa.Core;

namespace Fifa.AdoMysql.Test;

public class MapFutbolistaTest
{
    public AdoFifa Ado { get; set; }
    public MapFutbolistaTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoFifa(adoAGBD);
    }
    [Fact]
    public void AltaFutbolista()
    {
        DateTime ahora = new DateTime(1995, 04, 18);
        var futbolista = new Futbolista(1, - , "Tomas", "Bernoulli", ahora, 92, 84, 86, 93);
        Ado.AltaFutbolista(futbolista);
        Assert.Equal(1, futbolista.idFutbolista);
    }

    [Theory]
    [InlineData(1, 2)]
    public void TraerFutbolista(byte idFutbolista, Posicion ubiCampo, string nombre, string apellido, DateTime nacimiento, byte velocidad, byte remate, byte pase, byte defensa)
    {
        var futbolista = Ado.ObtenerFutbolista();
        Assert.Contains(futbolista, F => F.idFutbolista == idFutbolista && F.ubiCampo == ubiCampo && F.nombre == nombre && F.apellido == apellido && F.nacimiento == nacimiento && F.velocidad == velocidad && F.remate == remate && F.pase == pase && F.defensa == defensa);
    }
}
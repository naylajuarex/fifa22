using et12.edu.ar.AGBD.Ado;
using Fifa.AdoMysql;
using Fifa.Core;

namespace Fifa.AdoMysql.Test;

public class MapFutbolistaHabilidadTest
{
    public AdoFifa Ado { get; set; }
    public MapFutbolistaHabilidadTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoFifa(adoAGBD);
    }
    [Fact]
    public void AltaFutbolistahabilidad()
    {
        var futbolistahabilidad = new FutbolistaHabilidad(Ado.ObtenerFutbolistaPorId(14), Ado.ObtenerHabilidadPorId(56));
        Ado.AltaFutbolistahabilidad(futbolistahabilidad);
        Assert.Equal(14, futbolistahabilidad.idFutbolista.idFutbolista);
    }

    [Theory]
    [InlineData(14,24)]
    public void TraerFutbolistahabilidad(int idFutbolista, byte idHabilidad)
    {
        var futbolistahabilidad = Ado.ObtenerFutbolistahabilidad();
        Assert.Contains(futbolistahabilidad, F => F.idFutbolista.idFutbolista == idFutbolista && F.idHabilidad.idHabilidad == idHabilidad);
    }
}
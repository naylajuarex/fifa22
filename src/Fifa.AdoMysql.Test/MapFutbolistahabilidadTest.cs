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
        var futbolistahabilidad = new FutbolistaHabilidad(1, Ado.ObtenerHabilidadPorId(2));
        Ado.AltaFutbolistahabilidad(futbolistahabilidad);
        Assert.Equal(1, futbolistahabilidad.idFutbolista);
    }

    [Theory]
    [InlineData(1, 2)]
    public void TraerFutbolistahabilidad(int idFutbolista, Habilidad idHabilidad)
    {
        var futbolistahabilidad = Ado.ObtenerFutbolistahabilidad();
        Assert.Contains(futbolistahabilidad, F => F.idFutbolista == idFutbolista && F.idHabilidad == idHabilidad);
    }
}
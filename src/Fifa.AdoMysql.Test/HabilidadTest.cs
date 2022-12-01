using et12.edu.ar.AGBD.Ado;
using Fifa.AdoMysql;
using Fifa.Core;

namespace Fifa.AdoMysql.Test;

public class MapHabilidadTest
{
    public AdoFifa Ado { get; set; }
    public MapHabilidadTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoFifa(adoAGBD);
    }
    [Fact]
    public void AltaHabilidad()
    {
        var habilidad = new Habilidad(3, "saltar", "...");
        Ado.AltaHabilidad(habilidad);
        Assert.Equal(3, habilidad.idHabilidad);
    }

    [Theory]
    [InlineData(24, "chilena")]
    public void TraerHabilidades(byte idHabilidad, string nHabilidad)
    {
        var habilidades = Ado.ObtenerHabilidad();
        Assert.Contains(habilidades, H => H.idHabilidad == idHabilidad);
    }
}
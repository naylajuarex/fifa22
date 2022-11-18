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
        var habilidad = new Habilidad(1,"pancho", "meu");
        Ado.altaHabilidad(habilidad);
        Assert.Equal(1, habilidad.idHabilidad);
    }

    [Theory]
    [InlineData(1, "pancho", "meu")]
    public void TraerHabilidades(byte idHabilidad, string nHabilidad, string descripcion)
    {
        var habilidades = Ado.ObtenerHabilidad();
        Assert.Contains(habilidades, H => H.idHabilidad == idHabilidad && H.nHabilidad == nHabilidad && H.descripcion == descripcion);
    }
}
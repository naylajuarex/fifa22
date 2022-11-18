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
        var posesion = new Posesion (1,2);
        Ado.altaPosesion(posesion);
        Assert.Equal(1, posesion.idHabilidad);
    }

    [Theory]
    [InlineData(1, "pancho", "meu")]
    public void TraerHabilidades(byte idHabilidad, string nHabilidad, string descripcion)
    {
        var habilidades = Ado.ObtenerHabilidad();
        Assert.Contains(habilidades, H => H.idHabilidad == idHabilidad && H.nHabilidad == nHabilidad && H.descripcion == descripcion);
    }
}
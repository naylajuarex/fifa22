using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System.Data;
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
        var delantero = Ado.ObtenerPosicionPorId(12);
        var futbolista = new Futbolista(
            idFutbolista : 0, ubiCampo: delantero,
            nombre : "Roberto", apellido: "Bernoulli",
            nacimiento : ahora, velocidad: 92, pase: 84,
            remate: 86, defensa: 93);
        Ado.AltaFutbolista(futbolista);
        Assert.Equal(3, futbolista.idFutbolista);
    }

    [Theory]
    [InlineData(14,"Pepe")]
    public void TraerFutbolista(byte idFutbolista, string nombre)
    {
        var futbolista = Ado.ObtenerFutbolista();

        Assert.Contains(futbolista, F => F.idFutbolista == idFutbolista && F.nombre == nombre);
    }
}
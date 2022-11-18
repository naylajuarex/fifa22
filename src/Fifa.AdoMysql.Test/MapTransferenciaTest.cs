using et12.edu.ar.AGBD.Ado;
using Fifa.AdoMysql;
using Fifa.Core;

namespace Fifa.AdoMysql.Test;

public class MapTransferenciaTest
{
    public AdoFifa Ado { get; set; }
    public MapTransferenciaTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoFifa(adoAGBD);
    }
    [Fact]
    public void AltaTransferencia()
    {
        DateTime ahora = new DateTime(2022, 11, 18);
        DateTime antes = new DateTime(2022, 10, 18);
        var transferencia = new Transferencia(antes, ahora, Ado.ObtenerJugadorPorId(1), Ado.ObtenerJugadorPorId(2), Ado.ObtenerFutbolistaPorId(1), 430);
        Ado.AltaTransferencia(transferencia);
        Assert.Equal(ahora, transferencia.fyhPublicado);
    }

    [Theory]
    [InlineData(1, 1)]
    public void TraerTransferencias(Int16 idComprador, Int16 idVendedor)
    {
        var transferencias = Ado.ObtenerTransferencia();
        Assert.Contains(transferencias, T => T.idComprador.idJugador == idComprador && T.idVendedor.idJugador == idVendedor);
    }
}
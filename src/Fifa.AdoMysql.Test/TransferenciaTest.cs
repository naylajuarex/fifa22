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
        var transferencia = new Transferencia(ahora,antes , Ado.ObtenerJugadorPorId(2), Ado.ObtenerJugadorPorId(1), Ado.ObtenerFutbolistaPorId(2), 430);
        Ado.AltaTransferencia(transferencia);
        Assert.Equal(ahora, transferencia.fyhPublicado);
    }

    [Theory]
    [InlineData(1, 2)]
    public void TraerTransferencias(byte idComprador, byte idVendedor)
    {
        var transferencias = Ado.ObtenerTransferencia();
        Assert.Contains(transferencias, T => T.idComprador.idJugador == idComprador && T.idVendedor.idJugador == idVendedor);
    }
}
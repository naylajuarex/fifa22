using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System.Data;
using Fifa.Core;

namespace Fifa.AdoMysql;
public class MapTransferencia : Mapeador<Transferencia>
{
    public MapJugador MapJugador { get; set; }
    public MapJugador MapJugador2 { get; set; }
    public MapFutbolista MapFutbolista { get; set; }
    public MapTransferencia(AdoAGBD ado) : base(ado) => Tabla = "Transferencia";

    public MapTransferencia(MapJugador mapJugador, MapJugador mapJugador2, MapFutbolista mapFutbolista) : this(mapJugador.AdoAGBD)
    {
        MapJugador = mapJugador;
        MapJugador2 = mapJugador2;
        MapFutbolista = mapFutbolista;
    }


    public override Transferencia ObjetoDesdeFila(DataRow fila)
            => new Transferencia()
            {

                fyhPublicado = Convert.ToDateTime(fila["fyhPublicado"]),
                fyhTerminado = Convert.ToDateTime(fila["fyhTerminado"]),
                idVendedor = MapJugador.JugadorPorId(Convert.ToInt16(fila["idVendedor"])),
                idComprador = MapJugador.JugadorPorId(Convert.ToInt16(fila["idComprador"])),
                precio = Convert.ToUInt16(fila["precio"]),
                idFutbolista = MapFutbolista.FutbolistaPorId(Convert.ToByte(fila["idFutbolista"])),
            };

    public void AltaTransferencia(Transferencia transferencia)
=> EjecutarComandoCon("altaTransferencia", ConfigurarAltaTransferencia, PostAltaTransferencia, transferencia);

    public Transferencia TransferenciaPorId(DateTime fyhPublicado)
        => FiltrarPorPK("fyhPublicado", fyhPublicado)!;

    public void ConfigurarAltaTransferencia(Transferencia transferencia)
    {
        SetComandoSP("altaTransferencia");

        BP.CrearParametroSalida("unfyhPublicado")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
            .SetValor(transferencia.fyhPublicado)
            .AgregarParametro();

        BP.CrearParametro("unfyhTerminado")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
            .SetValor(transferencia.fyhTerminado)
            .AgregarParametro();

        BP.CrearParametro("unidVendedor")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(transferencia.idVendedor.idJugador)
            .AgregarParametro();

        BP.CrearParametro("unidComprador")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(transferencia.idComprador.idJugador)
            .AgregarParametro();

        BP.CrearParametro("unprecio")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(transferencia.precio)
            .AgregarParametro();

        BP.CrearParametro("unidFutbolista")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(transferencia.idFutbolista)
            .AgregarParametro();
    }

    public void PostAltaTransferencia(Transferencia transferencia)
    {
        var paramfyhPublicado = GetParametro("unfyhPublicado");
        transferencia.fyhPublicado = Convert.ToDateTime(paramfyhPublicado.Value);
    }
}

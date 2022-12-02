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
                fyhTerminado = FechaONull(fila["fyhTerminado"]),
                idVendedor = MapJugador.JugadorPorId(Convert.ToByte(fila["idVendedor"]))!,
                idComprador = JugadorONull(fila["idComprador"]),
                precio = Convert.ToUInt16(fila["precio"]),
                idFutbolista = MapFutbolista.FutbolistaPorId(Convert.ToByte(fila["idFutbolista"]))
            };

    private DateTime? FechaONull(object valor)
        => valor == DBNull.Value ? null : Convert.ToDateTime(valor);

    private Jugador? JugadorONull(object valor)
        => valor != DBNull.Value ?
            MapJugador2.JugadorPorId(Convert.ToByte(valor)) :
            null;

    public void AltaTransferencia(Transferencia transferencia)
=> EjecutarComandoCon("publicar", ConfigurarAltaTransferencia, transferencia);

    public Transferencia TransferenciaPorId(DateTime fyhPublicado)
        => FiltrarPorPK("fyhPublicado", fyhPublicado)!;

    public void ConfigurarAltaTransferencia(Transferencia transferencia)
    {
        SetComandoSP("publicar");

        BP.CrearParametro("unfyhPublicado")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
            .SetValor(transferencia.fyhPublicado)
            .AgregarParametro();

        BP.CrearParametro("unidVendedor")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(transferencia.idVendedor.idJugador)
            .AgregarParametro();

        BP.CrearParametro("unprecio")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(transferencia.precio)
            .AgregarParametro();

        BP.CrearParametro("unidFutbolista")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(transferencia.idFutbolista.idFutbolista)
            .AgregarParametro();
    }
}

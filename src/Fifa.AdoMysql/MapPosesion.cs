using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System.Data;
using Fifa.Core;

namespace Fifa.AdoMysql;
public class MapPosesion : Mapeador<Posesion>
{
    public MapJugador MapJugador { get; set; }

    public MapFutbolista MapFutbolista { get; set; }
    public MapPosesion(AdoAGBD ado) : base(ado) => Tabla = "Posesion";
    public MapPosesion(MapJugador mapJugador, MapFutbolista mapFutbolista) : this(mapJugador.AdoAGBD)
    {
        MapJugador = mapJugador;
        MapFutbolista = mapFutbolista;
    }

    public override Posesion ObjetoDesdeFila(DataRow fila)
            => new Posesion()
            {
                idJugador = MapJugador.JugadorPorId(Convert.ToByte(fila["idJugador"])),
                idFutbolista = MapFutbolista.FutbolistaPorId(Convert.ToByte(fila["idFutbolista"])),
            };

    public void AltaPosesion(Posesion posesion)
        => EjecutarComandoCon("altaPosesion", ConfigurarAltaPosesion, posesion);

    public Posesion PosesionPorId(byte id)
        => FiltrarPorPK("idJugador", id)!;
    public void ConfigurarAltaPosesion(Posesion Posesion)
    {
        SetComandoSP("altaPosesion");

        BP.CrearParametro("unidJugador")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(Posesion.idJugador.idJugador)
            .AgregarParametro();

        BP.CrearParametro("unidFutbolista")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(Posesion.idFutbolista.idFutbolista)
            .AgregarParametro();

    }

}
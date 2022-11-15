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
                idJugador = MapJugador.JugadorPorId(Convert.ToUInt16(fila["idJugador"])),
                idFutbolista = MapFutbolista.FutbolistaPorId("idFutbolista", Convert.ToByte(fila["idFutbolista"])),
            };

    public void AltaPosesion(Posesion posesion)
        => EjecutarComandoCon("altaPosesion", ConfigurarAltaPosesion, PostAltaPosesion, posesion);

    public void ConfigurarAltaPosesion(Posesion Posesion)
    {
        SetComandoSP("altaPosesion");

        BP.CrearParametroSalida("unidJugador")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(Posesion.idJugador)
            .AgregarParametro();

        BP.CrearParametro("unidFutbolista")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(Posesion.idFutbolista)
            .AgregarParametro();

    }

    public void PostAltaPosesion(Posesion posesion)
    {
        var paramIdPosesion = GetParametro("unIdPosesion");
        posesion.idFutbolista = Convert.ToUInt16(paramIdPosesion.Value);
    }
}
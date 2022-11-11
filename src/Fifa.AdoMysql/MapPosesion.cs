using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System.Data;
using Fifa.Core;

namespace Fifa.AdoMysql;
public class MapPosesion : Mapeador<Posesion>
{
    public MapPosesion(AdoAGBD ado) : base(ado) => Tabla = "Posesion";
    public override Posesion ObjetoDesdeFila(DataRow fila)
            => new Posesion()
            {
                posesion = MapPosesion.FiltrarPorPk("idPosesion", Convert.ToUInt16(fila["idPosesion"])),
                idJugador = Convert.ToUInt16(fila["idJugador"]),
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
        posesion. = Convert.UInt16(paramIdPosesion.Value);
    }
}
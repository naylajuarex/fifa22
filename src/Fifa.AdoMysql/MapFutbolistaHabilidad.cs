using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System.Data;
using Fifa.Core;

namespace Fifa.AdoMysql;
public class MapFutbolistaHabilidad : Mapeador<FutbolistaHabilidad>
{
    public MapFutbolistaHabilidad(AdoAGBD ado) : base(ado) => Tabla = "FutbolistaHabilidad";
    public override FutbolistaHabilidad ObjetoDesdeFila(DataRow fila)
            => new FutbolistaHabilidad()
            {
                idFutbolista = Convert.ToByte(fila["idFutbolista"]),
                idHabilidad = Convert.ToByte(fila["idHabilidad"]),
            };

    public void AltaFutbolistaHabilidad(FutbolistaHabilidad futbolistaHabilidad)
        => EjecutarComandoCon("altaFutbolistaHabilidad", ConfigurarAltaFutbolistaHabilidad, PostAltaFutbolistaHabilidad, futbolistaHabilidad);

    public void ConfigurarAltaFutbolistaHabilidad(FutbolistaHabilidad futbolistaHabilidad)
    {
        SetComandoSP("AltaFutbolistaHabilidad");

        BP.CrearParametroSalida("unidFutbolista")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(futbolistaHabilidad.idFutbolista)
            .AgregarParametro();

        BP.CrearParametro("unidHabilidad")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(futbolistaHabilidad.idFutbolista)
            .AgregarParametro();

    }

    public void PostAltaFutbolistaHabilidad(FutbolistaHabilidad futbolistaHabilidad)
    {
        var paramidFutbolista = GetParametro("unidFutbolista");
        futbolistaHabilidad.idFutbolista = Convert.ToByte(paramidFutbolista.Value);
    }
}
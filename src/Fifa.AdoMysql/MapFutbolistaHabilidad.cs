using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System.Data;
using Fifa.Core;

namespace Fifa.AdoMysql;
public class MapFutbolistaHabilidad : Mapeador<FutbolistaHabilidad>
{
    public MapHabilidad MapHabilidad { get; set; }
    public MapFutbolista MapFutbolista { get; set; }
    public MapFutbolistaHabilidad(AdoAGBD ado) : base(ado) => Tabla = "FutbolistaHabilidad";

    public MapFutbolistaHabilidad(MapHabilidad mapHabilidad,MapFutbolista mapFutbolista) : this(mapHabilidad.AdoAGBD)
    {
        Tabla = "FutbolistaHabilidad";
        MapFutbolista = mapFutbolista;
        MapHabilidad = mapHabilidad;
    }
    public override FutbolistaHabilidad ObjetoDesdeFila(DataRow fila)
            => new FutbolistaHabilidad()
            {
                idFutbolista = MapFutbolista.FutbolistaPorId(Convert.ToByte(fila["idFutbolista"])),
                idHabilidad = MapHabilidad.HabilidadPorId(Convert.ToByte(fila["idHabilidad"])),
            };

    public void AltaFutbolistaHabilidad(FutbolistaHabilidad futbolistaHabilidad)
        => EjecutarComandoCon("altaFutbolistaHabilidad", ConfigurarAltaFutbolistaHabilidad, PostAltaFutbolistaHabilidad, futbolistaHabilidad);

    public void ConfigurarAltaFutbolistaHabilidad(FutbolistaHabilidad futbolistaHabilidad)
    {
        SetComandoSP("AltaFutbolistaHabilidad");

        BP.CrearParametro("unidFutbolista")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(futbolistaHabilidad.idFutbolista.idFutbolista)
            .AgregarParametro();

        BP.CrearParametro("unidHabilidad")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(futbolistaHabilidad.idHabilidad.idHabilidad)
            .AgregarParametro();

    }

    public void PostAltaFutbolistaHabilidad(FutbolistaHabilidad futbolistaHabilidad)
    {
        var paramidFutbolista = GetParametro("unidFutbolista");
        futbolistaHabilidad.idFutbolista.idFutbolista = Convert.ToByte(paramidFutbolista.Value);
    }
}
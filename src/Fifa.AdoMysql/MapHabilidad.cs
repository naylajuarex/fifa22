using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System.Data;
using Fifa.Core;

namespace Fifa.AdoMysql;
public class MapHabilidad : Mapeador<Habilidad>
{
    public MapHabilidad(AdoAGBD ado) : base(ado) => Tabla = "Habilidad";
    public override Habilidad ObjetoDesdeFila(DataRow fila)
            => new Habilidad()
            {
                idHabilidad = Convert.ToByte(fila["idHabilidad"]),
                nHabilidad = fila["nHabilidad"].ToString()!,
                descripcion = fila["Descripcion"].ToString()!,
            };

    public void AltaHabilidad(Habilidad habilidad)
        => EjecutarComandoCon("altaHabilidad", ConfigurarAltaHabilidad, PostAltaHabilidad, habilidad);

    public Habilidad HabilidadPorId(byte id)
        => FiltrarPorPK("idHabilidad", id)!;

    public void ConfigurarAltaHabilidad(Habilidad habilidad)
    {
        SetComandoSP("altaHabilidad");

        BP.CrearParametroSalida("unidHabilidad")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(habilidad.idHabilidad)
            .AgregarParametro();

        BP.CrearParametro("unnHabilidad")
            .SetTipoVarchar(45)
            .SetValor(habilidad.nHabilidad)
            .AgregarParametro();

        BP.CrearParametro("undescripcion")
            .SetTipoVarchar(45)
            .SetValor(habilidad.descripcion)
            .AgregarParametro();

    }

    public void PostAltaHabilidad(Habilidad habilidad)
    {
        var paramIdHabilidad = GetParametro("unidHabilidad");
        habilidad.idHabilidad = Convert.ToByte(paramIdHabilidad.Value);
    }
}
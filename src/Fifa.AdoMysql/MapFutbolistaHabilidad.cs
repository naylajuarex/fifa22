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
                ubiCampo = Convert.ToByte(fila["ubiCampo"]),
                nPosicion = fila["nPosicion"].ToString(),
            };

    public void AltaHabilidad(FutbolistaHabilidad futbolistaHabilidad)
        => EjecutarComandoCon("altaPosicion", ConfigurarAltaPosicion, PostAltaPosicion, posicion);

    public void ConfigurarAltaPosicion(Posicion posicion)
    {
        SetComandoSP("altaPosicion");

        BP.CrearParametroSalida("unubiCampo")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(posicion.ubiCampo)
            .AgregarParametro();

        BP.CrearParametro("unnPosicion")
            .SetTipoVarchar(20)
            .SetValor(posicion.nPosicion)
            .AgregarParametro();

    }

    public void PostAltaPosicion(Posicion posicion)
    {
        var paramubiCampo = GetParametro("unubiCampo");
        posicion.ubiCampo = Convert.ToByte(paramubiCampo.Value);
    }
}
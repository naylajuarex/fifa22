using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System.Data;
using Fifa.Core;

namespace Fifa.AdoMysql;
public class MapPosicion : Mapeador<Posicion>
{

    public MapPosicion(AdoAGBD ado) : base(ado) => Tabla = "Posicion";
    public override Posicion ObjetoDesdeFila(DataRow fila)
            => new Posicion()
            {
                ubiCampo = Convert.ToByte(fila["ubiCampo"]),
                nPosicion = fila["nPosicion"].ToString()!,
            };

    public void AltaPosicion(Posicion posicion)
        => EjecutarComandoCon("altaPosicion", ConfigurarAltaPosicion, PostAltaPosicion, posicion);

    public Posicion PosicionPorId(byte id)
        => FiltrarPorPK("ubiCampo", id)!;

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
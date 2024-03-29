using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System.Data;
using Fifa.Core;

namespace Fifa.AdoMysql;
public class MapFutbolista : Mapeador<Futbolista>
{
    public MapPosicion MapPosicion { get; set; }
    public MapFutbolista(AdoAGBD ado) : base(ado) => Tabla = "Futbolista";

    public MapFutbolista(MapPosicion mapPosicion) : base(mapPosicion.AdoAGBD)
    {
        Tabla = "Futbolista";
        MapPosicion = mapPosicion;
    }
    public override Futbolista ObjetoDesdeFila(DataRow fila)
            => new Futbolista()
            {
                idFutbolista = Convert.ToByte(fila["idFutbolista"]),
                ubiCampo = MapPosicion.PosicionPorId(Convert.ToByte(fila["ubiCampo"])),
                nombre = fila["nombre"].ToString()!,
                apellido = fila["apellido"].ToString()!,
                nacimiento = Convert.ToDateTime(fila["nacimiento"]),
                velocidad = Convert.ToByte(fila["velocidad"]),
                remate = Convert.ToByte(fila["remate"]),
                pase = Convert.ToByte(fila["pase"]),
                defensa = Convert.ToByte(fila["defensa"])
            };

    public void AltaFutbolista(Futbolista futbolista)
        => EjecutarComandoCon("altaFutbolista", ConfigurarAltaFutbolista, PostAltaFutbolista, futbolista);

    public Futbolista FutbolistaPorId(byte id)
    => FiltrarPorPK("idFutbolista", id)!;

    public void ConfigurarAltaFutbolista(Futbolista futbolista)
    {
        SetComandoSP("altaFutbolista");

        BP.CrearParametroSalida("unidFutbolista")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(futbolista.idFutbolista)
            .AgregarParametro();

        BP.CrearParametro("unnombre")
            .SetTipoVarchar(30)
            .SetValor(futbolista.nombre)
            .AgregarParametro();

        BP.CrearParametro("unapellido")
            .SetTipoVarchar(25)
            .SetValor(futbolista.apellido)
            .AgregarParametro();

        BP.CrearParametro("unnacimiento")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
            .SetValor(futbolista.nacimiento)
            .AgregarParametro();

        BP.CrearParametro("unubiCampo")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(futbolista.ubiCampo.ubiCampo)
            .AgregarParametro();

        BP.CrearParametro("unvelocidad")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(futbolista.velocidad)
            .AgregarParametro();

        BP.CrearParametro("unremate")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(futbolista.remate)
            .AgregarParametro();

        BP.CrearParametro("unpase")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(futbolista.pase)
            .AgregarParametro();

        BP.CrearParametro("undefensa")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(futbolista.defensa)
            .AgregarParametro();

    }

    public void PostAltaFutbolista(Futbolista futbolista)
    {
        var paramidFutbolista = GetParametro("unidFutbolista");
        futbolista.idFutbolista = Convert.ToByte(paramidFutbolista.Value);
    }
}
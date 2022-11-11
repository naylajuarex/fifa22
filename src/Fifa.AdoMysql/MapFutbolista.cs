using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System.Data;
using Fifa.Core;

namespace Fifa.AdoMysql;
public class MapFutbolista : Mapeador<Futbolista>
{
    public MapFutbolista(AdoAGBD ado) : base(ado) => Tabla = "Futbolista";
    public override Futbolista ObjetoDesdeFila(DataRow fila)
            => new Futbolista()
            {
                idFutbolista = Convert.ToByte(fila["idFutbolista"]),
                ubiCampo = Convert.ToByte(fila["ubiCampo"]),
                nombre = fila["nombre"].ToString()!,
                apellido = fila["apellido"].ToString()!,
                nacimiento = Convert.ToDateTime(fila["nacimiento"]),
                velocidad = Convert.ToByte(fila["velocidad"]),
                remate = Convert.ToByte(fila["remate"]),
                pase = Convert.ToByte(fila["pase"]),
                defensa = Convert.ToByte(fila["defensa"]),
            };

    public void AltaFutbolista(Futbolista futbolista)
        => EjecutarComandoCon("AltaFutbolista", ConfigurarAltaFutbolista, PostAltaFutbolista, futbolista);

            public Futbolista FutbolistaPorId(Int16 id)
            => FiltrarPorPK("idFutbolista", id)!;

    public void ConfigurarAltaFutbolista(Futbolista futbolista)
    {
        SetComandoSP("AltaFutbolista");

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

        BP.CrearParametroSalida("unnacimiento")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
            .SetValor(futbolista.nacimiento)
            .AgregarParametro();

        BP.CrearParametroSalida("unubiCampo")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(futbolista.ubiCampo)
            .AgregarParametro();

        BP.CrearParametroSalida("unvelocidad")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(futbolista.velocidad)
            .AgregarParametro();

        BP.CrearParametroSalida("unremate")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(futbolista.remate)
            .AgregarParametro();

        BP.CrearParametroSalida("unpase")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(futbolista.pase)
            .AgregarParametro();

        BP.CrearParametroSalida("undefensa")
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
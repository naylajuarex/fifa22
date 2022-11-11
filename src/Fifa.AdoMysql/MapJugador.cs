using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System.Data;
using Fifa.Core;

namespace Fifa.AdoMysql;
public class MapJugador : Mapeador<Jugador>
{
    public MapJugador(AdoAGBD ado) : base(ado) => Tabla = "Jugador";
    public override Jugador ObjetoDesdeFila(DataRow fila)
            => new Jugador()
            {
                idJugador = Convert.ToUInt16(fila["idJugador"]),
                Nombre = fila["nombre"].ToString(),
                Apellido = fila["apellido"].ToString(),
                Usuario = fila["usuario"].ToString(),
                Contrasena = fila["contrasena"].ToString(),
                Moneda = Convert.ToUInt16(fila["moneda"]),
            };

    public void AltaJugador(Jugador jugador)
        => EjecutarComandoCon("altaJugador", ConfigurarAltaJugador, PostAltaJugador, jugador);

    public void ConfigurarAltaJugador(Jugador jugador)
    {
        SetComandoSP("altaJugador");

        BP.CrearParametroSalida("unidJugador")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(jugador.idJugador)
            .AgregarParametro();

        BP.CrearParametro("unnombre")
            .SetTipoVarchar(30)
            .SetValor(jugador.Nombre)
            .AgregarParametro();

        BP.CrearParametro("unapellido")
            .SetTipoVarchar(30)
            .SetValor(jugador.Apellido)
            .AgregarParametro();

        BP.CrearParametro("unusuario")
            .SetTipoVarchar(15)
            .SetValor(jugador.Usuario)
            .AgregarParametro();

        BP.CrearParametro("uncontrasena")
            .SetTipoChar(64)
            .SetValor(jugador.Contrasena)
            .AgregarParametro();

        BP.CrearParametro("unmoneda")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(jugador.Moneda)
            .AgregarParametro();

    }

    public void PostAltaJugador(Jugador jugador)
    {
        var paramIdJugador = GetParametro("unIdJugador");
        jugador.idJugador = Convert.ToByte(paramIdJugador.Value);
    }
}


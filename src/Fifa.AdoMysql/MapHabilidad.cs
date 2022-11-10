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
                idHabilidad = Convert.ToUInt16(fila["idHabilidad"]),
                Nombre = fila["nombre"].ToString(),
                Apellido = fila["apellido"].ToString(),
                Usuario = fila["usuario"].ToString(),
                Contrasena = fila["contraseña"].ToString(),
                Moneda = Convert.ToUInt16(fila["moneda"]),
            };

    public void AltaHabilidad(Habilidad habilidad)
        => EjecutarComandoCon("altaHabilidad", ConfigurarAltaHabilidad, PostAltaHabilidad, Habilidad);

    public void ConfigurarAltaHabilidad(Habilidad habilidad)
    {
        SetComandoSP("altaHabilidad");

        BP.CrearParametroSalida("unidHabilidad")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(Habilidad.idHabilidad)
            .AgregarParametro();

        BP.CrearParametro("unnombre")
            .SetTipoVarchar(30)
            .SetValor(Habilidad.Nombre)
            .AgregarParametro();

        BP.CrearParametro("unapellido")
            .SetTipoVarchar(30)
            .SetValor(Habilidad.Apellido)
            .AgregarParametro();

        BP.CrearParametro("unusuario")
            .SetTipoVarchar(15)
            .SetValor(Habilidad.Usuario)
            .AgregarParametro();

        BP.CrearParametro("uncontrasena")
            .SetTipoChar(64)
            .SetValor(Habilidad.Contrasena)
            .AgregarParametro();

        BP.CrearParametro("unmoneda")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(Habilidad.Moneda)
            .AgregarParametro();

    }

    public void PostAltaHabilidad(Habilidad Habilidad)
    {
        var paramIdHabilidad = GetParametro("unIdHabilidad");
        Habilidad.idHabilidad = Convert.ToByte(paramIdHabilidad.Value);
    }
}
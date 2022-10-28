using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System;
using System.Data;
using System.Collections.Generic;
using Fifa.Core;

namespace Fifa.AdoMysql;
public class MapFutbolista : Mapeador<Futbolista>
{
    public MapFutbolista(AdoAGBD ado) : base(ado)
    {
        Tabla = "Futbolista";
    }
    public override Futbolista ObjetoDesdeFila(DataRow fila)
            => new Futbolista()
            {
                idFutbolista = Convert.ToUInt16(fila["idFutbolista"]),
                nombre = fila["nombre"].ToString(),
                //ubiCampo = Convert.ToByte(fila["ubiCampo"]), lpm
                apellido = fila["apellido"].ToString(),
                nacimiento =  Convert.ToDateTime(fila["nacimiento"])
                
            };


//FALTA MODIFICAR
public void AltaFutbolista(Futbolista futbolista)
    => EjecutarComandoCon("altaFutbolista", ConfigurarAltaFutbolista, PostAltaFutbolista, futbolista);

public void ConfigurarAltaFutbolista(Futbolista futbolista)
    {
        SetComandoSP("altaFutbolista");

        BP.CrearParametroSalida("unIdFutbolista")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
            .AgregarParametro();

        BP.CrearParametro("unFutbolista")
            .SetTipoVarchar(45)
            .SetValor(futbolista.Nombre)
            .AgregarParametro();
    }

    public void PostAlta(Futbolista futbolista)
    {
        var paramIdFutbolista = GetParametro("unIdFutbolista");
        futbolista.Id = Convert.ToByte(paramIdFutbolista.Value);
    }

    public Futbolista FutbolistaPorId(byte id)
    {
        SetComandoSP("FutbolistaPorId");

        BP.CrearParametro("unIdFutbolista")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
        .SetValor(id)
        .AgregarParametro();

        return ElementoDesdeSP();
    }
    public List<Futbolista> ObtenerFutbolistas() => ColeccionDesdeTabla();
}


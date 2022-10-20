using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System;
using System.Data;
using System.Collections.Generic;

namespace Fifa.AdoMysql;
public class MapFutbolista : Mapeador<Futbolista>
{
    public MapFutbolista(AdoAGBD ado) : base(ado)
    {
        tabla = "Futbolista";
    }
    public override Futbolista ObjetoDesdeFila(DataRow fila)
            => new Futbolista()
            {
                idFutbolista = Convert.Toushort(fila["idFutbolista"]),
                nombre = fila["Futbolista"].ToString()
            };

}

using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System.Data;
using Fifa.Core;

namespace Fifa.AdoMysql;
public class MapTransferencia : Mapeador<Transferencia>
{
    public MapTransferencia(AdoAGBD ado) : base(ado) => Tabla = "Transferencia";
    public override Transferencia ObjetoDesdeFila(DataRow fila)
            => new Transferencia()
            {

                fyhPublicado = Convert.ToDateTime(fila["fyhPublicado"]),
                fyhTerminado = Convert.ToDateTime(fila["fyhTerminado"]),
                idVendedor = Convert.ToUInt16(fila["idVendedor"]),
                idComprador = Convert.ToUInt16(fila["idComprador"]),
                precio = Convert.ToUInt16(fila["precio"]),
                idFutbolista = Convert.ToByte(fila["idFutbolista"]),
            };
}
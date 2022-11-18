using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System.Data;
using Fifa.Core;

namespace Fifa.AdoMysql;
public class MapTransferencia : Mapeador<Transferencia>
{   
    public MapJugador MapJugador {get; set;}
    public MapFutbolista MapFutbolista {get; set;}
    public MapTransferencia(AdoAGBD ado) : base(ado) => Tabla = "Transferencia";

    public MapTransferencia (MapJugador mapJugador) : this(mapJugador.AdoAGBD)
    {
        MapJugador = mapJugador;
    }

     public MapTransferencia (MapFutbolista mapFutbolista) : this(mapFutbolista.AdoAGBD)
    {
        MapFutbolista = mapFutbolista;
    }


    public override Transferencia ObjetoDesdeFila(DataRow fila)
            => new Transferencia()
            {

                fyhPublicado = Convert.ToDateTime(fila["fyhPublicado"]),
                fyhTerminado = Convert.ToDateTime(fila["fyhTerminado"]),
                idVendedor = Convert.ToUInt16(fila["idVendedor"]),
                idComprador = MapJugador.JugadorPorId(Convert.ToInt16(fila["idComprador"])),
                precio = Convert.ToUInt16(fila["precio"]),
                idFutbolista = MapFutbolista.FutbolistaPorId(Convert.ToByte(fila["idFutbolista"])),
            };
}
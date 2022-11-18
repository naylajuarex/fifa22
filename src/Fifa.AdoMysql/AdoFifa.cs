using et12.edu.ar.AGBD.Ado;
using Fifa.Core;
using Fifa22.Core.Ado;

namespace Fifa.AdoMysql;
public class AdoFifa : IAdo
{
    public AdoAGBD AdoAGBD { get; set; }
    public MapJugador MapJugador { get; set; }
    public MapHabilidad MapHabilidad { get; set; }
    public MapFutbolistaHabilidad MapFutbolistaHabilidad { get; set; }
    public MapFutbolista MapFutbolista { get; set; }
    public MapPosesion MapPosesion { get; set; }
    public MapPosicion MapPosicion { get; set; }
    public MapTransferencia MapTransferencia { get; set; }
    public AdoFifa(AdoAGBD adoAGBD)
    {
        AdoAGBD = adoAGBD;
        MapJugador = new MapJugador(adoAGBD);
        MapHabilidad = new MapHabilidad(adoAGBD);
        MapPosicion = new MapPosicion(adoAGBD);
        MapFutbolistaHabilidad = new MapFutbolistaHabilidad(adoAGBD);
        MapFutbolista = new MapFutbolista(adoAGBD);
        MapPosesion = new MapPosesion(adoAGBD);
        MapTransferencia = new MapTransferencia(MapJugador, MapJugador, MapFutbolista);
    }

    public void AltaJugador(Jugador jugador)
        => MapJugador.AltaJugador(jugador);

    public List<Jugador> ObtenerJugador()
        => MapJugador.ColeccionDesdeTabla();

    public Jugador ObtenerJugadorPorId(Int16 id)
        => MapJugador.FiltrarPorPK("idJugador", id)!;

    public void AltaHabilidad(Habilidad habilidad)
        => MapHabilidad.AltaHabilidad(habilidad);

    public List<Habilidad> ObtenerHabilidad()
        => MapHabilidad.ColeccionDesdeTabla();

    public void AltaPosicion(Posicion posicion)
        => MapPosicion.AltaPosicion(posicion);

    public List<Posicion> ObtenerPosicion()
        => MapPosicion.ColeccionDesdeTabla();

    public void AltaFutbolistahabilidad(FutbolistaHabilidad futbolistaHabilidad)
        => MapFutbolistaHabilidad.ColeccionDesdeTabla();

    public List<FutbolistaHabilidad> ObtenerFutbolistahabilidad()
        => MapFutbolistaHabilidad.ColeccionDesdeTabla();

    public void AltaFutbolista(Futbolista futbolista)
        => MapFutbolista.ColeccionDesdeTabla();

    public List<Futbolista> ObtenerFutbolista()
        => MapFutbolista.ColeccionDesdeTabla();
    public Futbolista ObtenerFutbolistaPorId(Int16 id)
        => MapFutbolista.FiltrarPorPK("idFutbolista", id)!;

    public void AltaPosesion(Posesion posesion)
        => MapPosesion.ColeccionDesdeTabla();
    public List<Posesion> ObtenerPosesion()
        => MapPosesion.ColeccionDesdeTabla();
    public Posesion ObtenerPosesionPorId(byte id)
        => MapPosesion.FiltrarPorPK("idFutbolista", id)!;
    public void AltaTransferencia(Transferencia transferencia)
    => MapTransferencia.ColeccionDesdeTabla();
    public List<Transferencia> ObtenerTransferencia()
        => MapTransferencia.ColeccionDesdeTabla();

}
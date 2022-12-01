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
        MapFutbolista = new MapFutbolista(MapPosicion);
        MapFutbolistaHabilidad = new MapFutbolistaHabilidad(MapHabilidad,MapFutbolista);
        MapPosesion = new MapPosesion(MapJugador,MapFutbolista);
        MapTransferencia = new MapTransferencia(MapJugador, MapJugador, MapFutbolista);
    }

    public void AltaJugador(Jugador jugador)
        => MapJugador.AltaJugador(jugador);

    public List<Jugador> ObtenerJugador()
        => MapJugador.ColeccionDesdeTabla();

    public Jugador ObtenerJugadorPorId(byte id)
        => MapJugador.FiltrarPorPK("idJugador", id)!;

    public void AltaHabilidad(Habilidad habilidad)
        => MapHabilidad.AltaHabilidad(habilidad);

    public List<Habilidad> ObtenerHabilidad()
        => MapHabilidad.ColeccionDesdeTabla();
    public Habilidad ObtenerHabilidadPorId(byte idHabilidad)
        => MapHabilidad.FiltrarPorPK("idHabilidad", idHabilidad)!;

    public void AltaPosicion(Posicion posicion)
        => MapPosicion.AltaPosicion(posicion);

    public List<Posicion> ObtenerPosicion()
        => MapPosicion.ColeccionDesdeTabla();

    public Posicion ObtenerPosicionPorId(byte ubiCampo)
        => MapPosicion.FiltrarPorPK("ubiCampo", ubiCampo)!;

    public void AltaFutbolistahabilidad(FutbolistaHabilidad futbolistaHabilidad)
        => MapFutbolistaHabilidad.AltaFutbolistaHabilidad(futbolistaHabilidad);

    public List<FutbolistaHabilidad> ObtenerFutbolistahabilidad()
        => MapFutbolistaHabilidad.ColeccionDesdeTabla();

    public void AltaFutbolista(Futbolista futbolista)
        => MapFutbolista.AltaFutbolista(futbolista);

    public List<Futbolista> ObtenerFutbolista()
        => MapFutbolista.ColeccionDesdeTabla();
    public Futbolista ObtenerFutbolistaPorId(byte id)
        => MapFutbolista.FiltrarPorPK("idFutbolista", id)!;

    public void AltaPosesion(Posesion posesion)
        => MapPosesion.AltaPosesion(posesion);
    public List<Posesion> ObtenerPosesion()
        => MapPosesion.ColeccionDesdeTabla();
    public Posesion ObtenerPosesionPorId(byte id)
        => MapPosesion.FiltrarPorPK("idFutbolista", id)!;
    public void AltaTransferencia(Transferencia transferencia)
    => MapTransferencia.AltaTransferencia(transferencia);
    public List<Transferencia> ObtenerTransferencia()
        => MapTransferencia.ColeccionDesdeTabla();

}
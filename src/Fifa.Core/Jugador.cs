
namespace Fifa.Core;

public class Jugador
{
    public uint idJugador { get; set; }
    public string nombre { get; set; }
    public string apellido { get; set; }
    public string usuario { get; set; }
    public string contrasena { get; set; }
    public uint moneda { get; set; }

    public Jugador(string nombre, string apellido, string usuario, string contrasena)
    {
        this.nombre = nombre;
        this.apellido = apellido;
        this.usuario = usuario;
        this.contrasena = contrasena;
    }


}


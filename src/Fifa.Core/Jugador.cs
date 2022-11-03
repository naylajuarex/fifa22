
namespace Fifa.Core;

public class Jugador
{
    public uint idJugador { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Usuario { get; set; }
    public string Contrasena { get; set; }
    public uint Moneda { get; set; }
    public Jugador()
    {
    }

    public Jugador(string nombre, string apellido, string usuario, string contrasena)
    {
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.Usuario = usuario;
        this.Contrasena = contrasena;
    }

}


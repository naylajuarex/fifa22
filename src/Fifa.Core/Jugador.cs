
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

    public Jugador(string Nombre, string Apellido, string Usuario, string Contrasena, uint Moneda)
    {
        this.Nombre = Nombre;
        this.Apellido = Apellido;
        this.Usuario = Usuario;
        this.Contrasena = Contrasena;
        this.Moneda = Moneda;
    }

}


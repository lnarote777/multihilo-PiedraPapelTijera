namespace multihilo1;

public class Jugador
{
    private static readonly string[] _opciones = { "Piedra", "Papel", "Tijera" };
    private static readonly ThreadLocal<Random> _random = new(() => new Random());

    public string Nombre { get; }
    public string Eleccion { get; private set; }

    public Jugador(string nombre)
    {
        Nombre = nombre;
        Eleccion = "";
    }

    public void Jugar()
    {
        int opcion = _random.Value.Next(_opciones.Length);
        Eleccion = _opciones[opcion];
        Console.WriteLine($"{Nombre} elige: {Eleccion}");
    }
}
namespace multihilo1;
    
class Program
{
    private static string[] _opciones = { "Piedra", "Papel", "Tijera" };
    private static string _eleccionJ1 = "";
    private static string _eleccionJ2 = "";
    private static Random _random = new Random();

    static void Jugador1()
    {
        int opcion = _random.Next(_opciones.Length);
        
        _eleccionJ1 = _opciones[opcion];
        Console.WriteLine($"J1 elige: {_eleccionJ1}");
    }
    
    static void Jugador2()
    {
        int opcion = _random.Next(_opciones.Length);
        
        _eleccionJ2 = _opciones[opcion];
        Console.WriteLine($"J2 elige: {_eleccionJ2}");
    }

    static void DeterminarGanador()
    {
        if (_eleccionJ1 == _eleccionJ2)
        {
            Console.Write("Empate!!");
        }else if ((_eleccionJ1 == "Piedra" && _eleccionJ2 == "Tijera") ||
                  (_eleccionJ1 == "Papel" && _eleccionJ2 == "Piedra") ||
                  (_eleccionJ1 == "Tijera" && _eleccionJ2 == "Papel"))
        {
            Console.Write("Jugador 1 gana!!");
        }
        else
        {
            Console.Write("Jugador 2 gana!!");
        }
    }

    static void Main()
    {
        Console.WriteLine("¡Comienza la partida!");
        
        Thread j1 = new Thread(Jugador1);
        Thread j2 = new Thread(Jugador2);
        
        j1.Start();
        j2.Start();
        
        j1.Join();
        j2.Join();
        
        DeterminarGanador();
    }
} 
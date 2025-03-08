namespace multihilo1;
    
class Program
{
    static Jugador DeterminarGanador(Jugador j1, Jugador j2)
    {
        if (j1.Eleccion == j2.Eleccion)
        {
            return j1;
        }else if ((j1.Eleccion == "Piedra" && j2.Eleccion == "Tijera") ||
                  (j1.Eleccion == "Papel" && j2.Eleccion == "Piedra") ||
                  (j1.Eleccion == "Tijera" && j2.Eleccion == "Papel"))
        {
            return j1;
        }
        else
        {
            return j2;
        }
    }

    static void Main()
    {
        Console.WriteLine("¡Comienza la partida!");
        
        Jugador[] jugadores = new Jugador[16];
        Thread[] hilos = new Thread[16];

        for (int i = 0; i < 16; i++)
        {
            jugadores[i] = new Jugador($"Jugador {i + 1}");
            hilos[i] = new Thread(jugadores[i].Jugar);
            hilos[i].Start();
        }
        
        foreach (var hilo in hilos)
        {
            hilo.Join();
        }
        
        int jugadoresRestantes = 16;
        while (jugadoresRestantes > 1)
        {
            Console.WriteLine("\n--- Nueva Ronda ---");

            for (int i = 0; i < jugadoresRestantes / 2; i++)
            {
                jugadores[i] = DeterminarGanador(jugadores[i], jugadores[jugadoresRestantes - 1 - i]);
                Console.WriteLine($"Ganador entre {jugadores[i].Nombre} y {jugadores[jugadoresRestantes - 1 - i].Nombre}: {jugadores[i].Nombre} ({jugadores[i].Eleccion})");
            }

            jugadoresRestantes /= 2;
        }

        Console.WriteLine($"\n¡El gran ganador es {jugadores[0].Nombre} con {jugadores[0].Eleccion}!");
    }
} 
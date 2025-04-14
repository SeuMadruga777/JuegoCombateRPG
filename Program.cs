using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoCombateRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Primeros personajes y sus equipos
            Barbaro barbaro = new Barbaro("Gronk", 50, 12, 9);
            Sacerdote sacerdote = new Sacerdote("Elias", 45, 10);
            Equipo hacha = new Equipo("Hacha Rústica", 5, 0);
            Equipo tunica = new Equipo("Túnica Bendita", 0, 3);

            barbaro.AsignarEquipo(hacha);
            sacerdote.AsignarEquipo(tunica);

            Console.WriteLine("\n⚔️ Primera Batalla: Gronk vs Elias ⚔️\n");

            // Primera batalla
            Personaje ganador = Batalla(barbaro, sacerdote);

            if (ganador == null)
            {
                Console.WriteLine("\nNo hubo ganador en la primera batalla. Fin del juego.");
                return;
            }

            // 🚨 Segunda parte: crear personaje personalizado
            Console.WriteLine("\n🛡️ Crea tu personaje personalizado (Campesino)\n");

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Vida: ");
            int vida = int.Parse(Console.ReadLine());

            Console.Write("Ataque: ");
            int ataque = int.Parse(Console.ReadLine());

            Console.Write("Nombre del equipo: ");
            string nombreEquipo = Console.ReadLine();

            Console.Write("Modificador de ataque del equipo: ");
            int modAtk = int.Parse(Console.ReadLine());

            Console.Write("Modificador de defensa del equipo: ");
            int modDef = int.Parse(Console.ReadLine());

            Equipo equipoPersonalizado = new Equipo(nombreEquipo, modAtk, modDef);
            Campesino nuevoCampesino = new Campesino(nombre, vida, ataque);
            nuevoCampesino.AsignarEquipo(equipoPersonalizado);

            Console.WriteLine($"\n⚔️ Segunda Batalla: {ganador.GetNombre()} vs {nuevoCampesino.GetNombre()} ⚔️\n");

            Personaje finalista = Batalla(ganador, nuevoCampesino);

            if (finalista != null)
            {
                Console.WriteLine($"\n🏆 {finalista.GetNombre()} ha ganado la batalla final.");
            }
            else
            {
                Console.WriteLine("\n❌ Ambos han caído en la segunda batalla.");
            }
            Console.ReadKey(); // <- Espera a que el usuario presione una tecla
        }

        // 🧠 Método para batallar entre dos personajes
        public static Personaje Batalla(Personaje p1, Personaje p2)
        {
            while (p1.GetVida() > 0 && p2.GetVida() > 0)
            {
                p1.Atacar(p2);
                if (p2.GetVida() <= 0) break;

                p2.Atacar(p1);
                if (p1.GetVida() <= 0) break;

                Console.WriteLine("\n--- Siguiente ronda ---\n");
            }

            if (p1.GetVida() > 0) return p1;
            else if (p2.GetVida() > 0) return p2;
            else return null;
        }
    }
}

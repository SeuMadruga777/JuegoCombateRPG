using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoCombateRPG
{
    internal class Campesino : Personaje
    {
        private bool esHombreLobo = false;

        public Campesino(string nombre, int vida, int ataque) : base(nombre, vida, ataque)
        {
        }

        public override void Atacar(Personaje objetivo)
        {
            // Si ya es Hombre Lobo
            if (esHombreLobo)
            {
                Console.WriteLine($"{GetNombre()} ataca con la ferocidad de un lobo.");
                objetivo.RecibirDanio((int)(GetAtaque() * 1.5));
            }
            else
            {
                // Ataca normalmente
                Console.WriteLine($"{GetNombre()} ataca a {objetivo.GetNombre()}.");
                objetivo.RecibirDanio(GetAtaque());

                // Probabilidad de transformación (30%)
                Random random = new Random();
                int probabilidad = random.Next(1, 101); // entre 1 y 100

                if (probabilidad <= 30)
                {
                    esHombreLobo = true;
                    Console.WriteLine($"¡{GetNombre()} se transforma en Hombre Lobo! +50% de daño.");
                    // No es necesario cambiar el ataque base, simplemente aplicamos el +50% en cada ataque futuro
                }
            }
        }
    }
}

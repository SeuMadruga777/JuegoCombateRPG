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
            string armaUsada = equipo != null ? $" usando {equipo.getNombre()}" : "";

            if (esHombreLobo)
            {
                Console.WriteLine($"{GetNombre()} ataca a {objetivo.GetNombre()}{armaUsada} con la ferocidad de un lobo.");

                objetivo.RecibirDanio((int)(GetAtaque() * 1.5));
            }
            else
            {

                Console.WriteLine($"{GetNombre()} ataca a {objetivo.GetNombre()}{armaUsada}.");

                objetivo.RecibirDanio(GetAtaque());

                
                Random random = new Random();
                int probabilidad = random.Next(1, 101); 

                if (probabilidad <= 30)
                {
                    esHombreLobo = true;
                    Console.WriteLine($"¡{GetNombre()} se transforma en Hombre Lobo! +50% de daño.");
                    
                }
            }
        }
    }
}

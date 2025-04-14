using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoCombateRPG
{
    public class Sacerdote : Personaje
    {
        public Sacerdote(string nombre, int vida, int ataque)
       : base(nombre, vida, ataque)
        {
        }

        public override void RecibirDanio(int danio)
        {
            
            int danioReducido = danio / 2;
            base.RecibirDanio(danioReducido);
            Console.WriteLine($"{GetNombre()} recibe solo {danioReducido} de daño gracias a su fe.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoCombateRPG
{
    public class Barbaro : Personaje
    {
        private int furia;

        public Barbaro(string nombre, int vida, int ataque, int furia)
            : base(nombre, vida, ataque)
        {
            this.furia = furia;
        }

        public override void Atacar(Personaje objetivo)
        {
            
            int danio = GetAtaque() + this.furia;
            objetivo.RecibirDanio(danio);
            Console.WriteLine($"{GetNombre()} ataca con furia a {objetivo.GetNombre()} causando {danio} de daño.");

        }
}
}


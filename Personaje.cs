using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoCombateRPG
{
    public class Personaje
    {
        
        protected string nombre;
        protected int vida;
        protected int ataque;
        protected Equipo equipo; 

        
        public Personaje(string nombre, int vida, int ataque)
        {
            this.nombre = nombre;
            this.vida = vida;
            this.ataque = ataque;
            this.equipo = null; 
        }

        
        public string GetNombre() { return nombre; }
        public int GetVida() { return vida; }

        public virtual int GetAtaque()
        {
            if (equipo != null)
            {
                return ataque + equipo.getModificadorAtaque();
            }
            return ataque;
        }

        
        public void AsignarEquipo(Equipo nuevoEquipo)
        {
            equipo = nuevoEquipo;
            Console.WriteLine($"{nombre} ha equipado {equipo.getNombre()}.");
        }

        
        public virtual void Atacar(Personaje objetivo)
        {
            int danio = GetAtaque();

            string armaUsada = equipo != null ? $" usando {equipo.getNombre()}" : "";

            Console.WriteLine($"{nombre} ataca a {objetivo.GetNombre()}{armaUsada} con {danio} de daño.");
            objetivo.RecibirDanio(danio);
        }

       
        public virtual void RecibirDanio(int danio)
        {
            int danioReducido = danio;

            if (equipo != null)
            {
                danioReducido -= equipo.getModificadorDefensa();
            }

            if (danioReducido < 0) danioReducido = 0;

            vida -= danioReducido;
            if (vida < 0) vida = 0;

            Console.WriteLine($"{nombre} recibió {danioReducido} de daño. Vida restante: {vida}");
        }
    }
}

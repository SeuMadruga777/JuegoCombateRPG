using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoCombateRPG
{
    public class Personaje
    {
        // Atributos protegidos
        protected string nombre;
        protected int vida;
        protected int ataque;
        protected Equipo equipo; // Ahora es parte del personaje

        // Constructor
        public Personaje(string nombre, int vida, int ataque)
        {
            this.nombre = nombre;
            this.vida = vida;
            this.ataque = ataque;
            this.equipo = null; // Por defecto sin equipo
        }

        // Métodos GET
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

        // Método para asignar equipo
        public void AsignarEquipo(Equipo nuevoEquipo)
        {
            equipo = nuevoEquipo;
            Console.WriteLine($"{nombre} ha equipado {equipo.getNombre()}.");
        }

        // Método Atacar
        public virtual void Atacar(Personaje objetivo)
        {
            int danio = GetAtaque();
            Console.WriteLine($"{nombre} ataca a {objetivo.GetNombre()} con {danio} de daño.");
            objetivo.RecibirDanio(danio);
        }

        // Método Recibir Daño
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

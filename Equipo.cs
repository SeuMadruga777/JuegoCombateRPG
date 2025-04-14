using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoCombateRPG
{
    public class Equipo
    {
        private string nombre;
        private int modificadorAtaque;
        private int modificadorDefensa;

        public Equipo(string nombre, int modificadorAtaque, int modificadorDefensa)
        {
            this.nombre = nombre;
            this.modificadorAtaque = modificadorAtaque;
            this.modificadorDefensa = modificadorDefensa;
        }

        public string getNombre()
        {
            return nombre;
        }

        public int getModificadorAtaque()
        {
            return modificadorAtaque;
        }

        public int getModificadorDefensa()
        {
            return modificadorDefensa;
        }
    }
}

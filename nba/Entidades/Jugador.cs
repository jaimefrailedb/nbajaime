using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nba.Entidades
{
    public class Jugador
    {
        int idJugador;
        string nombre;
        int altura;
        double peso;
        int dorsal;
        int equipo_id;
        int posicion_id;

        public Jugador()
        {
            this.idJugador = -1;
            this.nombre = string.Empty;
            this.altura = -1;
            this.peso = 0;
            this.dorsal = -1;
            this.equipo_id = -1;
            this.posicion_id = -1;
        }
        public Jugador(int idJugador, string nombre, int altura, double peso, int dorsal, int equipo_id, int posicion_id)
        {
            this.idJugador = idJugador;
            this.nombre = nombre;
            this.altura = altura;
            this.peso = peso;
            this.dorsal = dorsal;
            this.equipo_id = equipo_id;
            this.posicion_id = posicion_id;
        }

        public int IdJugador
        {
            get
            {
                return idJugador;
            }

            set
            {
                idJugador = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public int Altura
        {
            get
            {
                return altura;
            }

            set
            {
                altura = value;
            }
        }

        public double Peso
        {
            get
            {
                return peso;
            }

            set
            {
                peso = value;
            }
        }

        public int Dorsal
        {
            get
            {
                return dorsal;
            }

            set
            {
                dorsal = value;
            }
        }

        public int Equipo_id
        {
            get
            {
                return equipo_id;
            }

            set
            {
                equipo_id = value;
            }
        }

        public int Posicion_id
        {
            get
            {
                return posicion_id;
            }

            set
            {
                posicion_id = value;
            }
        }
    }
}

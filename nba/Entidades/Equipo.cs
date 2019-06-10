using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nba.Entidades
{
    public class Equipo
    {
        int idEquipo;
        string nombre;
        string colores;
        int anyoFundacion;

        public Equipo()
        {
            this.idEquipo = -1;
            this.nombre = string.Empty;
            this.colores = string.Empty;
            this.anyoFundacion = -1;
        }
        public Equipo(int idEquipo, string nombre, string colores, int anyoFundacion)
        {
            this.idEquipo = idEquipo;
            this.nombre = nombre;
            this.colores = colores;
            this.anyoFundacion = anyoFundacion;
        }

        public int IdEquipo
        {
            get
            {
                return idEquipo;
            }

            set
            {
                idEquipo = value;
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

        public string Colores
        {
            get
            {
                return colores;
            }

            set
            {
                colores = value;
            }
        }

        public int AnyoFundacion
        {
            get
            {
                return anyoFundacion;
            }

            set
            {
                anyoFundacion = value;
            }
        }
    }
}

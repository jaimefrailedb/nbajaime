using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nba.Entidades
{
    public class Posicion
    {
        int idPosicion;
        string descripcion;

        public Posicion()
        {
            this.idPosicion = -1;
            this.descripcion = string.Empty;
        }
        public Posicion(int idPosicion, string descripcion)
        {
            this.idPosicion = idPosicion;
            this.descripcion = descripcion;
        }

        public int IdPosicion
        {
            get
            {
                return idPosicion;
            }

            set
            {
                idPosicion = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }
    }
}

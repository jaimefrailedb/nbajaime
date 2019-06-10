using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nba.Entidades
{
    public class Acceso
    {
        int idAcceso;
        string descripcion;

        public Acceso()
        {
            this.idAcceso = -1;
            this.descripcion = string.Empty;
        }
        public Acceso(int idAcceso, string descripcion)
        {
            this.idAcceso = idAcceso;
            this.descripcion = descripcion;
        }

        public int IdAcceso
        {
            get
            {
                return idAcceso;
            }

            set
            {
                idAcceso = value;
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

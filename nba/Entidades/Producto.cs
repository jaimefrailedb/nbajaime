using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nba.Entidades
{
    public class Producto
    {
        int idProducto;
        string nombre;
        string descripcion;
        int cantidad;
        double precio;
        int equipo_id;

        public Producto()
        {
            this.idProducto = -1;
            this.nombre = string.Empty;
            this.descripcion = string.Empty;
            this.cantidad = -1;
            this.precio = 0;
            this.equipo_id = -1;
        }
        public Producto(int idProducto, string nombre, string descripcion, int cantidad, double precio, int equipo_id)
        {
            this.idProducto = idProducto;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.cantidad = cantidad;
            this.precio = precio;
            this.equipo_id = equipo_id;
        }

        public int IdProducto
        {
            get
            {
                return idProducto;
            }

            set
            {
                idProducto = value;
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

        public int Cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
            }
        }

        public double Precio
        {
            get
            {
                return precio;
            }

            set
            {
                precio = value;
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
    }
}

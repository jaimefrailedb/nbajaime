using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nba.Entidades
{
    public class Compra
    {
        int idCompra;
        int producto_id;
        int usuario_id;
        int cantidad;
        DateTime fecha;

        public Compra()
        {
            this.idCompra = -1;
            this.producto_id = -1;
            this.usuario_id = -1;
            this.cantidad = -1;
            this.fecha = DateTime.Today;
        }

        public Compra(int idCompra, int producto_id, int usuario_id, int cantidad, DateTime fecha)
        {
            this.idCompra = idCompra;
            this.producto_id = producto_id;
            this.usuario_id = usuario_id;
            this.cantidad = cantidad;
            this.fecha = fecha;
        }

        public int IdCompra
        {
            get
            {
                return idCompra;
            }

            set
            {
                idCompra = value;
            }
        }

        public int Producto_id
        {
            get
            {
                return producto_id;
            }

            set
            {
                producto_id = value;
            }
        }

        public int Usuario_id
        {
            get
            {
                return usuario_id;
            }

            set
            {
                usuario_id = value;
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

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }
    }
}

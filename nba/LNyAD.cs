

using nba.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nba.Entidades;

namespace nba
{
    public class LNyAD
    {
        static usuariosTableAdapter usuariosAdapter = new usuariosTableAdapter();
        static DataSet1.usuariosDataTable usuariosTabla = new DataSet1.usuariosDataTable();

        

        static accesosTableAdapter accesosAdapter = new accesosTableAdapter();

        

        static DataSet1.accesosDataTable accesosTabla = new DataSet1.accesosDataTable();

        

        static productosTableAdapter productosAdapter = new productosTableAdapter();

        

        static DataSet1.productosDataTable productosTabla = new DataSet1.productosDataTable();



        static comprasTableAdapter comprasAdapter = new comprasTableAdapter();

        

        static DataSet1.comprasDataTable comprasTabla = new DataSet1.comprasDataTable();

        static equiposTableAdapter equiposAdapter = new equiposTableAdapter();
        static DataSet1.equiposDataTable equiposTabla = new DataSet1.equiposDataTable();

        

        static jugadoresTableAdapter jugadoresAdapter = new jugadoresTableAdapter();

        

        static DataSet1.jugadoresDataTable jugadoresTabla = new DataSet1.jugadoresDataTable();

        

        static posicionesTableAdapter posicionesAdapter=new posicionesTableAdapter();

        

        static DataSet1.posicionesDataTable posicionesTabla = new DataSet1.posicionesDataTable();







        //USUARIOS

        public static Usuario DevuelveDatosUsuarioConMail(string text)
        {
            usuariosTabla = usuariosAdapter.GetUsuarioPorMail(text);

            Usuario usu = new Usuario(usuariosTabla[0].idUsuario, usuariosTabla[0].nombre, usuariosTabla[0].alias, usuariosTabla[0].login, usuariosTabla[0].password, usuariosTabla[0].movil, usuariosTabla[0].mail, usuariosTabla[0].acceso);

            return usu;
        }

        

        public static Usuario DevuelveUsuarioLogado(string text1, string text2)
        {
            usuariosTabla = usuariosAdapter.GetAlumnoLogado(text1, text2);

            Usuario usu = new Usuario(usuariosTabla[0].idUsuario, usuariosTabla[0].nombre, usuariosTabla[0].alias, usuariosTabla[0].login, usuariosTabla[0].password, usuariosTabla[0].movil, usuariosTabla[0].mail, usuariosTabla[0].acceso);

            return usu;
        }

        

        public static void ModificaUsuario(Usuario usu)
        {
            DataSet1.usuariosRow regUsuario = usuariosTabla.FindByidUsuario(usu.IdUsuario);

            regUsuario.nombre = usu.Nombre;
            regUsuario.alias = usu.Alias;
            regUsuario.login = usu.Login;
            regUsuario.password = usu.Password;
            regUsuario.movil = usu.Movil;
            regUsuario.mail = usu.Mail;
            regUsuario.acceso = usu.Acceso;

            usuariosAdapter.Update(regUsuario);
            usuariosTabla.AcceptChanges();
        }

        internal static bool UsuarioTieneCompras(int idUsuario)
        {
            return (comprasAdapter.ExisteUsuarioConCompras(idUsuario) > 0);
        }

        public static bool ExistenMasAdministradores()
        {
            return (usuariosAdapter.GetNumAdministradores() > 1);
        }

        public static void AddUsuario(Usuario usu)
        {
            DataSet1.usuariosRow regUsuario = usuariosTabla.NewusuariosRow();

            regUsuario.nombre = usu.Nombre;
            regUsuario.alias = usu.Alias;
            regUsuario.login = usu.Login;
            regUsuario.password = usu.Password;
            regUsuario.movil = usu.Movil;
            regUsuario.mail = usu.Mail;
            regUsuario.acceso = usu.Acceso;

            usuariosTabla.AddusuariosRow(regUsuario);

            usuariosAdapter.Update(regUsuario);
            usuariosTabla.AcceptChanges();
        }

        

        public static bool LoginCorrecto(string text1, string text2)
        {
            return (usuariosAdapter.ExisteLoginConAcceso(text1, text2) == 1);
        }

        

        public static bool ExisteAlias(string text)
        {
            return (usuariosAdapter.ExisteAlias(text) == 1);
        }

        

        public static bool LoginDeshabilitado(string text1, string text2)
        {
            return (usuariosAdapter.ExisteLoginDeshabilitado(text1, text2) == 1);
        }

        public static Usuario DevuelveUsuario(int idUsuario)
        {
            DataSet1.usuariosRow regUsuario = usuariosTabla.FindByidUsuario(idUsuario);

            Usuario usu = new Usuario(idUsuario, regUsuario.nombre, regUsuario.alias, regUsuario.login, regUsuario.password, regUsuario.movil, regUsuario.mail, regUsuario.acceso);
            return usu;
        }

        

        public static bool ExisteLogin(string text)
        {
            return (usuariosAdapter.ExisteLogin(text) == 1);
        }

        

        public static bool ExisteNombre(string text)
        {
            return (usuariosAdapter.ExisteNombreUsuario(text) == 1);
        }

        public static bool ExisteMovil(string text)
        {
            return (usuariosAdapter.ExisteMovil(text) == 1);
        }

        public static bool ExisteMail(string text)
        {
            return (usuariosAdapter.ExisteMail(text) == 1);
        }

        public static List<Acceso> ListaAccesos()
        {
            Acceso acceso;
            List<Acceso> lista = new List<Acceso>();

            accesosTabla = accesosAdapter.GetData();

            foreach(DataSet1.accesosRow regAcceso in accesosTabla)
            {
                acceso = new Acceso(regAcceso.idAcceso, regAcceso.descripcion);
                lista.Add(acceso);
            }

            return lista;
        }

        public static List<Usuario> listaUsuarios()
        {
            Usuario usuario;
            List<Usuario> lista = new List<Usuario>();

            usuariosTabla = usuariosAdapter.GetData();

            foreach(DataSet1.usuariosRow regUsuario in usuariosTabla)
            {
                usuario = new Usuario(regUsuario.idUsuario, regUsuario.nombre, regUsuario.alias, regUsuario.login, regUsuario.password, regUsuario.movil, regUsuario.mail, regUsuario.acceso);
                lista.Add(usuario);
            }
            return lista;
        }



        public static DataSet1.usuariosDataTable TablaAccesos(int idAcceso)
        {
            if (idAcceso == 0)
                usuariosTabla = usuariosAdapter.GetUsuariosConAliasCategoria();
            else
                usuariosTabla = usuariosAdapter.GetUsuariosPorAcceso(idAcceso);

            return usuariosTabla;
        }

        public static void EliminarUsuario(int idUsuario)
        {
            DataSet1.usuariosRow regUsuario = usuariosTabla.FindByidUsuario(idUsuario);

            regUsuario.Delete();
            usuariosAdapter.Update(usuariosTabla);
            usuariosTabla.AcceptChanges();
        }

        //EQUIPOS

        public static bool ExisteEquipo(string text)
        {
            return (equiposAdapter.GetExisteEquipo(text) > 0);
        }

        internal static bool EquipoTieneProductos(int idEquipo)
        {
            return (productosAdapter.ExisteEquipoConProductos(idEquipo) > 0);
        }

        public static DataSet1.equiposDataTable TablaEquiposPorAnyo(string anyo, string color)
        {
            if (anyo=="Seleccione un año" && color=="Seleccione un color")
            {
                equiposTabla = equiposAdapter.GetData();
            }else if(anyo != "Seleccione un año" && color == "Seleccione un color")
            {
                equiposTabla = equiposAdapter.GetEquiposPorAnyo(Convert.ToInt32(anyo));
            }else if (anyo == "Seleccione un año" && color != "Seleccione un color")
            {
                equiposTabla = equiposAdapter.GetEquiposPorColores(color);
            }else
            {
                equiposTabla = equiposAdapter.GetEquiposPorAnyoConColores(Convert.ToInt32(anyo), color);
            }

            return equiposTabla;
        }

        public static DataSet1.equiposDataTable TablaEquiposPorColores(string color, string anyo)
        {
            if (color=="Seleccione un color" && anyo=="Seleccione un año")
            {
                equiposTabla = equiposAdapter.GetData();
            }else if (color !="Seleccione un color" && anyo=="Seleccione un año")
            {
                equiposTabla = equiposAdapter.GetEquiposPorColores(color);
            }else if(color=="Seleccione un color" && anyo!="Seleccione un año")
            {
                equiposTabla = equiposAdapter.GetEquiposPorAnyo(Convert.ToInt32(anyo));
            }else
            {
                equiposTabla = equiposAdapter.GetEquiposPorColoresConAnyo(color, Convert.ToInt32(anyo));
            }

            return equiposTabla;
        }

        public static DataSet1.equiposDataTable TablaEquipos()
        {
            equiposTabla = equiposAdapter.GetData();

            return equiposTabla;
        }

        public static void EliminarEquipo(int idEquipo)
        {
            DataSet1.equiposRow regEquipo = equiposTabla.FindByidEquipo(idEquipo);

            regEquipo.Delete();
            equiposAdapter.Update(equiposTabla);
            equiposTabla.AcceptChanges();
        }

        public static Equipo DevuelveEquipo(int idEquipo)
        {
            DataSet1.equiposRow regEquipo = equiposTabla.FindByidEquipo(idEquipo);

            Equipo equipo = new Equipo(regEquipo.idEquipo, regEquipo.nombre, regEquipo.colores, regEquipo.anyoFundacion);

            return equipo;
        }

        public static void AddEquipo(Equipo equipo)
        {
            DataSet1.equiposRow regEquipo = equiposTabla.NewequiposRow();
            int lmax = Convert.ToInt32(equiposAdapter.IdMaxEquipo()) + 1;

            regEquipo.idEquipo = lmax;
            regEquipo.nombre = equipo.Nombre;
            regEquipo.colores = equipo.Colores;
            regEquipo.anyoFundacion = equipo.AnyoFundacion;

            equiposTabla.AddequiposRow(regEquipo);

            equiposAdapter.Update(regEquipo);
            equiposTabla.AcceptChanges();
        }

        public static void ModificaEquipo(Equipo equipo)
        {
            DataSet1.equiposRow regEquipo = equiposTabla.FindByidEquipo(equipo.IdEquipo);

            regEquipo.nombre = equipo.Nombre;
            regEquipo.colores = equipo.Colores;
            regEquipo.anyoFundacion = equipo.AnyoFundacion;

            equiposAdapter.Update(regEquipo);
            equiposTabla.AcceptChanges();
        }

        //JUGADORES

        public static bool ExisteDorsalEnEquipo(int dorsal, int equipo)
        {
            return (jugadoresAdapter.GetExisteDorsalEnEquipo(dorsal, equipo) > 0);
        }

        public static bool ExistenJugadoresEnEquipo(int idEquipo)
        {
            return (jugadoresAdapter.GetJugadoresEnEquipo(idEquipo) > 0);
        }

        public static List<Equipo> ListaEquipos()
        {
            Equipo equipo;

            List<Equipo> lista = new List<Equipo>();

            equiposTabla = equiposAdapter.GetData();

            foreach(DataSet1.equiposRow regEquipo in equiposTabla)
            {
                equipo = new Equipo(regEquipo.idEquipo, regEquipo.nombre, regEquipo.colores, regEquipo.anyoFundacion);
                lista.Add(equipo);
            }

            return lista;
        }

        public static List<Posicion> ListaPosiciones()
        {
            Posicion posicion;

            List<Posicion> lista = new List<Posicion>();

            posicionesTabla = posicionesAdapter.GetData();

            foreach(DataSet1.posicionesRow regPosicion in posicionesTabla)
            {
                posicion = new Posicion(regPosicion.idPosicion, regPosicion.descripcion);
                lista.Add(posicion);
            }

            return lista;
        }

        public static DataSet1.jugadoresDataTable TablaJugadores(int idEquipo, int idPosicion)
        {
            if (idEquipo == 0 && idPosicion == 0)
                jugadoresTabla = jugadoresAdapter.GetJugadoresConAliasEquipoYPosicion();
            else if (idEquipo != 0 && idPosicion == 0)
                jugadoresTabla = jugadoresAdapter.GetJugadoresPorIdEquipo(idEquipo);
            else if (idEquipo == 0 && idPosicion != 0)
                jugadoresTabla = jugadoresAdapter.GetJugadoresPorIdPosicion(idPosicion);
            else
                jugadoresTabla = jugadoresAdapter.GetJugadoresPorIdEquipoConIdPosicion(idEquipo, idPosicion);

            return jugadoresTabla;
        }

        public static object TablaJugadoresPosicion(int idPosicion, int idEquipo)
        {
            if (idPosicion == 0 && idEquipo == 0)
                jugadoresTabla = jugadoresAdapter.GetJugadoresConAliasEquipoYPosicion();
            else if (idPosicion != 0 && idEquipo == 0)
                jugadoresTabla = jugadoresAdapter.GetJugadoresPorIdPosicion(idPosicion);
            else if (idPosicion == 0 && idEquipo != 0)
                jugadoresTabla = jugadoresAdapter.GetJugadoresPorIdEquipo(idEquipo);
            else
                jugadoresTabla = jugadoresAdapter.GetJugadoresPorIdPosicionConIdEquipo(idPosicion, idEquipo);

            return jugadoresTabla;
        }

        public static void EliminarJugador(int idJugador)
        {
            DataSet1.jugadoresRow regJugador = jugadoresTabla.FindByidJugador(idJugador);

            regJugador.Delete();
            jugadoresAdapter.Update(regJugador);
            jugadoresTabla.AcceptChanges();
        }

        public static Jugador DevuelveJugador(int idJugador)
        {
            DataSet1.jugadoresRow regJugador=jugadoresTabla.FindByidJugador(idJugador);

            Jugador jugador = new Jugador(regJugador.idJugador, regJugador.nombre, regJugador.altura, regJugador.peso, regJugador.dorsal, regJugador.equipo_id, regJugador.posicion_id);

            return jugador;
        }

        public static void AddJugador(Jugador jug)
        {
            DataSet1.jugadoresRow regJugador = jugadoresTabla.NewjugadoresRow();

            regJugador.nombre = jug.Nombre;
            regJugador.altura = jug.Altura;
            regJugador.peso = jug.Peso;
            regJugador.dorsal = jug.Dorsal;
            regJugador.equipo_id = jug.Equipo_id;
            regJugador.posicion_id = jug.Posicion_id;

            jugadoresTabla.AddjugadoresRow(regJugador);

            jugadoresAdapter.Update(regJugador);
            jugadoresTabla.AcceptChanges();
        }

        public static void ModificaJugador(Jugador jug)
        {
            DataSet1.jugadoresRow regJugador = jugadoresTabla.FindByidJugador(jug.IdJugador);

            regJugador.nombre = jug.Nombre;
            regJugador.altura = jug.Altura;
            regJugador.peso = jug.Peso;
            regJugador.dorsal = jug.Dorsal;
            regJugador.equipo_id = jug.Equipo_id;
            regJugador.posicion_id = jug.Posicion_id;

            jugadoresAdapter.Update(regJugador);
            jugadoresTabla.AcceptChanges();
        }

        public static bool ExisteNombreJugador(string text)
        {
            return (jugadoresAdapter.ExisteNombreJugador(text) > 0);
        }

        //PRODUCTOS

        public static bool ExisteProductoEnCompra(int idProducto)
        {
            return (comprasAdapter.GetExisteProductoEnCompras(idProducto) > 0);
        }

        public static List<Producto> listaProductos()
        {
            Producto producto;

            List<Producto> lista = new List<Producto>();

            productosTabla = productosAdapter.GetData();

            foreach (DataSet1.productosRow regProducto in productosTabla)
            {
                producto = new Producto(regProducto.idProducto, regProducto.nombre, regProducto.descripcion, regProducto.cantidad, regProducto.precio,regProducto.equipo_id);
                lista.Add(producto);
            }

            return lista;
        }

        public static int ExistenciasProducto(int indice)
        {
            productosTabla = productosAdapter.GetExistenciasProducto(indice);

            int cantidad = Convert.ToInt32( productosTabla[0]);

            return cantidad;
        }

        public static DataSet1.productosDataTable TablaProductos(int idEquipo)
        {
            if (idEquipo == 0)
            {
                productosTabla = productosAdapter.GetProductosConAliasEquipo();
            }else
            {
                productosTabla = productosAdapter.GetProductosPorIdEquipo(idEquipo);
            }

            return productosTabla;
        }

        public static void EliminarProducto(int idProducto)
        {
            DataSet1.productosRow regProducto = productosTabla.FindByidProducto(idProducto);

            regProducto.Delete();
            productosAdapter.Update(productosTabla);
            productosTabla.AcceptChanges();

        }

        public static bool ExisteNombreProducto(string text)
        {
            return (productosAdapter.GetExisteNombreProducto(text) == 1);
        }

        public static bool ExisteDescripcionProducto(string text)
        {
            return (productosAdapter.GetExisteDescripcionProducto(text) == 1);
        }

        public static Producto DevuelveProducto(int idProducto)
        {
            DataSet1.productosRow regProducto = productosTabla.FindByidProducto(idProducto);

            Producto producto = new Producto(idProducto, regProducto.nombre, regProducto.descripcion, regProducto.cantidad, regProducto.precio, regProducto.equipo_id);

            return producto;
        }

        public static void AddProducto(Producto producto)
        {
            DataSet1.productosRow regProducto = productosTabla.NewproductosRow();

            regProducto.nombre = producto.Nombre;
            regProducto.descripcion = producto.Descripcion;
            regProducto.cantidad = producto.Cantidad;
            regProducto.precio = producto.Precio;
            regProducto.equipo_id = producto.Equipo_id;

            productosTabla.AddproductosRow(regProducto);
            productosAdapter.Update(regProducto);
            productosTabla.AcceptChanges();
        }

        public static void ModificaProducto(Producto producto)
        {
            DataSet1.productosRow regProducto = productosTabla.FindByidProducto(producto.IdProducto);

            regProducto.nombre = producto.Nombre;
            regProducto.descripcion = producto.Descripcion;
            regProducto.cantidad = producto.Cantidad;
            regProducto.precio = producto.Precio;
            regProducto.equipo_id = producto.Equipo_id;

            productosAdapter.Update(regProducto);
            productosTabla.AcceptChanges();
        }

        public static void ActualizaCantidadProducto(int cantidadProducto, int cantidadCompra, int idProducto)
        {
            DataSet1.productosRow regProducto = productosTabla.FindByidProducto(idProducto);

            regProducto.cantidad = cantidadProducto - cantidadCompra;

            productosAdapter.Update(regProducto);

            productosTabla.AcceptChanges();
        }

        //COMPRAS
        public static DataSet1.comprasDataTable TablaCompras(int idUsuario, int idProducto)
        {
            if (idUsuario == 0 && idProducto == 0)
            {
                comprasTabla = comprasAdapter.GetCompras();
            }
            else if(idUsuario!=0 && idProducto == 0)
            {
                comprasTabla = comprasAdapter.GetComprasPorIdUsuario(idUsuario);
            }else if(idUsuario==0 && idProducto != 0)
            {
                comprasTabla = comprasAdapter.GetComprasPorIdProducto(idProducto);
            }else
            {
                comprasTabla = comprasAdapter.GetComprasPorIdUsuarioConProducto(idUsuario, idProducto);
            }

            return comprasTabla;
        }

        public static DataSet1.comprasDataTable TablaComprasProductos(int idProducto, int idUsuario)
        {
            if (idProducto == 0 && idUsuario==0)
            {
                comprasTabla = comprasAdapter.GetCompras();
            }
            else if (idProducto != 0 && idUsuario==0)
            {
                comprasTabla = comprasAdapter.GetComprasPorIdProducto(idProducto);
            }
            else if (idProducto == 0 && idUsuario!=0)
            {
                comprasTabla = comprasAdapter.GetComprasPorIdUsuario(idUsuario);
            }
            else
            {
                comprasTabla = comprasAdapter.GetComprasPorIdProductoConUsuario(idProducto, idUsuario);
            }

            return comprasTabla;
        }

        public static DataSet1.comprasDataTable TablaMisCompras(int idUsuario)
        {
            comprasTabla = comprasAdapter.GetMisCompras(idUsuario);

            return comprasTabla;
        }

        public static void EliminarCompra(int idCompra)
        {
            DataSet1.comprasRow regCompra = comprasTabla.FindByidCompra(idCompra);

            regCompra.Delete();
            comprasAdapter.Update(comprasTabla);
            comprasTabla.AcceptChanges();
        }

        public static Compra DevuelveCompra(int idCompra)
        {
            DataSet1.comprasRow regCompra = comprasTabla.FindByidCompra(idCompra);

            Compra compra = new Compra(idCompra, regCompra.producto_id, regCompra.usuario_id, regCompra.cantidad, regCompra.fecha);

            return compra;
        }

        public static void ModificaCompra(Compra compra)
        {
            DataSet1.comprasRow regCompra = comprasTabla.FindByidCompra(compra.IdCompra);

            regCompra.cantidad = compra.Cantidad;
            regCompra.fecha = compra.Fecha;
            regCompra.producto_id = compra.Producto_id;
            regCompra.usuario_id = compra.Usuario_id;

            comprasAdapter.Update(regCompra);
            comprasTabla.AcceptChanges();
        }

        public static void AddCompra(Compra compra)
        {
            DataSet1.comprasRow regCompra = comprasTabla.NewcomprasRow();

            
            int lmax = Convert.ToInt32(comprasAdapter.IdCompraMax()) + 1;
            regCompra.idCompra = lmax;
            regCompra.cantidad = compra.Cantidad;
            regCompra.fecha = DateTime.Now;
            regCompra.producto_id = compra.Producto_id;
            regCompra.usuario_id = compra.Usuario_id;

            comprasTabla.AddcomprasRow(regCompra);

            comprasAdapter.Update(regCompra);
            comprasTabla.AcceptChanges();
        }
    }
}

using nba.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nba
{
    public partial class detalleProducto : System.Web.UI.Page
    {
        Producto producto;
        String nombreActual, descripcionActual;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                CargaEquipos();
                try
                {

                    int acceso = Convert.ToInt32(((Usuario)Session["Log"]).Acceso);

                    


                }
                catch
                {
                    Response.Redirect("Default.aspx");
                }

                producto = (Producto)Session["Producto"];

                if (producto.IdProducto != -1)
                {
                    CargarControles();
                }
            }
        }

        private void CargaEquipos()
        {
            List<Equipo> listaEquipos = LNyAD.ListaEquipos();
            listaEquipos.Insert(0, new Equipo(0, "Seleccione un equipo", "", -1));
            ddlEquipos.DataSource = listaEquipos;
            ddlEquipos.DataTextField = "Nombre";
            ddlEquipos.DataValueField = "IdEquipo";

            ddlEquipos.DataBind();
        }

        private void CargarControles()
        {
            txbNombre.Text = producto.Nombre;
            txbDescripcion.Text = producto.Descripcion;
            txbCantidad.Text = producto.Cantidad.ToString();
            txbPrecio.Text = producto.Precio.ToString();
            ddlEquipos.SelectedValue = producto.Equipo_id.ToString();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            producto = new Producto(((Producto)Session["Producto"]).IdProducto, txbNombre.Text, txbDescripcion.Text, Convert.ToInt32(txbCantidad.Text), Math.Round(Convert.ToDouble(txbPrecio.Text),2),Convert.ToInt32(ddlEquipos.SelectedValue));

            if (producto.IdProducto == -1)
            {
                LNyAD.AddProducto(producto);
            }else
            {
                LNyAD.ModificaProducto(producto);
            }

            Response.Redirect("productos.aspx");
        }

        protected void cusValNombre_ServerValidate(object source, ServerValidateEventArgs args)
        {
            nombreActual = ((Producto)Session["Producto"]).Nombre;
            if (LNyAD.ExisteNombreProducto(txbNombre.Text) && nombreActual!=txbNombre.Text)
            {
                args.IsValid = false;
                cusValNombre.ErrorMessage = "El producto " + txbNombre.Text + " ya existe";
            }
        }

        protected void cusValddl_ServerValidate(object source, ServerValidateEventArgs args)
        {
            
                if (ddlEquipos.SelectedIndex == 0)
                {
                    args.IsValid = false;

                }
            
        }

        protected void cusValDescripcion_ServerValidate(object source, ServerValidateEventArgs args)
        {
            descripcionActual = ((Producto)Session["Producto"]).Descripcion;
            if (LNyAD.ExisteDescripcionProducto(txbDescripcion.Text) && descripcionActual!=txbDescripcion.Text)
            {
                args.IsValid = false;
                cusValDescripcion.ErrorMessage = "La descripción " + txbDescripcion.Text + " ya existe";
            }
        }
    }
}
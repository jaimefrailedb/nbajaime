
using nba.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nba
{
    public partial class detalleCompra : System.Web.UI.Page
    {
        Compra compra;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {

                    int acceso = Convert.ToInt32(((Usuario)Session["Log"]).Acceso);




                }
                catch
                {
                    Response.Redirect("Default.aspx");
                }

                CargaCombo();

                compra = (Compra)Session["Compra"];

                if (compra.IdCompra != -1)
                {
                    CargarControles();
                }else
                {
                    int idProducto = ddlProducto.SelectedIndex+1;

                    
                    Producto producto = LNyAD.DevuelveProducto(idProducto);

                    Session["Producto"] = producto;

                    ddlProducto.SelectedValue = compra.Producto_id.ToString();
                    Calendar1.TodaysDate = DateTime.Today.Date;
                    txbFecha.Text = DateTime.Now.ToString();
                    txbUsuario.Text = compra.Usuario_id.ToString();
                    //int existencias = LNyAD.ExistenciasProducto(ddlProducto.SelectedIndex);
                    txbExistencias.Text =Convert.ToString( ((Producto)Session["Producto"]).Cantidad);
                }
            }
        }

        private void CargarControles()
        {
            ddlProducto.SelectedValue = compra.Producto_id.ToString();
            int idProducto = ddlProducto.SelectedIndex + 1;


            Producto producto = LNyAD.DevuelveProducto(idProducto);

            Session["Producto"] = producto;

            
            txbUsuario.Text = compra.Usuario_id.ToString();
            txbFecha.Text = compra.Fecha.ToString();
            txbCantidad.Text = compra.Cantidad.ToString();
            txbExistencias.Text = Convert.ToString(((Producto)Session["Producto"]).Cantidad);
        }

        private void CargaCombo()
        {
            List<Producto> listaProductos = LNyAD.listaProductos();

            ddlProducto.DataSource = listaProductos;
            ddlProducto.DataTextField = "Nombre";
            ddlProducto.DataValueField = "IdProducto";

            ddlProducto.DataBind();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            
            if (!Page.IsValid)
                return;

            
            compra = new Compra(((Compra)Session["Compra"]).IdCompra, Convert.ToInt32(ddlProducto.SelectedValue), Convert.ToInt32(txbUsuario.Text), Convert.ToInt32(txbCantidad.Text), Convert.ToDateTime(txbFecha.Text));

            if (compra.IdCompra == -1)
            {
                

                int idProducto = Convert.ToInt32(ddlProducto.SelectedValue);
                Producto producto = LNyAD.DevuelveProducto(idProducto);

                //Si hay la misma o más cantidad de producto que la cantidad de la compra permito realizarla y actualizo la cantidad de productos
                if (producto.Cantidad - compra.Cantidad >= 0)
                {
                    lbMensaje.Text = "";
                    LNyAD.ActualizaCantidadProducto(producto.Cantidad, compra.Cantidad, idProducto);
                    LNyAD.AddCompra(compra);
                }
                else
                {
                    lbMensaje.Visible = true;
                    return;
                }
            }else
            {
                LNyAD.ModificaCompra(compra);
            }

            Response.Redirect("compras.aspx");
        }

        protected void ddlProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProducto = ddlProducto.SelectedIndex+1;

            Producto producto = LNyAD.DevuelveProducto(idProducto);

            Session["Producto"] = producto;

            txbExistencias.Text = Convert.ToString(((Producto)Session["Producto"]).Cantidad);
        }

        protected void cusValCantidad_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int cantidad;

            bool esValido = Int32.TryParse(txbCantidad.Text, out cantidad);

            int max = Convert.ToInt32(txbExistencias.Text);

            if (!esValido)
            {
                args.IsValid = false;
            }else if(cantidad<1 || cantidad > max)
            {
                args.IsValid = false;
            }

            if (!args.IsValid)
            {
                cusValCantidad.ErrorMessage = "La cantidad debe estar entre 1 y " + max;
            }
        }
    }
}
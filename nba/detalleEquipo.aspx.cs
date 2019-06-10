using nba.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nba
{
    public partial class detalleEquipo : System.Web.UI.Page
    {
        Equipo equipo;
        String nombreActual;
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
                equipo = (Equipo)Session["Equipo"];

                if (equipo.IdEquipo != 0)
                    CargarControles();
            }
            

        }

        private void CargarControles()
        {
            txbNombre.Text = equipo.Nombre;
            ddlAnyoFundacion.SelectedValue = equipo.AnyoFundacion.ToString();
            ddlColores.SelectedValue = equipo.Colores;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            equipo = new Equipo(((Equipo)Session["Equipo"]).IdEquipo, txbNombre.Text, ddlColores.SelectedValue, Convert.ToInt32(ddlAnyoFundacion.SelectedValue));

            if (equipo.IdEquipo == -1)
                LNyAD.AddEquipo(equipo);
            else
                LNyAD.ModificaEquipo(equipo);

            Response.Redirect("equipos.aspx");
        }

        protected void cusValAnyoFundacion_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlAnyoFundacion.SelectedIndex < 1)
            {
                args.IsValid = false;
                cusValAnyoFundacion.ErrorMessage = "Debe seleccionar un año";
            }
        }

        protected void cusValColores_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlColores.SelectedIndex < 1)
            {
                args.IsValid = false;
                cusValColores.ErrorMessage = "Debe elegir color";
            }
        }

        protected void cusValNombre_ServerValidate(object source, ServerValidateEventArgs args)
        {
            nombreActual = ((Equipo)Session["Equipo"]).Nombre;

            if (LNyAD.ExisteEquipo(txbNombre.Text) && nombreActual != txbNombre.Text)
            {
                args.IsValid = false;
                cusValNombre.ErrorMessage = "El equipo " + txbNombre.Text + " ya existe, por favor seleccione otro";
            }
        }
    }
}
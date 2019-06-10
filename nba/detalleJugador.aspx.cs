using nba.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nba
{
    public partial class detalleJugador : System.Web.UI.Page
    {
        Jugador jug;
        string nombreActual;
        int dorsalActual;
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
                cargaEquipos();
                cargaPosiciones();

                jug = (Jugador)Session["Jugador"];

                if (jug.IdJugador != -1)
                    CargarControles();
                else
                {
                    ddlEquipo.Items.Insert(0, "Seleccione un equipo");
                    ddlPosicion.Items.Insert(0, "Seleccione una posición");
                }
            }
        }

        private void CargarControles()
        {
            txbNombre.Text = jug.Nombre;
            txbAltura.Text = jug.Altura.ToString();
            txbPeso.Text = jug.Peso.ToString();
            txbDorsal.Text = jug.Dorsal.ToString();
            ddlEquipo.SelectedValue = jug.Equipo_id.ToString();
            ddlPosicion.SelectedValue = jug.Posicion_id.ToString();
        }

        private void cargaPosiciones()
        {
            List<Posicion> lista = LNyAD.ListaPosiciones();

            ddlPosicion.DataSource = lista;
            ddlPosicion.DataTextField = "Descripcion";
            ddlPosicion.DataValueField = "IdPosicion";

            ddlPosicion.DataBind();
        }

        private void cargaEquipos()
        {
            List<Equipo> lista = LNyAD.ListaEquipos();

            ddlEquipo.DataSource = lista;
            ddlEquipo.DataTextField = "Nombre";
            ddlEquipo.DataValueField = "IdEquipo";

            ddlEquipo.DataBind();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            jug = new Jugador(((Jugador)Session["Jugador"]).IdJugador, txbNombre.Text, Convert.ToInt32(txbAltura.Text),Math.Round(Convert.ToSingle(txbPeso.Text),2), Convert.ToInt32(txbDorsal.Text), Convert.ToInt32(ddlEquipo.SelectedValue), Convert.ToInt32(ddlPosicion.SelectedValue));

            if (jug.IdJugador == -1)
                LNyAD.AddJugador(jug);
            else
                LNyAD.ModificaJugador(jug);

            Response.Redirect("jugadores.aspx");
        }

        protected void cusValNombre_ServerValidate(object source, ServerValidateEventArgs args)
        {
            nombreActual = ((Jugador)Session["Jugador"]).Nombre;

            if (LNyAD.ExisteNombreJugador(txbNombre.Text) && nombreActual != txbNombre.Text)
            {
                args.IsValid = false;
                cusValNombre.ErrorMessage = "El nombre " + txbNombre.Text + " ya existe, por favor seleccione otro";
            }
        }

        protected void cusValDorsal_ServerValidate(object source, ServerValidateEventArgs args)
        {
            dorsalActual = ((Jugador)Session["Jugador"]).Dorsal;
            if (LNyAD.ExisteDorsalEnEquipo(Convert.ToInt32(txbDorsal.Text),ddlEquipo.SelectedIndex) && dorsalActual!= Convert.ToInt32(txbDorsal.Text))
            {
                args.IsValid = false;

            }
            else if (LNyAD.ExisteDorsalEnEquipo(Convert.ToInt32(txbDorsal.Text), ddlEquipo.SelectedIndex) && txbNombre.Text.Equals(nombreActual) && ((Jugador)Session["Jugador"]).Equipo_id != Convert.ToInt32(ddlEquipo.SelectedValue))
            {
                args.IsValid = false;

            }

            if (!args.IsValid)
                cusValDorsal.ErrorMessage = "Ya existe el dorsal " + txbDorsal.Text + " en " + ddlEquipo.SelectedItem.Text + " por favor seleccione otro dorsal";
        }

        protected void cusValEquipo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (((Jugador)Session["Jugador"]).IdJugador == -1)
            {
                if (ddlEquipo.SelectedIndex == 0)
                {
                    args.IsValid = false;
                    
                }
            }
        }

        protected void cusValPosicion_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (((Jugador)Session["Jugador"]).IdJugador == -1)
            {
                if (ddlPosicion.SelectedIndex == 0)
                {
                    args.IsValid = false;
                }
            }
        }
    }
}
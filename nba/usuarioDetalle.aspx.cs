using nba.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nba
{
    public partial class usuarioDetalle : System.Web.UI.Page
    {
        Usuario usu;
        string nombreActual, aliasActual, loginActual, movilActual, mailActual;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {

                    int acceso = Convert.ToInt32(((Usuario)Session["Log"]).Acceso);

                    if(acceso == 1)
                    {
                        ddlCategoria.Enabled = false;
                    }


                }
                catch
                {
                    Response.Redirect("Default.aspx");
                }

                CargaCategorias();

                usu = (Usuario)Session["Usuario"];

                if (usu.IdUsuario != -1)
                    CargarControles();
            }
        }

        private void CargarControles()
        {
            txbNombre.Text = usu.Nombre;
            txbAlias.Text = usu.Alias;
            txbLogin.Text = usu.Login;
            txbPass.Text = usu.Password;
            txbRepPass.Text = usu.Password;
            txbMovil.Text = usu.Movil;
            txbMail.Text = usu.Mail;
            ddlCategoria.SelectedValue = usu.Acceso.ToString();
        }

        private void CargaCategorias()
        {
            List<Acceso> listaAccesos = LNyAD.ListaAccesos();
            ddlCategoria.DataSource = listaAccesos;
            ddlCategoria.DataTextField = "Descripcion";
            ddlCategoria.DataValueField = "IdAcceso";

            ddlCategoria.DataBind();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            usu = new Usuario(((Usuario)Session["Usuario"]).IdUsuario, txbNombre.Text, txbAlias.Text, txbLogin.Text, txbPass.Text, txbMovil.Text, txbMail.Text, Convert.ToInt32(ddlCategoria.SelectedValue));

            if (usu.IdUsuario == -1)
                LNyAD.AddUsuario(usu);
            else
                LNyAD.ModificaUsuario(usu);

            Response.Redirect("usuarios.aspx");
        }

        protected void cusValMail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            mailActual = ((Usuario)Session["Usuario"]).Mail;
            if (LNyAD.ExisteMail(txbMail.Text) && mailActual!=txbMail.Text)
            {
                args.IsValid = false;
                cusValMail.Text = "El correo " + txbMail.Text + " ya está registrado";
            }
        }

        protected void cusValNombre_ServerValidate(object source, ServerValidateEventArgs args)
        {
            nombreActual = ((Usuario)Session["Usuario"]).Nombre;

            if (LNyAD.ExisteNombre(txbNombre.Text) && nombreActual != txbNombre.Text)
            {
                args.IsValid = false;
                cusValNombre.ErrorMessage = "El nombre " + txbNombre.Text + " ya existe, por favor seleccione otro";
            }
        }

        protected void cusValMovil_ServerValidate(object source, ServerValidateEventArgs args)
        {
            movilActual = ((Usuario)Session["Usuario"]).Movil;
            if (LNyAD.ExisteMovil(txbMovil.Text) && movilActual != txbMovil.Text)
            {
                args.IsValid = false;
                cusValMovil.Text = "El móvil " + txbMovil.Text + " ya está registrado";
            }
        }

        protected void cusValLogin_ServerValidate(object source, ServerValidateEventArgs args)
        {
            loginActual = ((Usuario)Session["Usuario"]).Login;
            if (LNyAD.ExisteLogin(txbLogin.Text) && loginActual != txbLogin.Text)
            {
                args.IsValid = false;
                cusValLogin.Text = "El login " + txbLogin.Text + " ya existe";
            }
        }

        protected void cusValAlias_ServerValidate(object source, ServerValidateEventArgs args)
        {
            aliasActual= ((Usuario)Session["Usuario"]).Alias;
            if (LNyAD.ExisteAlias(txbAlias.Text) && aliasActual!=txbAlias.Text)
            {
                args.IsValid = false;
                cusValAlias.Text = "El alias " + txbAlias.Text + " ya existe";
            }
        }
    }
}
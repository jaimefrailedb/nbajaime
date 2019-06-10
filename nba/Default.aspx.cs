
using nba.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nba
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["Usuario"] = null;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (LNyAD.LoginCorrecto(txbUsuario.Text, txbPass.Text))
            {
                Usuario usu = LNyAD.DevuelveUsuarioLogado(txbUsuario.Text, txbPass.Text);
                Session["Log"] = usu;
                Session["Usuario"] = usu;
                lbError.Visible = false;
                Response.Redirect("equipos.aspx");
            }else if (LNyAD.LoginDeshabilitado(txbUsuario.Text,txbPass.Text))
            {
                lbError.Visible = true;
                lbError.Text = "Login correcto como deshabilitado. Pida acceso al administrador";
            }
            else
            {
                lbError.Visible = true;
                lbError.Text = "Usuario y/o contraseña incorrecto";
            }
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            if (!PanelReg.Visible)
                PanelReg.Visible = true;
            else
            {
                lbExito.Visible = false;
                if (!Page.IsValid)
                    return;

                Usuario usu = new Usuario(-1, txbNombre.Text, txbAlias.Text, txbLogin.Text, txbPassReg.Text, txbMovil.Text, txbMail.Text, 3);

                LNyAD.AddUsuario(usu);

                lbExito.Text = "Usuario registrado con éxito";
                lbExito.Visible = true;
            }


        }

        protected void cusValNombre_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (LNyAD.ExisteNombre(txbNombre.Text))
            {
                args.IsValid = false;
                cusValNombre.Text = "El nombre " + txbNombre.Text + " ya existe";
            }
        }

        protected void cusValAlias_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (LNyAD.ExisteAlias(txbAlias.Text))
            {
                args.IsValid = false;
                cusValAlias.Text = "El alias " + txbAlias.Text + " ya existe";
            }
        }

        protected void cusValLogin_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (LNyAD.ExisteLogin(txbLogin.Text))
            {
                args.IsValid = false;
                cusValLogin.Text = "El login " + txbLogin.Text + " ya existe";
            }
        }

        protected void cusValMovil_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (LNyAD.ExisteMovil(txbMovil.Text))
            {
                args.IsValid = false;
                cusValMovil.Text = "El móvil " + txbMovil.Text + " ya está registrado";
            }
        }

        protected void cusValMail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (LNyAD.ExisteMail(txbMail.Text))
            {
                args.IsValid = false;
                cusValMail.Text = "El correo " + txbMail.Text + " ya está registrado";
            }
        }

        
    }
}
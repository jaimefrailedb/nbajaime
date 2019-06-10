using nba.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nba
{
    public partial class recordarPass : System.Web.UI.Page
    {
        Usuario usu;
        bool PassActualOK = false;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cusValMail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!LNyAD.ExisteMail(txbMail.Text))
            {
                args.IsValid = false;
                cusValMail.ErrorMessage = "El mail " + txbMail.Text + " no existe en la aplicación";
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            lbExito.Text = "";
            if (LNyAD.ExisteMail(txbMail.Text))
            {
                usu = LNyAD.DevuelveDatosUsuarioConMail(txbMail.Text);

                

                

                MailMessage correo = new MailMessage();
                correo.To.Add(txbMail.Text);//destino
                correo.Subject = "Recuperación Contraseña app nba";//ASUNTO
                correo.Body = "Acceso a tu app nba \n\nUsuario: " + usu.Login + "\nContraseña: " + usu.Password;//mensaje
                correo.From = new MailAddress("jaimefdv@jaimefrailedebruguera.es");//quien lo envía
                correo.IsBodyHtml = true;
                SmtpClient cliente = new SmtpClient();//servidor de correo
                cliente.Host = "smtp.ionos.com";
                cliente.Port = 587;//para ssl
                cliente.UseDefaultCredentials = false;
                cliente.Credentials = new System.Net.NetworkCredential("jaimefdv@jaimefrailedebruguera.es", "MiraFuera");//dirección y contraseña para poder mandar mail
                
                cliente.EnableSsl = true;
                
                try
                {
                    btnCambiaPass.Enabled = true;
                    cliente.Send(correo);
                    cliente.Timeout = 900000;
                    lbAviso.Text = "Se ha enviado a " + usu.Mail + " sus datos, revise su bandeja de entrada";

                    
                    lbAviso.Visible = true;

                    txbMail.Enabled = false;
                }
                catch
                {
                    lbAviso.Text = "No se ha podido enviar el correo a " + usu.Mail + ", puede que el mail no exista realmente";
                    
                    lbAviso.Visible = true;
                    
                }
            }
        }

        protected void btnCambiaPass_Click(object sender, EventArgs e)
        {
            if (!panelCambiaPass.Visible)
                panelCambiaPass.Visible = true;
            else
            {
                if (!Page.IsValid)
                {
                    lbExito.Text = "";
                    return;
                }

                if (PassActualOK)
                {
                    Usuario usuModificado = LNyAD.DevuelveDatosUsuarioConMail(txbMail.Text);
                    Usuario usuPassNuevo = new Usuario(usuModificado.IdUsuario, usuModificado.Nombre, usuModificado.Alias, usuModificado.Login, txbNuevaPass.Text, usuModificado.Movil, usuModificado.Mail, usuModificado.Acceso);
                    LNyAD.ModificaUsuario(usuPassNuevo);
                    if (Page.IsValid)
                        lbExito.Text = "Éxito, contraseña modificada correctamente";
                }
            }
        
        }

        protected void cusValPassActual_ServerValidate(object source, ServerValidateEventArgs args)
        {
            usu = LNyAD.DevuelveDatosUsuarioConMail(txbMail.Text);

            if (!txbPassActual.Text.Equals(usu.Password))
            {
                args.IsValid = false;
                cusValPassActual.ErrorMessage = "La contraseña no es correcta";
                PassActualOK = false;
            }
            else
                PassActualOK = true;
        }
    }
}
using nba.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nba
{
    public partial class usuarios : System.Web.UI.Page
    {
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
                Cargacombo();
                CargaUsuariosCategoria();
            }
        }

        private void CargaUsuariosCategoria()
        {
            int idAcceso = Convert.ToInt32(ddlCategoria.SelectedValue);

            bool sonTodos = (idAcceso == 0);

            
            dgv.DataSource = LNyAD.TablaAccesos(idAcceso);
            dgv.Columns[1].Visible = true;//idUsuario
            dgv.Columns[5].Visible = true;//contraseña
            dgv.Columns[8].Visible = true;//acceso
            dgv.Columns[9].Visible = true;//categoria
            
            dgv.DataBind();
            dgv.Columns[1].Visible = false;//idUsuario
            dgv.Columns[5].Visible = false;//contraseña
            dgv.Columns[8].Visible = false;//acceso
            dgv.Columns[9].Visible = sonTodos;//categoria

            if (ddlCategoria.SelectedIndex == 0)
            {
                lbCabecera.Text = String.Format("{0} usuario(s)", dgv.Rows.Count);
            }
            else
            {
                lbCabecera.Text = String.Format("{0} usuario(s) de tipo {1}", dgv.Rows.Count, ddlCategoria.SelectedItem.ToString());
            }
        }

        private void Cargacombo()
        {
            List<Acceso> listaAccesos = LNyAD.ListaAccesos();

            listaAccesos.Insert(0, new Acceso(0,"Todas las categorías"));

            ddlCategoria.DataSource = listaAccesos;
            ddlCategoria.DataTextField = "Descripcion";
            ddlCategoria.DataValueField = "IdAcceso";

            ddlCategoria.DataBind();
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaUsuariosCategoria();
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            
            int idUsuario = Convert.ToInt32(dgv.Rows[dgv.SelectedIndex].Cells[1].Text);

            if (Convert.ToInt32(dgv.SelectedRow.Cells[1].Text) == ((Usuario)Session["Log"]).IdUsuario)
            {
                MostrarConfirmacion(false);
                lbNoBorrar.Text = "No puede eliminarse a si mismo";
                dgv.SelectedIndex = -1;
                return;
            }

            if(Convert.ToInt32(dgv.SelectedRow.Cells[8].Text)==1 && !LNyAD.ExistenMasAdministradores())
            {
                MostrarConfirmacion(false);
                lbNoBorrar.Text = "No puedes eliminar a " + dgv.SelectedRow.Cells[2].Text + " porque no hay más administradores";
                dgv.SelectedIndex = -1;
                return;
            }

            if (LNyAD.UsuarioTieneCompras(idUsuario))
            {
                MostrarConfirmacion(false);
                lbNoBorrar.Text = "No puedes eliminar a " + dgv.SelectedRow.Cells[2].Text + " porque ha realizado compras";
                dgv.SelectedIndex = -1;
                return;
            }

            LNyAD.EliminarUsuario(idUsuario);
            dgv.SelectedIndex = -1;
            MostrarConfirmacion(false);
            CargaUsuariosCategoria();
            
            
        }

        protected void dgv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lbNoBorrar.Text = "";
            dgv.SelectedIndex = e.RowIndex;
            MostrarConfirmacion(true);
        }

        protected void MostrarConfirmacion(bool loMostramos)
        {
            if (loMostramos)
            {
                btnAddUsuario.Visible = false;
                btnVolver.Visible = false;
                btnExportar.Visible = false;
                ddlCategoria.Enabled = false;
                panelBorrado.Visible = true;
                lbBorrado.Text = "¿Está seguro de eliminar a " + dgv.SelectedRow.Cells[2].Text + "?";
                dgv.Enabled = false;
            }else
            {
                btnAddUsuario.Visible = true;
                btnVolver.Visible = true;
                btnExportar.Visible = true;
                ddlCategoria.Enabled = true;
                panelBorrado.Visible = false;
                dgv.Enabled = true;
            }
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            MostrarConfirmacion(false);
            dgv.SelectedIndex = -1;
        }

        protected void dgv_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32(dgv.SelectedRow.Cells[1].Text);

            Usuario usu = LNyAD.DevuelveUsuario(idUsuario);

            Session["Usuario"] = usu;
            Response.Redirect("usuarioDetalle.aspx");
        }

        protected void btnAddUsuario_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = new Usuario(-1, "", "", "", "", "", "", 3);
            Response.Redirect("usuarioDetalle.aspx");
        }
    }
}
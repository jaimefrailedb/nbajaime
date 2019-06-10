using nba.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nba
{
    public partial class equipos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargaEquipos();
                
                
            }
        }

        private void CargaEquipos()
        {
            try
            {
                dgv.Columns[0].Visible = true;//editar
                dgv.Columns[1].Visible = true;//idequipo
                dgv.Columns[5].Visible = true;//eliminar
                dgv.DataSource = LNyAD.TablaEquipos();
                dgv.DataBind();
                int acceso = Convert.ToInt32(((Usuario)Session["Log"]).Acceso);
                if (acceso == 2)
                {
                    dgv.Columns[0].Visible = false;
                    dgv.Columns[5].Visible = false;
                    btnAddEquip.Visible = false;
                    btnGestionUsuarios.Visible = false;
                    btnExportar.Visible = false;
                }
                dgv.Columns[1].Visible = false;

                lbResultados.Text = String.Format("{0} equipo(s)", dgv.Rows.Count);
            }
            catch
            {
                Response.Redirect("Default.aspx");
            }
            
            
        }

        private void CargaEquiposColores()
        {
            bool sonTodosColores = (ddlColores.SelectedIndex == 0);
            bool sonTodosAnyos = (ddlAnyoFundacion.SelectedIndex == 0);

            dgv.DataSource = LNyAD.TablaEquiposPorColores(ddlColores.SelectedValue, ddlAnyoFundacion.SelectedValue);

            dgv.Columns[0].Visible = true;//sel
            dgv.Columns[1].Visible = true;//idequipo
            dgv.Columns[2].Visible = true;//nombre
            dgv.Columns[3].Visible = true;//colores
            dgv.Columns[4].Visible = true;//año
            dgv.Columns[5].Visible = true;//del

            int acceso = Convert.ToInt32(((Usuario)Session["Usuario"]).Acceso);
            if (acceso == 2)
            {
                dgv.Columns[0].Visible = false;
                dgv.Columns[5].Visible = false;
            }

            dgv.DataBind();

            if (dgv.Rows.Count == 0)
            {
                lbResultados.Text = "No hay resultados para los criterios seleccionados";
            }else
            {
                if (ddlAnyoFundacion.SelectedIndex == 0 && ddlColores.SelectedIndex == 0)
                {
                    lbResultados.Text = String.Format("{0} equipo(s)", dgv.Rows.Count);
                }
                else if (ddlAnyoFundacion.SelectedIndex != 0 && ddlColores.SelectedIndex == 0)
                {
                    lbResultados.Text = String.Format("{0} equipo(s) del {1}", dgv.Rows.Count,ddlAnyoFundacion.SelectedItem.ToString());
                }
                else if(ddlAnyoFundacion.SelectedIndex == 0 && ddlColores.SelectedIndex != 0)
                {
                    lbResultados.Text = String.Format("{0} equipo(s) de color(es) {1}", dgv.Rows.Count, ddlColores.SelectedItem.ToString());
                }
                else{
                    lbResultados.Text = String.Format("{0} equipo(s) del {1} de color(es) {2}", dgv.Rows.Count, ddlAnyoFundacion.SelectedItem.ToString(),ddlColores.SelectedItem.ToString());
                }
            }

            dgv.Columns[1].Visible = false;
            dgv.Columns[3].Visible = sonTodosColores;
            dgv.Columns[4].Visible = sonTodosAnyos;

            
            

        }

        private void CargaEquiposAnyo()
        {
            bool sonTodosColores = (ddlColores.SelectedIndex == 0);
            bool sonTodosAnyos = (ddlAnyoFundacion.SelectedIndex == 0);

            dgv.DataSource = LNyAD.TablaEquiposPorAnyo(ddlAnyoFundacion.SelectedValue, ddlColores.SelectedValue );

            dgv.Columns[0].Visible = true;//sel
            dgv.Columns[1].Visible = true;//idequipo
            dgv.Columns[2].Visible = true;//nombre
            dgv.Columns[3].Visible = true;//colores
            dgv.Columns[4].Visible = true;//año
            dgv.Columns[5].Visible = true;//del

            int acceso = Convert.ToInt32(((Usuario)Session["Usuario"]).Acceso);
            if (acceso == 2)
            {
                dgv.Columns[0].Visible = false;
                dgv.Columns[5].Visible = false;
            }

            

            dgv.DataBind();

            if (dgv.Rows.Count == 0)
            {
                lbResultados.Text = "No hay resultados para los criterios seleccionados";
            }
            else
            {
                if (ddlAnyoFundacion.SelectedIndex == 0 && ddlColores.SelectedIndex == 0)
                {
                    lbResultados.Text = String.Format("{0} equipo(s)", dgv.Rows.Count);
                }
                else if (ddlAnyoFundacion.SelectedIndex != 0 && ddlColores.SelectedIndex == 0)
                {
                    lbResultados.Text = String.Format("{0} equipo(s) del {1}", dgv.Rows.Count, ddlAnyoFundacion.SelectedItem.ToString());
                }
                else if (ddlAnyoFundacion.SelectedIndex == 0 && ddlColores.SelectedIndex != 0)
                {
                    lbResultados.Text = String.Format("{0} equipo(s) de color(es) {1}", dgv.Rows.Count, ddlColores.SelectedItem.ToString());
                }
                else
                {
                    lbResultados.Text = String.Format("{0} equipo(s) del {1} de color(es) {2}", dgv.Rows.Count, ddlAnyoFundacion.SelectedItem.ToString(), ddlColores.SelectedItem.ToString());
                }
            }

            dgv.Columns[1].Visible = false;
            dgv.Columns[3].Visible = sonTodosColores;
            dgv.Columns[4].Visible = sonTodosAnyos;
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            
            int idEquipo = Convert.ToInt32(dgv.Rows[dgv.SelectedIndex].Cells[1].Text);

            if (LNyAD.EquipoTieneProductos(idEquipo))
            {
                MostrarConfirmacion(false);
                lbNoBorrado.Text = "No puedes borrar el equipo " + dgv.Rows[dgv.SelectedIndex].Cells[2].Text + " porque tiene productos";
                dgv.SelectedIndex = -1;
                return;
            }

            if (!LNyAD.ExistenJugadoresEnEquipo(idEquipo))
            {
                LNyAD.EliminarEquipo(idEquipo);
                CargaEquipos();
                
            }else
            {
                lbNoBorrado.Text = "No puedes borrar el equipo " + dgv.Rows[dgv.SelectedIndex].Cells[2].Text + " porque tiene jugadores";   
            }
            MostrarConfirmacion(false);
            dgv.SelectedIndex = -1;
        }

        protected void dgv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lbNoBorrado.Text = "";
            dgv.SelectedIndex = e.RowIndex;
            MostrarConfirmacion(true);
        }

        protected void MostrarConfirmacion(bool loMostramos)
        {
            if (loMostramos)
            {
                btnAddEquip.Visible = false;
                btnGestionUsuarios.Visible = false;
                btnJugadores.Visible = false;
                btnProductos.Visible = false;
                btnVolver.Visible = false;
                btnExportar.Visible = false;
                ddlColores.Enabled = false;
                ddlAnyoFundacion.Enabled = false;
                dgv.Enabled = false;
                panelBorrado.Visible = true;
                lbBorrar.Text = "¿Está seguro de eliminar el equipo " + dgv.Rows[dgv.SelectedIndex].Cells[2].Text + "?";
            }else
            {
                btnExportar.Visible = true;
                btnAddEquip.Visible = true;
                btnGestionUsuarios.Visible = true;
                btnJugadores.Visible = true;
                btnProductos.Visible = true;
                btnVolver.Visible = true;
                ddlAnyoFundacion.Enabled = true;
                ddlColores.Enabled = true;
                dgv.Enabled = true;
                panelBorrado.Visible = false;
            }
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            MostrarConfirmacion(false);
            dgv.SelectedIndex = -1;
        }

        protected void dgv_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idEquipo = Convert.ToInt32(dgv.SelectedRow.Cells[1].Text);

            Equipo equipo = LNyAD.DevuelveEquipo(idEquipo);

            Session["Equipo"] = equipo;

            Response.Redirect("detalleEquipo.aspx");
        }

        protected void btnAddEquip_Click(object sender, EventArgs e)
        {
            Session["Equipo"] = new Equipo(-1, "", "", -1);
            Response.Redirect("detalleEquipo.aspx");
        }

        protected void ddlColores_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaEquiposColores();
        }

        protected void ddlAnyoFundacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaEquiposAnyo();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
        }
    }
}

using nba.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nba
{
    public partial class jugadores : System.Web.UI.Page
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
                CargaEquipos();
                CargaPosiciones();
                CargaJugadoresPorEquipo();
                CargaJugadoresPorPosicion();
            }
        }

        private void CargaJugadoresPorEquipo()
        {
            int idEquipo = Convert.ToInt32(ddlEquipos.SelectedValue);
            int idPosicion = Convert.ToInt32(ddlPosiciones.SelectedValue);

            bool sonTodosEquipos = (idEquipo == 0);
            bool sonTodosPosiciones = (idPosicion == 0);
            dgv.DataSource = LNyAD.TablaJugadores(idEquipo,idPosicion);

            dgv.Columns[1].Visible = true;//idjugador
            dgv.Columns[5].Visible = true;//nombre del equipo
            dgv.Columns[7].Visible = true;//equipo_id
            dgv.Columns[8].Visible = true;//posicion
            dgv.Columns[9].Visible = true;//posicion_id

            dgv.DataBind();

            int acceso = Convert.ToInt32(((Usuario)Session["Log"]).Acceso);
            if (acceso == 2)
            {
                dgv.Columns[0].Visible = false;
                dgv.Columns[10].Visible = false;
                btnAddJugador.Visible = false;
                btnExportar.Visible = false;
            }

            if (ddlEquipos.SelectedIndex == 0 && ddlPosiciones.SelectedIndex == 0)
            {
                lbCabecera.Text = String.Format("{0} jugador(es)", dgv.Rows.Count);
            }
            else if (ddlEquipos.SelectedIndex != 0 && ddlPosiciones.SelectedIndex == 0)
            {
                lbCabecera.Text = String.Format("{0} jugador(es) de {1}", dgv.Rows.Count, ddlEquipos.SelectedItem.Text);
            }
            else if (ddlEquipos.SelectedIndex == 0 && ddlPosiciones.SelectedIndex != 0)
            {
                lbCabecera.Text = String.Format("{0} jugador(es) {1}", dgv.Rows.Count, ddlPosiciones.SelectedItem.Text);
            }
            else
            {
                lbCabecera.Text = String.Format("{0} jugador(es) de {1} {2}", dgv.Rows.Count, ddlEquipos.SelectedItem.Text, ddlPosiciones.SelectedItem.Text);
            }

            dgv.Columns[1].Visible = false;
            dgv.Columns[5].Visible = sonTodosEquipos;
            dgv.Columns[7].Visible = false;
            dgv.Columns[8].Visible = sonTodosPosiciones;
            dgv.Columns[9].Visible = false;
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

        private void CargaPosiciones()
        {
            List<Posicion> listaPosiciones = LNyAD.ListaPosiciones();
            listaPosiciones.Insert(0, new Posicion(0, "Seleccione una posición"));
            ddlPosiciones.DataSource = listaPosiciones;
            ddlPosiciones.DataTextField = "Descripcion";
            ddlPosiciones.DataValueField = "IdPosicion";

            ddlPosiciones.DataBind();
        }

        protected void ddlEquipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaJugadoresPorEquipo();
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            int idJugador = Convert.ToInt32(dgv.Rows[dgv.SelectedIndex].Cells[1].Text);

            LNyAD.EliminarJugador(idJugador);
            dgv.SelectedIndex = -1;
            MostrarConfirmacion(false);
            CargaJugadoresPorEquipo();
        }

        protected void dgv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            dgv.SelectedIndex = e.RowIndex;
            MostrarConfirmacion(true);
        }

        protected void MostrarConfirmacion(bool loMostramos)
        {
            if (loMostramos)
            {
                btnExportar.Visible = false;
                btnAddJugador.Visible = false;
                btnVolver.Visible = false;
                ddlEquipos.Enabled = false;
                ddlPosiciones.Enabled = false;
                dgv.Enabled = false;

                lbBorrar.Text = "¿Está seguro de eliminar a " + dgv.SelectedRow.Cells[2].Text + "?";
                panelBorrado.Visible = true;
            }else
            {
                btnExportar.Visible = true;
                btnAddJugador.Visible = true;
                btnVolver.Visible = true;
                ddlPosiciones.Enabled = true;
                ddlEquipos.Enabled = true;
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
            int idJugador = Convert.ToInt32(dgv.SelectedRow.Cells[1].Text);

            Jugador jugador = LNyAD.DevuelveJugador(idJugador);

            Session["Jugador"] = jugador;
            Response.Redirect("detalleJugador.aspx");
        }

        protected void btnAddJugador_Click(object sender, EventArgs e)
        {
            Session["Jugador"] = new Jugador(-1, "", -1, -1, -1, -1, -1);

            Response.Redirect("detalleJugador.aspx");
        }

        protected void ddlPosiciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaJugadoresPorPosicion();
        }

        private void CargaJugadoresPorPosicion()
        {
            int idEquipo = Convert.ToInt32(ddlEquipos.SelectedValue);
            int idPosicion = Convert.ToInt32(ddlPosiciones.SelectedValue);

            bool sonTodosEquipos = (idEquipo == 0);
            bool sonTodosPosiciones = (idPosicion == 0);
            dgv.DataSource = LNyAD.TablaJugadoresPosicion(idPosicion, idEquipo);

            dgv.Columns[1].Visible = true;//idjugador
            dgv.Columns[5].Visible = true;//nombre del equipo
            dgv.Columns[7].Visible = true;//equipo_id
            dgv.Columns[8].Visible = true;//posicion
            dgv.Columns[9].Visible = true;//posicion_id

            dgv.DataBind();

            int acceso = Convert.ToInt32(((Usuario)Session["Usuario"]).Acceso);
            if (acceso == 2)
            {
                dgv.Columns[0].Visible = false;
                dgv.Columns[10].Visible = false;
                btnAddJugador.Visible = false;

            }

            if (ddlEquipos.SelectedIndex == 0 && ddlPosiciones.SelectedIndex == 0)
            {
                lbCabecera.Text = String.Format("{0} jugador(es)", dgv.Rows.Count);
            }
            else if (ddlEquipos.SelectedIndex != 0 && ddlPosiciones.SelectedIndex == 0)
            {
                lbCabecera.Text = String.Format("{0} jugador(es) de {1}", dgv.Rows.Count, ddlEquipos.SelectedItem.Text);
            }
            else if (ddlEquipos.SelectedIndex == 0 && ddlPosiciones.SelectedIndex != 0)
            {
                lbCabecera.Text = String.Format("{0} jugador(es) {1}", dgv.Rows.Count, ddlPosiciones.SelectedItem.Text);
            }
            else
            {
                lbCabecera.Text = String.Format("{0} jugador(es) de {1} {2}", dgv.Rows.Count, ddlEquipos.SelectedItem.Text, ddlPosiciones.SelectedItem.Text);
            }

            dgv.Columns[1].Visible = false;
            dgv.Columns[5].Visible = sonTodosEquipos;
            dgv.Columns[7].Visible = false;
            dgv.Columns[8].Visible = sonTodosPosiciones;
            dgv.Columns[9].Visible = false;
        }

        protected void dgv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgv.PageIndex = e.NewPageIndex;
            CargaJugadoresPorEquipo();
        }
    }
}
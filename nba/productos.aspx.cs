using nba.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nba
{
    public partial class productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargaEquipos();
                CargaProductos();
                
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

        private void CargaProductos()
        {
            int idEquipo = Convert.ToInt32(ddlEquipos.SelectedValue);
            bool sonTodos = (idEquipo == 0);
            dgv.DataSource = LNyAD.TablaProductos(idEquipo);
            dgv.Columns[0].Visible = true;//editar
            dgv.Columns[1].Visible = true;//idProducto
            dgv.Columns[6].Visible = true;//equipo_id
            dgv.Columns[7].Visible = true;//Equipo
            dgv.Columns[8].Visible = true;//del
            dgv.DataBind();
            try
            {
                int acceso = Convert.ToInt32(((Usuario)Session["Log"]).Acceso);
                if (acceso == 2)
                {
                    dgv.Columns[0].Visible = false;
                    dgv.Columns[8].Visible = false;
                    btnAddProducto.Visible = false;
                    btnExportar.Visible = false;
                }
                dgv.Columns[1].Visible = false;
                dgv.Columns[6].Visible = false;
                dgv.Columns[7].Visible = sonTodos;

                if (ddlEquipos.SelectedIndex == 0)
                {
                    lbCabecera.Text = String.Format("{0} producto(s)", dgv.Rows.Count);
                }
                else
                {
                    lbCabecera.Text = String.Format("{0} producto(s) de {1}", dgv.Rows.Count,ddlEquipos.SelectedItem.Text);
                }
            }
            catch
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            
            int idProducto = Convert.ToInt32(dgv.Rows[dgv.SelectedIndex].Cells[1].Text);

            if (!LNyAD.ExisteProductoEnCompra(idProducto))
            {

                LNyAD.EliminarProducto(idProducto);

                CargaProductos();

                MostrarConfirmacion(false);

                dgv.SelectedIndex = -1;
            }else
            {
                MostrarConfirmacion(false);
                lbNoBorrar.Text = "No puede borrar el producto " + dgv.SelectedRow.Cells[2].Text + " porque existe en compras";
                dgv.SelectedIndex = -1;
                return;
            }

            
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
                btnExportar.Visible = false;
                btnAddProducto.Visible = false;
                btnCompras.Visible = false;
                btnVolver.Visible = false;
                ddlEquipos.Enabled = false;
                dgv.Enabled = false;
                lbBorrado.Text = "¿Está seguro de eliminar el producto " + dgv.SelectedRow.Cells[2].Text + "?";
                panelBorrado.Visible = true;
            }
            else
            {
                btnExportar.Visible = true;
                btnAddProducto.Visible = true;
                btnCompras.Visible = true;
                btnVolver.Visible = true;
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
            int idProducto = Convert.ToInt32(dgv.SelectedRow.Cells[1].Text);

            Producto producto = LNyAD.DevuelveProducto(idProducto);

            Session["Producto"] = producto;

            Response.Redirect("detalleProducto.aspx");
        }

        protected void btnAddProducto_Click(object sender, EventArgs e)
        {
            Session["Producto"] = new Producto(-1, "", "", -1, -1,-1);

            Response.Redirect("detalleProducto.aspx");
        }

        protected void ddlEquipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaProductos();
        }

        protected void dgv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgv.PageIndex = e.NewPageIndex;
            CargaProductos();
        }
    }
}
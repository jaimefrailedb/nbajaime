
using nba.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nba
{
    public partial class compras : System.Web.UI.Page
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

                CargaProductos();
                CargaUsuarios();
                

                if (((Usuario)Session["Log"]).Acceso == 1)
                {
                    CargaComprasPorUsuario();
                    CargaComprasPorProducto();
                }else
                {
                    ddlProductos.Visible = false;
                    ddlUsuario.Visible = false;
                    lbProducto.Visible = false;
                    lbUsuario.Visible = false;
                    btnExportar.Visible = false;
                    CargaMisCompras();
                }

                if (dgv.Rows.Count == 0)
                {
                    lbCabecera.Text = "Actualmente no existen compras";
                }
            }
        }

        private void CargaUsuarios()
        {
            List<Usuario> listaUsuarios = LNyAD.listaUsuarios();

            listaUsuarios.Insert(0, new Usuario(0, "Seleccione un usuario", "", "", "", "", "", 0));
            ddlUsuario.DataSource = listaUsuarios;
            ddlUsuario.DataTextField = "Nombre";
            ddlUsuario.DataValueField = "IdUsuario";

            ddlUsuario.DataBind();
        }

        private void CargaProductos()
        {
            List<Producto> listaProductos = LNyAD.listaProductos();

            listaProductos.Insert(0, new Producto(0, "Seleccione un producto", "", 0, 0, 0));
            ddlProductos.DataSource = listaProductos;
            ddlProductos.DataTextField = "Nombre";
            ddlProductos.DataValueField = "IdProducto";

            ddlProductos.DataBind();
        }

        private void CargaMisCompras()
        {
            dgv.Columns[0].Visible = true;//sel
            dgv.Columns[1].Visible = true;//idCompra
            dgv.Columns[3].Visible = true;//producto_id
            dgv.Columns[4].Visible = true;//usuario
            dgv.Columns[5].Visible = true;//usuario_id
            dgv.Columns[8].Visible = true;//del

            int idUsuario = ((Usuario)Session["Log"]).IdUsuario;
            dgv.DataSource = LNyAD.TablaMisCompras(idUsuario);

            dgv.DataBind();

            if (dgv.Rows.Count == 0)
            {
                lbCabecera.Text = "Actualmente no existen compras";
            }
            else
            {
                lbCabecera.Text = String.Format("{0} compra(s)", dgv.Rows.Count);
            }

            dgv.Columns[0].Visible = false;
            dgv.Columns[1].Visible = false;
            dgv.Columns[3].Visible = false;
            dgv.Columns[4].Visible = false;
            dgv.Columns[5].Visible = false;
            dgv.Columns[8].Visible = false;
        }

        private void CargaComprasPorUsuario()
        {
            int idUsuario = Convert.ToInt32(ddlUsuario.SelectedValue);
            int idProducto = Convert.ToInt32(ddlProductos.SelectedValue);

            bool sonTodosUsuarios = (idUsuario == 0);
            bool sonTodosProductos = (idProducto == 0);

            dgv.Columns[0].Visible = true;//sel
            dgv.Columns[1].Visible = true;//idCompra
            dgv.Columns[2].Visible = true;//producto
            dgv.Columns[3].Visible = true;//producto_id
            dgv.Columns[4].Visible = true;//usuario
            dgv.Columns[5].Visible = true;//usuario_id
            dgv.DataSource = LNyAD.TablaCompras(idUsuario,idProducto);

            dgv.DataBind();
            if (dgv.Rows.Count == 0)
            {
                lbCabecera.Text = "Actualmente no existen compras con estos criterios";
            }
            else
            {
                if (ddlProductos.SelectedIndex==0 && ddlUsuario.SelectedIndex == 0)
                {
                    lbCabecera.Text = String.Format("{0} compra(s)", dgv.Rows.Count);
                }else if(ddlProductos.SelectedIndex != 0 && ddlUsuario.SelectedIndex == 0)
                {
                    lbCabecera.Text = String.Format("{0} compra(s) con {1}", dgv.Rows.Count, ddlProductos.SelectedItem.ToString());
                }
                else if (ddlProductos.SelectedIndex == 0 && ddlUsuario.SelectedIndex != 0)
                {
                    lbCabecera.Text = String.Format("{0} compra(s) de {1}", dgv.Rows.Count, ddlUsuario.SelectedItem.ToString());
                }
                else
                {
                    lbCabecera.Text = String.Format("{0} compra(s) con {1} de {2}", dgv.Rows.Count, ddlProductos.SelectedItem.ToString(),ddlUsuario.SelectedItem.ToString());
                }
            }
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].Visible = false;
            dgv.Columns[2].Visible = sonTodosProductos;
            dgv.Columns[3].Visible = false;
            dgv.Columns[4].Visible = sonTodosUsuarios;
            dgv.Columns[5].Visible = false;
        }

        private void CargaComprasPorProducto()
        {
            int idUsuario = Convert.ToInt32(ddlUsuario.SelectedValue);
            int idProducto = Convert.ToInt32(ddlProductos.SelectedValue);

            bool sonTodosUsuarios = (idUsuario == 0);
            bool sonTodosProductos = (idProducto == 0);

            dgv.Columns[0].Visible = true;//sel
            dgv.Columns[1].Visible = true;//idCompra
            dgv.Columns[2].Visible = true;//producto
            dgv.Columns[3].Visible = true;//producto_id
            dgv.Columns[4].Visible = true;//usuario
            dgv.Columns[5].Visible = true;//usuario_id
            dgv.DataSource = LNyAD.TablaComprasProductos(idProducto, idUsuario);

            dgv.DataBind();

            if (dgv.Rows.Count == 0)
            {
                lbCabecera.Text = "Actualmente no existen compras con estos criterios";
            }
            else
            {
                if (ddlProductos.SelectedIndex == 0 && ddlUsuario.SelectedIndex == 0)
                {
                    lbCabecera.Text = String.Format("{0} compra(s)", dgv.Rows.Count);
                }
                else if (ddlProductos.SelectedIndex != 0 && ddlUsuario.SelectedIndex == 0)
                {
                    lbCabecera.Text = String.Format("{0} compra(s) con {1}", dgv.Rows.Count, ddlProductos.SelectedItem.ToString());
                }
                else if (ddlProductos.SelectedIndex == 0 && ddlUsuario.SelectedIndex != 0)
                {
                    lbCabecera.Text = String.Format("{0} compra(s) de {1}", dgv.Rows.Count, ddlUsuario.SelectedItem.ToString());
                }
                else
                {
                    lbCabecera.Text = String.Format("{0} compra(s) con {1} de {2}", dgv.Rows.Count, ddlProductos.SelectedItem.ToString(), ddlUsuario.SelectedItem.ToString());
                }
            }

            dgv.Columns[0].Visible = false;
            dgv.Columns[1].Visible = false;
            dgv.Columns[2].Visible = sonTodosProductos;
            dgv.Columns[3].Visible = false;
            dgv.Columns[4].Visible = sonTodosUsuarios;
            dgv.Columns[5].Visible = false;
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            int idCompra = Convert.ToInt32(dgv.Rows[dgv.SelectedIndex].Cells[1].Text);

            LNyAD.EliminarCompra(idCompra);

            CargaComprasPorUsuario();

            MostrarConfirmacion(false);

            dgv.SelectedIndex = -1;
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
                btnComprar.Visible = false;
                btnVolver.Visible = false;
                ddlUsuario.Enabled = false;
                ddlProductos.Enabled = false;
                dgv.Enabled = false;
                panelBorrado.Visible = true;

                if (ddlUsuario.SelectedIndex == 0 && ddlProductos.SelectedIndex == 0)
                {
                    lbBorrado.Text = "¿Está seguro de eliminar la compra de " + dgv.SelectedRow.Cells[4].Text + " que contiene " + dgv.SelectedRow.Cells[2].Text + "?";
                }else if (ddlUsuario.SelectedIndex != 0 && ddlProductos.SelectedIndex == 0)
                {
                    lbBorrado.Text = "¿Está seguro de eliminar la compra de " + ddlUsuario.SelectedItem.ToString() + " que contiene " + dgv.SelectedRow.Cells[2].Text + "?";
                }
                else if (ddlUsuario.SelectedIndex == 0 && ddlProductos.SelectedIndex != 0)
                {
                    lbBorrado.Text = "¿Está seguro de eliminar la compra de " + dgv.SelectedRow.Cells[4].Text + " que contiene " + ddlProductos.SelectedItem.ToString() + "?";
                }
                else
                {
                    lbBorrado.Text = "¿Está seguro de eliminar la compra de " + ddlUsuario.SelectedItem.ToString() + " que contiene " + ddlProductos.SelectedItem.ToString() + "?";
                }

            }else
            {
                btnExportar.Visible = true;
                btnComprar.Visible = true;
                btnVolver.Visible = true;
                ddlProductos.Enabled = true;
                ddlUsuario.Enabled = true;
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
            int idCompra = Convert.ToInt32(dgv.SelectedRow.Cells[1].Text);

            Compra compra = LNyAD.DevuelveCompra(idCompra);

            Session["Compra"] = compra;

            Response.Redirect("detalleCompra.aspx");
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            Session["Compra"] = new Compra(-1, -1, ((Usuario)(Session["Usuario"])).IdUsuario, -1, DateTime.Now.Date);

            Response.Redirect("detalleCompra.aspx");
        }

        protected void ddlUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaComprasPorUsuario();
        }

        protected void ddlProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaComprasPorProducto();
            
        }

        protected void dgv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgv.PageIndex = e.NewPageIndex;

            if (((Usuario)Session["Log"]).Acceso == 1)
            {
                CargaComprasPorUsuario();
                CargaComprasPorProducto();
            }
            else
            {
                CargaMisCompras();
            }
        }
    }
}
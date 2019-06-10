using Microsoft.Reporting.WebForms;
using nba.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nba
{
    public partial class informeEquipos : System.Web.UI.Page
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
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("bin/equipos.rdlc");
            }
        }
    }
}
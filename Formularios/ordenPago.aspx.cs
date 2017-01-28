using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using capaNegocios;

public partial class Formularios_ordenPago : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            ResourceManager1.AddScript("setFormat();");
            ordenPago Pagos = new ordenPago();
            this.strPagos.DataSource = Pagos.getAllPendientesPago();
            this.strPagos.DataBind();
        }
    }
}
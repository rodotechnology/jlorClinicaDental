using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using capaNegocios;
using Ext.Net;


public partial class Formularios_frmConsulta : System.Web.UI.Page
{
    manttoServicios objNegocioServicio = new manttoServicios();
    consulta objConsulta = new consulta();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            getServicios();
        }

    }
    public void getServicios()
    {
        StoreServicios.DataSource = objNegocioServicio.selectAllItems();
        StoreServicios.DataBind();
    }

    [DirectMethod]
    public void getDientes(string idEmisferio)
    {
        Store2.DataSource = objConsulta.selectAllItems(idEmisferio);
        Store2.DataBind();
    }


}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using capaNegocio;


public partial class Formularios_servicios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [DirectMethod]
    public void guardar(string txtNombre, string txtCosto) {
        manttoServicios obj = new manttoServicios();
        obj.saveItems(txtNombre, txtCosto);

    }

    public void Selec() {
        manttoServicios objSelect = new manttoServicios();
        Store1.DataSource = objSelect.selectAllItems();
    }
}
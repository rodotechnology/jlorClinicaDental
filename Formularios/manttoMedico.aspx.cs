using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using capaNegocios;

public partial class Formularios_ManttoMedico : System.Web.UI.Page
{
    negocioMedico objMedico = new negocioMedico();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!X.IsAjaxRequest)
            {
                this.StoreEspecialidad.DataSource = objMedico.getAllEspecialidad();
                this.StoreEspecialidad.DataBind();

                this.StoreHorarios.DataSource = objMedico.getAllHorarios();
                this.StoreHorarios.DataBind();

                this.strMedico.DataSource = objMedico.getAllMedicos();
                this.strMedico.DataBind();
            }
        }
    }
}
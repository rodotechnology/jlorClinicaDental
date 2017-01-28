using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using capaNegocios;

public partial class Formularios_Alertas : System.Web.UI.Page
{
    negocioAlerta objNegocio = new negocioAlerta();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!X.IsAjaxRequest)
            {
                recargarGrid();
            }
        }
    }

    private void recargarGrid()
    {
        this.strAlerta.DataSource = objNegocio.getAllAlertas();
        this.strAlerta.DataBind();
    }

    protected void strAlerta_Refresh(object sender, StoreReadDataEventArgs e)
    {
        recargarGrid();
    }

    [DirectMethod]
    public void accionComando(string command, string id_alerta)
    {
        if (command == "oAlerta")
        {
            X.Msg.Confirm("Confirmación", "¿Desea eliminar la alerta? ", new MessageBoxButtonsConfig
            {
                Yes = new MessageBoxButtonConfig
                {
                    Handler = "App.direct.eliminarAlerta('" + id_alerta + "')",
                    Text = "Si"
                },
                No = new MessageBoxButtonConfig
                {
                    Handler = "",
                    Text = "No"
                }
            }).Show();

        }
    }

    [DirectMethod]
    public void eliminarAlerta(string id_alerta)
    {
        //agregando la cita confirmada a la consulta
        if (objNegocio.setFechaRecepcioAlerta(Convert.ToInt64(id_alerta)) > 0)
        {
            recargarGrid();
        }
        else
        {
            X.Msg.Alert("Mensaje", "No se pudo eliminar").Show();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using capaNegocios;


public partial class Formularios_Confirmacion : System.Web.UI.Page
{
    negocioConfirmacion objNegocio = new negocioConfirmacion();
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
        this.strCitasPorConfirmar.DataSource = objNegocio.getAllCitasPorConfirmar();
        this.strCitasPorConfirmar.DataBind();
    }

    protected void strCitasPorConfirmar_Refresh(object sender, StoreReadDataEventArgs e)
    {
        recargarGrid();
    }

    [DirectMethod]
    public void accionComando(string command, string id_cita, string nombre, string id_cliente)
    {
        if (command == "oConfirmar")
        {
            X.Msg.Confirm("Confirmación", "¿Desea confirmar la Cita de " + nombre + "? ", new MessageBoxButtonsConfig
            {
                Yes = new MessageBoxButtonConfig
                {
                    Handler = "App.direct.confirmarCita('" + id_cita + "','" + id_cliente + "')",
                    Text = "Si"
                },
                No = new MessageBoxButtonConfig
                {
                    Handler = "",
                    Text = "No"
                }
            }).Show();

        }
        else if (command == "oEliminar")
        {
            X.Msg.Confirm("Confirmación", "¿Desea eliminar esta Citade " + nombre + "? ", new MessageBoxButtonsConfig
            {
                Yes = new MessageBoxButtonConfig
                {
                    Handler = "App.direct.eliminarCita('" + id_cita + "','" + id_cliente + "')",
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
    public void confirmarCita(string id_cita, string id_cliente)
    {
        if (objNegocio.setInsertClienteConsulta(Convert.ToInt64(id_cita), Convert.ToInt64(id_cliente)) > 0)
        {
            recargarGrid();
            X.Msg.Alert("Exito", "Sea confirmado.").Show();
        }
        else
        {
            X.Msg.Alert("Mensaje", "Cita no confirmada").Show();
        }
    }

    [DirectMethod]
    public void eliminarCita(string id_cita, string id_cliente)
    {

    }
}
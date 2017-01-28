using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using capaNegocios;

public partial class Vista_Cita : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (!X.IsAjaxRequest)
            {
                clienteAgenda objServicios = new clienteAgenda();
                this.strServicio.DataSource = objServicios.getAllServicios();
                this.strServicio.DataBind();

                CalendarPanel1.EventStore.DataSource = objServicios.getColeccionCitas();
                CalendarPanel1.EventStore.DataBind();
            }
        }
    }

    protected void strMedicoRefresh(object sender, StoreReadDataEventArgs e)
    {
        clienteAgenda objMedicosPorSerivicios = new clienteAgenda();
        this.strMedico.DataSource = objMedicosPorSerivicios.getAllMedicosPorServicio(Convert.ToInt64(cbxServicio.SelectedItem.Value));
        this.strMedico.DataBind();
    }

    protected void btnGenerar_Click(object sender, DirectEventArgs e)
    {
        string data = e.ExtraParams["objCita"];
        clienteAgenda objCita = new clienteAgenda();
        if (objCita.setInsertClienteCita(data) > 0)
        {
            X.Msg.Alert("Exito", "se ha guardado la cita").Show();
        }
        else
        {
            X.Msg.Alert("Mensaje", "No hay disponibiliad en este horario").Show();
        }
    }

    [DirectMethod]
    public void actualizarCalendario()
    {
        this.winRegistroCita.Hide();
        clienteAgenda objServicios = new clienteAgenda();
        CalendarPanel1.EventStore.DataSource = objServicios.getColeccionCitas();
        CalendarPanel1.EventStore.DataBind();
    }
}
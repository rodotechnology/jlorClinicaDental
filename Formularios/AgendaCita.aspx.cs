using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using capaNegocio;

public partial class Vista_Cita : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        clienteAgenda objServicios = new clienteAgenda();
        this.strServicio.DataSource = objServicios.getAllServicios();
        this.strServicio.DataBind();

        this.CalendarPanel1.EventStore = new EventStore { ID = "EventStore1" };
        this.CalendarPanel1.EventStore.Events.AddRange(Data.Events);
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
            this.winRegistroCita.Hide();
            X.Msg.Alert("Exito", "se ha guardado la cita").Show();
        }
    }

    public class Data
    {
        public static EventModelCollection Events
        {
            get
            {
                DateTime now = DateTime.Now.Date;

                return new EventModelCollection {
                    new EventModel
                    {
                        EventId = 1001,
                        CalendarId = 1,
                        Title = "Vacation",
                        StartDate = now.AddDays(-20).AddHours(10),
                        EndDate = now.AddDays(-10).AddHours(15),
                        IsAllDay = false,
                        Notes = "Have fun"
                    },
                    new EventModel
                    {
                        EventId = 1002,
                        CalendarId = 2,
                        Title = "Lunch with Matt",
                        StartDate = now.AddHours(11).AddMinutes(30),
                        EndDate = now.AddHours(13),
                        IsAllDay = false,
                        Location = "Chuy's!",
                        Url = "http://chuys.com",
                        Notes = "Order the queso",
                        Reminder = "15"
                    },
                    new EventModel
                    {
                        EventId = 1003,
                        CalendarId = 3,
                        Title = "Project due",
                        StartDate = now.AddHours(15),
                        EndDate = now.AddHours(15),
                        IsAllDay = false
                    },
                    new EventModel
                    {
                        EventId = 1004,
                        CalendarId = 1,
                        Title = "Sarah's birthday",
                        StartDate = now,
                        EndDate = now,
                        IsAllDay = true,
                        Notes = "Need to get a gift"
                    },
                    new EventModel
                    {
                        EventId = 1005,
                        CalendarId = 2,
                        Title = "A long one...",
                        StartDate = now.AddDays(-12),
                        EndDate = now.AddDays(10).AddSeconds(-1),
                        IsAllDay = true
                    },
                    new EventModel
                    {
                        EventId = 1006,
                        CalendarId = 3,
                        Title = "School holiday",
                        StartDate = now.AddDays(5),
                        EndDate = now.AddDays(7).AddSeconds(-1),
                        IsAllDay = true,
                        Reminder = "2880"
                    },
                    new EventModel
                    {
                        EventId = 1007,
                        CalendarId = 1,
                        Title = "Haircut",
                        StartDate = now.AddHours(9),
                        EndDate = now.AddHours(9).AddMinutes(30),
                        IsAllDay = false,
                        Notes = "Get cash on the way"
                    },
                    new EventModel
                    {
                        EventId = 1008,
                        CalendarId = 3,
                        Title = "An old event",
                        StartDate = now.AddDays(-30),
                        EndDate = now.AddDays(-28),
                        IsAllDay = true,
                        Notes = "Get cash on the way"
                    },
                    new EventModel
                    {
                        EventId = 1009,
                        CalendarId = 2,
                        Title = "Board meeting",
                        StartDate = now.AddDays(-2).AddHours(13),
                        EndDate = now.AddDays(-2).AddHours(18),
                        IsAllDay = false,
                        Location = "ABC Inc.",
                        Reminder = "60"
                    },
                    new EventModel
                    {
                        EventId = 1010,
                        CalendarId = 3,
                        Title = "Jenny's final exams",
                        StartDate = now.AddDays(-2),
                        EndDate = now.AddDays(3).AddSeconds(-1),
                        IsAllDay = true
                    },
                    new EventModel
                    {
                        EventId = 1011,
                        CalendarId = 1,
                        Title = "Movie night",
                        StartDate = now.AddDays(2).AddHours(19),
                        EndDate = now.AddDays(2).AddHours(23),
                        IsAllDay = false,
                        Notes = "Don't forget the tickets!",
                        Reminder = "60"
                    }
                };
            }
        }
    }
}
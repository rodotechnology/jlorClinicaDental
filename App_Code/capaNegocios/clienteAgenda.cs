using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using capaDatos;
using System.Collections;
using Ext.Net;

/// <summary>
/// Descripción breve de clienteAgenda
/// </summary>
public class clienteAgenda
{
    public clienteAgenda()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public ArrayList getAllServicios()
    {
        datosAgenda objServicios = new datosAgenda();
        return objServicios.getServicios();
    }

    public ArrayList getAllMedicosPorServicio(Int64 id_servicio)
    {
        datosAgenda objMedicosPorServicio = new datosAgenda();
        return objMedicosPorServicio.getMedicoPorServicio(id_servicio);
    }

    public Int64 setInsertClienteCita(string Datajson)
    {
        //porceso de generar cliente y cita
        Hashtable row = (Hashtable)JSON.Deserialize(Datajson.ToString(), typeof(Hashtable));
        datosCliente objCliente = new datosCliente();
        Int64 id = objCliente.insertCliente(row["txtNombre"].ToString(), row["txtApellidos"].ToString(), row["txtTelefono"].ToString(), row["txtCorreo"].ToString(), row["txtDui"].ToString());
        Int64 id_cita = 0;
        if (id > 0)
        {
            DateTime hora_fin = Convert.ToDateTime(row["hinicio"].ToString().Substring(0, 5));
            hora_fin = hora_fin.AddMinutes(30);
            datosAgenda objCita = new datosAgenda();
            id_cita = objCita.insertCita(Convert.ToInt64(row["cbxMedico"].ToString()), Convert.ToDateTime(row["finicio"].ToString()), row["hinicio"].ToString().Substring(0, 5), String.Format("{0:t}", hora_fin).Substring(0, 5), Convert.ToInt64(row["cbxServicio"].ToString()), id);

        }
        return id_cita;
    }

    public EventModelCollection getColeccionCitas()
    {
        //proceso de generacion de las citas en el calendario
        datosAgenda objColeccionCitas = new datosAgenda();
        ArrayList registros = objColeccionCitas.getCitas();

        EventModelCollection recopilarEventos = new EventModelCollection();
        List<EventModel> lista = new List<EventModel>();

        foreach (Hashtable row in registros)
        {
            DateTime dt = Convert.ToDateTime(row["dia_cita"].ToString());
            string fechaIni = String.Format("{0} {1}", String.Format("{0:dd/MM/yyyy}", dt), row["hora_inicio"].ToString());
            string fechaFin = String.Format("{0} {1}", String.Format("{0:dd/MM/yyyy}", dt), row["hora_fin"].ToString());
            DateTime fini = Convert.ToDateTime(fechaIni);
            DateTime ffin = Convert.ToDateTime(fechaFin);
            lista.Add(new EventModel
            {
                EventId = Convert.ToInt32(row["id_cita"].ToString()),
                CalendarId = 1,
                Title = "Cita sin confirmar",
                StartDate = fini,
                EndDate = ffin,
                IsAllDay = false
            });
        }
        recopilarEventos.AddRange(lista);

        return recopilarEventos;
    }
}
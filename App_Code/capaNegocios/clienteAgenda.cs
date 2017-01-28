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
    datosAgenda objDatos = new datosAgenda();
    datosAlerta objAlerta = new datosAlerta();
    public clienteAgenda()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public ArrayList getAllServicios()
    {
        return objDatos.getServicios();
    }

    public ArrayList getAllMedicosPorServicio(Int64 id_servicio)
    {
        return objDatos.getMedicoPorServicio(id_servicio);
    }

    public Int64 setInsertClienteCita(string Datajson)
    {
        //porceso de generar cliente y cita
        Hashtable row = (Hashtable)JSON.Deserialize(Datajson.ToString(), typeof(Hashtable));
        datosCliente objCliente = new datosCliente();

        #region
        List<string> listaCitas = objDatos.getEventosRegistrados(Convert.ToDateTime(row["finicio"].ToString()), Convert.ToDateTime(row["finicio"].ToString()), Convert.ToInt64(row["cbxMedico"].ToString()));

        //DateTime hora_fin = Convert.ToDateTime(row["hinicio"].ToString().Replace(" a.m.","").Replace(" p.m.",""));
        DateTime hora_fin = Convert.ToDateTime(row["hinicio"].ToString());
        hora_fin = hora_fin.AddMinutes(30);

        ArrayList proporner = new ArrayList();

        #region primera forma de buscar una igual
        bool ejecutar = false;
        //bool ok = ContainsLoop(ref listaCitas, String.Format("{0}{1}{2}{3}", String.Format("{0:yyyyMMdd}", Convert.ToDateTime(row["finicio"].ToString()).Date), row["hinicio"].ToString().Substring(0, 5).Replace(":", ""), String.Format("{0:t}", hora_fin).Substring(0, 5).Replace(":", ""), row["cbxMedico"].ToString()));
        bool ok = ContainsLoop(ref listaCitas, String.Format("{0}{1}{2}{3}", String.Format("{0:yyyyMMdd}", Convert.ToDateTime(row["finicio"].ToString()).Date), row["hinicio"].ToString().Substring(0, 4).Replace(":", ""), String.Format("{0:t}", hora_fin).Substring(0, 4).Replace(":", ""), row["cbxMedico"].ToString()));
        if (ok)
        {
            //proporner.Add(String.Format("{0}/{1}/{2}", value.Substring(6, 2), value.Substring(4, 2), value.Substring(0, 4)));
        }
        else { ejecutar = true; }
        #endregion

        #region segunda forma de buscar por rangos
        ArrayList encontradas = new ArrayList();
        if (ejecutar)
        {
            encontradas = ContainsRango(ref listaCitas, row["hinicio"].ToString().Substring(0, 4), String.Format("{0:t}", hora_fin).Substring(0, 4));
            if (encontradas.Count == 0) { ejecutar = false; }
        }
        #endregion

        #endregion

        Int64 id_cita = 0;
        if (!ok && !ejecutar)
        {
            Int64 id = objCliente.insertCliente(row["txtNombre"].ToString(), row["txtApellidos"].ToString(), row["txtTelefono"].ToString(), row["txtCorreo"].ToString(), row["txtDui"].ToString());
            if (id > 0)
            {
                #region agreando la cita
                id_cita = objDatos.insertCita(Convert.ToInt64(row["cbxMedico"].ToString()), Convert.ToDateTime(row["finicio"].ToString()), row["hinicio"].ToString().Substring(0, 4), String.Format("{0:t}", hora_fin).Substring(0, 4), Convert.ToInt64(row["cbxServicio"].ToString()), id);
                #endregion
                #region agregar la alerta del modulo cita
                objAlerta.insertAlerta(id_cita, row["txtNombre"].ToString() + ' ' + row["txtApellidos"].ToString());
                #endregion
            }
        }
        return id_cita;
    }

    private static bool ContainsLoop(ref List<string> list, string value)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] == value)
            {
                return true;
            }
        }
        return false;
    }

    private ArrayList ContainsRango(ref List<string> list, string tmHorarioIni, string tmHorarioFin)
    {
        ArrayList encontradas = new ArrayList();
        ArrayList horasforulario = new ArrayList();
        horasforulario.Add(tmHorarioIni);
        horasforulario.Add(tmHorarioFin);
        foreach (string value in list)
        {
            #region bloque inicial A
            int hAIni = int.Parse(value.Substring(8, 2));
            int hAFin = int.Parse(value.Substring(10, 2));
            TimeSpan tini = new TimeSpan(hAIni, hAFin, 0);
            #endregion

            #region bloque final B
            int hBIni = int.Parse(value.Substring(12, 2));
            int hBFin = int.Parse(value.Substring(14, 2));
            TimeSpan tfin = new TimeSpan(hBIni, hBFin, 0);
            #endregion

            foreach (string horabuscada in horasforulario)
            {
                TimeSpan hb = TimeSpan.Parse(horabuscada);
                if (hb >= tini && hb <= tfin)
                {
                    encontradas.Add(String.Format("{0}/{1}/{2}", value.Substring(6, 2), value.Substring(4, 2), value.Substring(0, 4)));
                }
            }
        }
        return encontradas;
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
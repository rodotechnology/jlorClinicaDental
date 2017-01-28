using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using capaDatos;
using System.Collections;
using Ext.Net;
/// <summary>
/// Descripción breve de negocioConfirmacion
/// </summary>
public class negocioConfirmacion
{
    datosConfirmacion objDatos = new datosConfirmacion();
    public negocioConfirmacion()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public ArrayList getAllCitasPorConfirmar()
    {
        return objDatos.getCitasPorConfirmar();
    }

    public Int64 setInsertClienteConsulta(Int64 id_cita, Int64 id_cliente)
    {
        Int64 id = 0;
        //cambiar el tipo cliente de cliente a paciente
        if (objDatos.updateTipoCliente(id_cliente) >= 1)
        {
            //cambiar estado a cita por que fue confirmada
            if (objDatos.updateEstadoConfirmadaCita(id_cita) >= 1)
            {
                ArrayList registros = objDatos.getCitaPorIdCita(id_cita);
                foreach (Hashtable row in registros)
                {
                    id = objDatos.insertConsulta(id_cita, Convert.ToInt64(row["id_medico"].ToString()), id_cliente, Convert.ToDateTime(row["dia_cita"].ToString()), Convert.ToDateTime(row["dia_cita"].ToString()), row["hora_inicio"].ToString().Substring(0, 5), row["hora_fin"].ToString().Substring(0, 5));
                }
            }
        }
        return id;
    }
}
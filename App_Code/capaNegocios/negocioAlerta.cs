using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using capaDatos;
using System.Collections;
using Ext.Net;

/// <summary>
/// Descripción breve de negocioAlerta
/// </summary>
public class negocioAlerta
{
    datosAlerta objDatos = new datosAlerta();
    public negocioAlerta()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public ArrayList getAllAlertas()
    {
        return objDatos.getDataAlertas();
    }

    public Int16 setFechaRecepcioAlerta(Int64 id_alerta)
    {
        Int16 id = 0;
        //cambiar la fecha de la alerta cuando fue vista
        if (objDatos.updateVistoAlerta(id_alerta) >= 1)
        {
            id = 1;
        }
        return id;
    }
}
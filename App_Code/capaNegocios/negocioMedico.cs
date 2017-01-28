using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using capaDatos;
using System.Collections;
using Ext.Net;
/// <summary>
/// Descripción breve de negocioMedico
/// </summary>
public class negocioMedico
{
    datosMedico objDatos = new datosMedico();
    public negocioMedico()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public ArrayList getAllEspecialidad()
    {
        return objDatos.getEspecialidad();
    }

    public ArrayList getAllHorarios()
    {
        return objDatos.getHorarios();
    }

    public ArrayList getAllMedicos()
    {
        return objDatos.getMedicos();
    }
}
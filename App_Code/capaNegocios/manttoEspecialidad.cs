﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using capaDatos;
using System.Collections;
using Ext.Net;


/// <summary>
/// Descripción breve de manttoEspecialidad
/// </summary>
namespace capaNegocios
{
    public class manttoEspecialidad
    {
        datosEspecialidad objDatos = new datosEspecialidad();
        public manttoEspecialidad()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        public void saveItems(string nombreS, string idServicio)
        {
            if (!nombreS.Equals(""))
            {
                objDatos.dbSaveItems(nombreS, idServicio);
            }

        }

        public Array selectAllItems()
        {
            return objDatos.dbSelectAllItems();
        }

        public void deleteItems(string idEspecialidad)
        {
            if (!idEspecialidad.Equals(""))
            {
                objDatos.dbDeleteItems(idEspecialidad);
                
            }
        }

        public void updateItmes(string idServicios, string nombre, string id_especialidad)
        {
            if (!idServicios.Equals("") && !nombre.Equals("") && !id_especialidad.Equals(""))
            {
                objDatos.dbUpdateData(idServicios, nombre, id_especialidad);
            }
        }
    }
}
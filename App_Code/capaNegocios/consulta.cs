﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using capaDatos;
/// <summary>
/// Descripción breve de consulta
/// </summary>
/// 
namespace capaNegocios
{
    public class consulta
    {
        datosDiente objDatos = new datosDiente();
        datosConsulta objDatosConsulta = new datosConsulta();
        public consulta()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }
        public Array selectAllItems(string filtro)
        {
            return objDatos.dbSelectFiltroItems(filtro);
        }

        public Array selectAllItemsConsulta() {
            return objDatosConsulta.dbSelectAllItemsConsulta();
        }
        public void finalizarConsulta(string idConsulta) {
            objDatosConsulta.dbFinalizarConsulta(idConsulta);
        }
    }
}
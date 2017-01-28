using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using Ext.Net;
using capaDatos;

/// <summary>
/// Descripción breve de DetalleConsulta
/// </summary>
namespace capaNegocios
{
    public class DetalleConsulta
    {
        datosDetalleConsulta objDetalleConsulta = new datosDetalleConsulta();
        public DetalleConsulta()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }
        public void saveItemsDetalleConsulta(string id_consulta, string id_servicio, string id_pieza, string allazgo)
        {
            if (!id_consulta.Equals("") && !id_servicio.Equals("") && !id_pieza.Equals("") && !allazgo.Equals(""))
            {
                objDetalleConsulta.dbSaveItems( id_consulta, id_servicio,  id_pieza,  allazgo);
            }

        }

        public Array selectAllItems(string idConsulta)
        {
            return objDetalleConsulta.dbSelectAllItems(idConsulta);
        }

        public void deleteItems(string idDetalleConsulta)
        {
            if (!idDetalleConsulta.Equals(""))
            {
                objDetalleConsulta.dbDeleteItems(idDetalleConsulta);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using capaDatos;
using System.Collections;




/// <summary>
/// Descripción breve de manttoServicios
/// </summary>
namespace capaNegocios
{
    public class manttoServicios
    {
        datosServicios objDatos = new datosServicios();
        public manttoServicios()
        {

        }
        public void saveItems(string nombreS, string costoS)
        {
            if (!nombreS.Equals("") && !costoS.Equals(""))
            {
                objDatos.dbSaveItems(nombreS, costoS);
            }

        }

        public Array selectAllItems()
        {
            return objDatos.dbSelectAllItems();
        }

        public void deleteItems(string idServicio)
        {
            if (!idServicio.Equals(""))
            {
                objDatos.dbDeleteItems(idServicio);
            }
        }

        public void updateItmes(string idServicios, string nombre, string costo)
        {
            if (!idServicios.Equals("") && !nombre.Equals("") && !costo.Equals(""))
            {
                objDatos.dbUpdateData(idServicios, nombre, costo);
            }
        }

    }
}
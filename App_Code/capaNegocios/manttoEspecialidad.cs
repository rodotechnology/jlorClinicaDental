using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using capaDatos;
using System.Collections;


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

        public void saveItems(string nombreS)
        {
            if (!nombreS.Equals(""))
            {
                objDatos.dbSaveItems(nombreS);
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
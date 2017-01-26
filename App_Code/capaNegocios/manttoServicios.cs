using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using capaDatos;
using System.Collections;




/// <summary>
/// Descripción breve de manttoServicios
/// </summary>
namespace capaNegocio
{
    public class manttoServicios
    {
        public manttoServicios()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }
        public void saveItems(string nombreS, string costoS)
        {
            if (!nombreS.Equals("") && !costoS.Equals(""))
            {
                datosServicios obj = new datosServicios();
                obj.dbSaveItems(nombreS, costoS);
            }
            else
            {

            }
        }

        public ArrayList selectAllItems()
        {
            datosServicios objSelect = new datosServicios();
            return objSelect.dbSelectAllItems();
        }

    }
}
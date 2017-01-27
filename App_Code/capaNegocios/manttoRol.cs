using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using capaDatos;

/// <summary>
/// Descripción breve de manttoRol
/// </summary>
namespace capaNegocio
{
    public class manttoRol
    {
        public manttoRol()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        public ArrayList getAllRoles()
        {
            datosRol objRoles = new datosRol();
            return objRoles.getRoles();
        }

        public string getPermissionData(string idRol)
        {
            string recordset = string.Empty;
            datosRol objRoles = new datosRol();

            foreach(Hashtable record in objRoles.getPermissionData(idRol))
            {
                var pupu = 0;
            }

            /*for (int i =0; i < objRoles.getPermissionData(idRol).Count; i++)
            {
               var items = objRoles.getPermissionData(idRol)[i];
                records = items.ToString();
            }*/
            return recordset;
        }

        public bool validatePermission(string txtNombreRol, string txtIdRolA, string txtNombreRolA, string type)
        {
            datosRol objRoles = new datosRol();
            return objRoles.validateRol(txtNombreRol,txtIdRolA,txtNombreRolA,type);
        }
    }
}
using System.Collections;
using capaDatos;

/// <summary>
/// Descripción breve de manttoRol
/// </summary>
namespace capaNegocios
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
                recordset = "{idRolA: '" + record["id_rolA"].ToString() + "', rolA: '" + record["rolA"] + "'}";
            }

            return recordset;
        }

        public bool validatePermission(string txtNombreRol, string txtIdRolA, string txtNombreRolA, string type)
        {
            datosRol objRoles = new datosRol();
            return objRoles.validateRol(txtNombreRol,txtIdRolA,txtNombreRolA,type);
        }

        public bool setRol(string txtNombreRol)
        {
            datosRol objRoles = new datosRol();
            return objRoles.setRol(txtNombreRol);
        }

        public bool updateRol(string txtIdRolA, string txtNombreRolA)
        {
            datosRol objRoles = new datosRol();
            return objRoles.updateRol(txtIdRolA, txtNombreRolA);
        }
    }
}
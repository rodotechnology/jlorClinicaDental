using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using capaNegocio;

public partial class Formularios_manttoRol : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            getRoles();
        }
    }

    protected void MyData_Refresh(object sender, StoreReadDataEventArgs e)
    {
        getRoles();
    }

    public void getRoles()
    {
        manttoRol Roles = new manttoRol();

        this.strRols.DataSource = Roles.getAllRoles();
        this.strRols.DataBind();
    }

    [DirectMethod]
    public void accionComando(string command, string identificador)
    {
        if (command == "Editar")
        {
            manttoRol Roles = new manttoRol();
            Roles.getPermissionData(identificador);

            //Hashtable row = (Hashtable)JSON.Deserialize(Datajson.ToString(), typeof(Hashtable));
                //txtIdRolA.Text = row["id_rolA"].ToString();
                //txtNombreRolA.Text = row["rolA"].ToString();
            winEditar.Show();
        }
    }
}
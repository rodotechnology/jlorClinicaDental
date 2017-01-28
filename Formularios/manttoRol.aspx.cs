using System;
using System.Collections;
using Ext.Net;
using capaNegocios;
using System.Data.SqlClient;

public partial class Formularios_manttoRol : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            getRoles();
        }
    }

    #region Metodos
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
    #endregion
    
    #region Metodos directos
    [DirectMethod]
    public void accionComando(string command, string identificador)
    {
        if (command == "Editar")
        {
            manttoRol Roles = new manttoRol();

            Hashtable row = (Hashtable)JSON.Deserialize(Roles.getPermissionData(identificador), typeof(Hashtable));
            txtIdRolA.Text = row["idRolA"].ToString();
            txtNombreRolA.Text = row["rolA"].ToString();
            winEditar.Show();
        }
    }

    [DirectMethod]
    public void newPermission()
    {
        manttoRol Roles = new manttoRol();
        if(!Roles.validatePermission(txtNombreRol.Text, txtIdRolA.Text, txtNombreRolA.Text,"1"))
        {            
            if (Roles.setRol(txtNombreRol.Text))
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Confirmación",
                    Message = "Rol registrado satisfactoriamente!!",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "INFO"),
                    AnimEl = this.winCrear.ClientID
                });

                this.FormPanel1.Reset();
                this.winCrear.Hide();
                getRoles();
            }
            else
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Validación",
                    Message = "No se pudo registrar el rol!!",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "ERROR"),
                    AnimEl = this.winCrear.ClientID
                });
            }
        }
        else
        {
            X.Msg.Show(new MessageBoxConfig
            {
                Title = "Validación",
                Message = "Existe un Rol registrado con ese Nombre!!",
                Buttons = MessageBox.Button.OK,
                Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING"),
                AnimEl = this.winCrear.ClientID
            });
        }
    }

    [DirectMethod]
    public void editPermission()
    {
        manttoRol Roles = new manttoRol();
        if (!Roles.validatePermission(txtNombreRol.Text, txtIdRolA.Text, txtNombreRolA.Text, "2"))
        {
            if (Roles.updateRol(txtIdRolA.Text, txtNombreRolA.Text))
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Confirmación",
                    Message = "Rol actualizado satisfactoriamente!!",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "INFO"),
                    AnimEl = this.winCrear.ClientID
                });

                this.FormPanel2.Reset();
                this.winEditar.Hide();
                getRoles();
            }
            else
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Validación",
                    Message = "No se pudo registrar el rol!!",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "ERROR"),
                    AnimEl = this.winCrear.ClientID
                });
            }
        }
        else
        {
            X.Msg.Show(new MessageBoxConfig
            {
                Title = "Validación",
                Message = "Existe un Rol registrado con ese Nombre!!",
                Buttons = MessageBox.Button.OK,
                Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING"),
                AnimEl = this.winCrear.ClientID
            });
        }
    }
    #endregion
}
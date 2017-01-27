using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using capaNegocios;


public partial class Formularios_servicios : System.Web.UI.Page
{
    manttoServicios objNegocio = new manttoServicios();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            SelectRegistros();
        }
    }

    [DirectMethod]
    public void msgConfirmarSave()
    {
        if (!txtservicios.Text.Equals("") && !txtcosto.Text.Equals(""))
        {
            X.Msg.Confirm("Confirmar", "¿Desea Eliminar el registro?", new MessageBoxButtonsConfig
            {
                Yes = new MessageBoxButtonConfig
                {
                    Handler = "App.direct.guardar()",
                    Text = "Sí"
                },
                No = new MessageBoxButtonConfig
                {
                    Text = "No",

                }
            }).Show();
        }
        else
        {
            X.Msg.Alert("Error", "Verifique que no hayan campos vacios.").Show();
        }
    }

    [DirectMethod]
    public void guardar()
    {
        //manttoServicios obj = new manttoServicios();
        objNegocio.saveItems(this.txtservicios.Text, this.txtcosto.Text);
        SelectRegistros();
        limpiarCamposForm();
        this.txtservicios.Focus();
        X.Msg.Alert("Exito", "Sea guardado el regitro.").Show();
    }



    [DirectMethod]
    public void Acciones(string command, string idRegistro, string nombre, string costo)
    {
        if (command.Equals("modificar"))
        {
            this.txtservicios.Text = nombre;
            this.txtcosto.Text = costo;
            this.txtIDServicio.Text = idRegistro;

            this.btnGuardar.Hidden = true;
            this.btnUpdate.Hidden = false;
        }
        else
        {
            X.Msg.Confirm("Confirmar", "¿Desea Eliminar el registro?", new MessageBoxButtonsConfig
            {
                Yes = new MessageBoxButtonConfig
                {
                    Handler = "App.direct.getEliminarDatos(" + idRegistro + ")",
                    Text = "Sí"
                },
                No = new MessageBoxButtonConfig
                {
                    Text = "No",

                }
            }).Show();
        }
    }

    [DirectMethod]
    public void getEliminarDatos(string idRegistro)
    {
        objNegocio.deleteItems(idRegistro);
        SelectRegistros();
        X.Msg.Alert("Exito", "Sea eliminado el regitro.").Show();
    }

    [DirectMethod]
    public void msgConfirmarModificacion()
    {
        if (!txtIDServicio.Text.Equals("") && !txtcosto.Text.Equals(""))
        {
            X.Msg.Confirm("Confirmar", "¿Desea modificar el registro?", new MessageBoxButtonsConfig
            {
                Yes = new MessageBoxButtonConfig
                {
                    Handler = "App.direct.getModificarItems()",
                    Text = "Sí"
                },
                No = new MessageBoxButtonConfig
                {
                    Text = "No",

                }
            }).Show();
        }
        else
        {
            X.Msg.Alert("Error", "Verifique que no hayan campos vacios.").Show();
        }
    }

    [DirectMethod]
    public void getModificarItems()
    {
        objNegocio.updateItmes(txtIDServicio.Text, txtservicios.Text, txtcosto.Text);
        this.btnGuardar.Hidden = false;
        this.btnUpdate.Hidden = true;
        limpiarCamposForm();
        this.txtservicios.Focus();
        //SelectRegistros();
        X.Msg.Alert("Exito", "Sea actualizado el regitro.").Show();
    }

    [DirectMethod]
    public void SelectRegistros()
    {
        //manttoServicios objSelect = new manttoServicios();
        //Cargando el grid de los valores de la tabla
        Store1.DataSource = objNegocio.selectAllItems();
        Store1.DataBind();
    }

    public void limpiarCamposForm()
    {

        //Limpiando los campos del formulario
        this.txtIDServicio.Reset();
        this.txtservicios.Reset();
        this.txtcosto.Reset();
    }

}
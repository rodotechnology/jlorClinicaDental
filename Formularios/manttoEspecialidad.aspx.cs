using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using capaNegocios;


public partial class Formularios_MattoEspecialidad : System.Web.UI.Page
{
    manttoEspecialidad objNegocio = new manttoEspecialidad();
    manttoServicios objNegocioServicio = new manttoServicios();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            SelectRegistros();
            getServicios();
        }

    }

    [DirectMethod]
    public void mgsConfirmarSave()
    {
        //Validando que los campos no se envien vacios
        if (!txtNombre.Text.Equals("") && !cbxServicios.SelectedItem.Value.Equals(""))
        {

            X.Msg.Confirm("Confirmar", "¿Desea guardar el registro?", new MessageBoxButtonsConfig
            {
                Yes = new MessageBoxButtonConfig
                {
                    //LLamando al metodo para guardar el registro
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

        //Enviando los datos para guardar
        objNegocio.saveItems(txtNombre.Text, cbxServicios.SelectedItem.Value);
        SelectRegistros();
        limpiandoCampos();
        this.txtNombre.Focus();
        X.Msg.Alert("Exito", "Sea guardado el regitro.").Show();

    }



    [DirectMethod]
    public void Acciones(string command, string idEspecialidad, string nombre, string idServicios)
    {
        if (command.Equals("modificar"))
        {
            this.txtIdEspecialidad.Text = idEspecialidad;
            this.txtNombre.Text = nombre;
            this.cbxServicios.SetValue(idServicios);

            this.btnGuardar.Hidden = true;
            this.btnUpdate.Hidden = false;
        }
        else if (command.Equals("Eliminar"))
        {

            X.Msg.Confirm("Confirmar", "¿Desea Eliminar el registro?", new MessageBoxButtonsConfig
            {
                Yes = new MessageBoxButtonConfig
                {
                    Handler = "App.direct.sendatos(" + idEspecialidad + ")",
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
    public void sendatos(string idEspecialidad)
    {
        objNegocio.deleteItems(idEspecialidad);
        SelectRegistros();

    }

    [DirectMethod]
    public void msgConfirmarModificacion()
    {
        if (!txtIdEspecialidad.Text.Equals("") && !cbxServicios.SelectedItem.Value.Equals(""))
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
        objNegocio.updateItmes(this.txtIdEspecialidad.Text, this.txtNombre.Text, cbxServicios.SelectedItem.Value);
        this.btnGuardar.Hidden = false;
        this.btnUpdate.Hidden = true;
        limpiandoCampos();
        this.txtNombre.Focus();
        SelectRegistros();
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

    public void getServicios()
    {
        StoreServicios.DataSource = objNegocioServicio.selectAllItems();
        StoreServicios.DataBind();
    }

    public void limpiandoCampos()
    {
        //Limpiando los campos del formulario
        this.txtNombre.Reset();
        this.cbxServicios.Reset();
    }



}

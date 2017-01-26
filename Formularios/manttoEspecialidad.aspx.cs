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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            SelectRegistros();
        }

    }

    [DirectMethod]
    public void guardar()
    {
        //manttoServicios obj = new manttoServicios();
        objNegocio.saveItems(txtNombre.Text);
        SelectRegistros();
        this.txtNombre.Focus();
        X.Msg.Alert("Exito", "Sea guardado el regitro.").Show();
    }



    [DirectMethod]
    public void Acciones(string command, string idRegistro, string nombre, string costo)
    {
        if (command.Equals("modificar"))
        {
            //this.txtNombre.Text = nombre;
            //this.cbxServicios.SetValue(;
            //this.txtIDServicio.Text = idRegistro;

            //this.btnGuardar.Hidden = true;
            //this.btnUpdate.Hidden = false;
        }
        else
        {
            objNegocio.deleteItems(idRegistro);
            SelectRegistros();
            X.Msg.Alert("Exito", "Sea eliminado el regitro.").Show();
        }
    }

    [DirectMethod]
    public void getModificarItems()
    {
        objNegocio.updateItmes(this.txtIdEspecialidad.Text, this.txtNombre.Text);
        this.btnGuardar.Hidden = false;
        this.btnUpdate.Hidden = true;
        this.txtNombre.Focus();
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
}

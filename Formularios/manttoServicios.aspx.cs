using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using capaNegocio;


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
    public void guardar(string txtNombre, string txtCosto)
    {
        //manttoServicios obj = new manttoServicios();
        objNegocio.saveItems(txtNombre, txtCosto);
        SelectRegistros();
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
            objNegocio.deleteItems(idRegistro);
            SelectRegistros();
            X.Msg.Alert("Exito", "Sea eliminado el regitro.").Show();
        }
    }

    [DirectMethod]
    public void getModificarItems()
    {
        objNegocio.updateItmes(txtIDServicio.Text, txtservicios.Text, txtcosto.Text);
        this.btnGuardar.Hidden = false;
        this.btnUpdate.Hidden = true;
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

}
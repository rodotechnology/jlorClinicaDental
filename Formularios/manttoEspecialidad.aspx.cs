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
    public void guardar()
    {
        //manttoServicios obj = new manttoServicios();
        objNegocio.saveItems(txtNombre.Text, cbxServicios.SelectedItem.Value);
        SelectRegistros();
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
            //this.txtNombre.Text = nombre;
            //this.cbxServicios.SetValue(;
            //this.txtIDServicio.Text = idRegistro;

            //this.btnGuardar.Hidden = true;
            //this.btnUpdate.Hidden = false;
        }
        else if(command.Equals("Eliminar"))
        {
            objNegocio.msgConfirmacion(idEspecialidad);
            SelectRegistros();
            X.Msg.Alert("Exito", "Sea eliminado el regitro.").Show();
        }
    }

    [DirectMethod]
    public void getModificarItems()
    {
        //objNegocio.updateItmes(this.txtIdEspecialidad.Text, this.txtNombre.Text);
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

    public void getServicios() {
        StoreServicios.DataSource = objNegocioServicio.selectAllItems();
        StoreServicios.DataBind();
    }
}

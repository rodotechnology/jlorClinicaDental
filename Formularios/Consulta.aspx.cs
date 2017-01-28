using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using capaNegocios;
using Ext.Net;


public partial class Formularios_frmConsulta : System.Web.UI.Page
{
    manttoServicios objNegocioServicio = new manttoServicios();
    consulta objConsulta = new consulta();
    DetalleConsulta objDetalleConsulta = new DetalleConsulta();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            getServicios();
            getConsultasEnProcesos();
        }

    }
    public void getServicios()
    {
        StoreServicios.DataSource = objNegocioServicio.selectAllItems();
        StoreServicios.DataBind();
    }

    [DirectMethod]
    public void getDientes(string idEmisferio)
    {
        Store2.DataSource = objConsulta.selectAllItems(idEmisferio);
        Store2.DataBind();
    }

    [DirectMethod]
    public void getConsultasEnProcesos()
    {
        StoreConsulta.DataSource = objConsulta.selectAllItemsConsulta();
        StoreConsulta.DataBind();
    }

    [DirectMethod]
    public void Acciones(string comand, string idConsulta)
    {
        if (comand.Equals("AtenderConsulta"))
        {

            this.txtIdConsulta.Text = idConsulta;
            this.WinFormConsulta.Show();
        }
    }

    [DirectMethod]
    public void AgregarDetalleConsulta()
    {
        try
        {
            //Guardando en la tabla detalle consulta
            objDetalleConsulta.saveItemsDetalleConsulta(txtIdConsulta.Text, cbxServicios.SelectedItem.Value, cbxPiezaDentales.SelectedItem.Value, txtObservaciones.Text);
            //Cargando el detalle de la consulta
            StoreDetalleConsulta.DataSource = objDetalleConsulta.selectAllItems(txtIdConsulta.Text);
            StoreDetalleConsulta.DataBind();
            //Limpiando Formulario
            limpiarFormulario();
            X.Msg.Alert("Exito", "Sea agrego al  detalle de la consulta").Show();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Error", "No se puede ingresar el detalle de la consulta").Show();
        }
    }

    [DirectMethod]
    public void msgConfirmacionEliminacion(string idDetalleConsulta)
    {
        X.Msg.Confirm("Confirmar", "¿Desea Eliminar el registro?", new MessageBoxButtonsConfig
        {
            Yes = new MessageBoxButtonConfig
            {
                Handler = "App.direct.EliminarDetalleConsulta(" + idDetalleConsulta + ")",
                Text = "Sí"
            },
            No = new MessageBoxButtonConfig
            {
                Text = "No",

            }
        }).Show();
    }

    [DirectMethod]
    public void EliminarDetalleConsulta(string idDetalleConsulta)
    {
        objDetalleConsulta.deleteItems(idDetalleConsulta);
        //Cargando el detalle de la consulta
        StoreDetalleConsulta.DataSource = objDetalleConsulta.selectAllItems(txtIdConsulta.Text);
        StoreDetalleConsulta.DataBind();
    }

    [DirectMethod]
    public void msgConfirmacionFinalizar()
    {
        X.Msg.Confirm("Confirmar", "¿Desea Eliminar el registro?", new MessageBoxButtonsConfig
        {
            Yes = new MessageBoxButtonConfig
            {
                Handler = "App.direct.FinalizarConsulta(" + txtIdConsulta.Text + ")",
                Text = "Sí"
            },
            No = new MessageBoxButtonConfig
            {
                Text = "No",

            }
        }).Show();
    }
    [DirectMethod]
    public void FinalizarConsulta(string idConsulta)
    {
        objConsulta.finalizarConsulta(idConsulta);
        getConsultasEnProcesos();
        this.WinFormConsulta.Hidden = true;
    }
    public void limpiarFormulario()
    {
        txtObservaciones.Reset();
        cbxDentincion.Reset();
        cbxPiezaDentales.Reset();
        cbxServicios.Reset();
    }




}
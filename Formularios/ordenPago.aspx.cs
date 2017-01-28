using System;
using System.Collections;
using Ext.Net;
using capaNegocios;

public partial class Formularios_ordenPago : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            ResourceManager1.AddScript("setFormat();");
            getPendientesPago();
        }
    }

    public void getPendientesPago()
    {
        ordenPago Pagos = new ordenPago();
        this.strPagos.DataSource = Pagos.getAllPendientesPago();
        this.strPagos.DataBind();
    }

    public void obtenerFactura(string id_consulta)
    {
        ordenPago orden = new ordenPago();
        orden.obtenerFactura(id_consulta);
        Hashtable encabezado = orden.getEncabezado();

        strDetalleFactura.DataSource = orden.getDetalle();
        strDetalleFactura.DataBind();

        txtCliente.SetText(encabezado["cliente"].ToString());
        txtMedico.SetText(encabezado["medico"].ToString());
        txtFecha.SetValue(encabezado["fecha"].ToString());
        hdnIdConsulta.SetText(id_consulta);
    }

    [DirectMethod]
    public void accionComando(string command, string identificador)
    {
        if (command == "Facturar")
        {
            obtenerFactura(identificador);
            winFactura.Show();
        }
    }

    [DirectMethod]
    public void setFactura()
    {
        string idConsulta = hdnIdConsulta.Text;
        ordenPago Pago = new ordenPago();
        if (Pago.setFactura(idConsulta))
        {
            X.Msg.Show(new MessageBoxConfig
            {
                Title = "Confirmación",
                Message = "Factura generada satisfactoriamente!!",
                Buttons = MessageBox.Button.OK,
                Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "INFO"),
                AnimEl = this.winFactura.ClientID
            });

            this.winFactura.Hide();
            getPendientesPago();
        }
        else
        {
            X.Msg.Show(new MessageBoxConfig
            {
                Title = "Validación",
                Message = "No se pudo registrar el pago!!",
                Buttons = MessageBox.Button.OK,
                Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "ERROR"),
                AnimEl = this.winFactura.ClientID
            });
        }
    }
}
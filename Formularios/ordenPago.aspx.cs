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
            ordenPago Pagos = new ordenPago();
            this.strPagos.DataSource = Pagos.getAllPendientesPago();
            this.strPagos.DataBind();
        }
    }

    public void obtenerFactura(string id_consulta)
    {
        datosPago factura = new datosPago(id_consulta);

        Hashtable encabezado = factura.getEncabezado();
        strDetalleFactura.DataSource = factura.getDetalle();
        strDetalleFactura.DataBind();

        txtCliente.SetText(encabezado["cliente"].ToString());
        txtMedico.SetText(encabezado["medico"].ToString());
        txtFecha.SetText(encabezado["fecha"].ToString());


    }
}
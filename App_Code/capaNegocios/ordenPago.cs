using System.Collections;
using capaDatos;

/// <summary>
/// Descripción breve de ordenPago
/// </summary>
namespace capaNegocios
{
    public class ordenPago
    {
        public ordenPago()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        public ArrayList getAllPendientesPago()
        {
            datosPago objPagos = new datosPago();
            return objPagos.getPendientesPago();
        }

        public void obtenerFactura(string id_consulta)
        {
            datosPago factura = new datosPago(id_consulta);

            /*Hashtable encabezado = factura.getEncabezado();
            strDetalleFactura.DataSource = factura.getDetalle();
            strDetalleFactura.DataBind();

            txtCliente.SetText(encabezado["cliente"].ToString());
            txtMedico.SetText(encabezado["medico"].ToString());
            txtFecha.SetText(encabezado["fecha"].ToString());*/


        }
    }
}
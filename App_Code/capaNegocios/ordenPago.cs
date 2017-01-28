using System;
using System.Collections;
using capaDatos;


/// <summary>
/// Descripción breve de ordenPago
/// </summary>
namespace capaNegocios
{
    public class ordenPago
    {

        Hashtable encabezado = new Hashtable();
        Array detalle = null;

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
            datosPago factura = new datosPago();
            Hashtable datos = factura.datosFactura(id_consulta);


            encabezado = (Hashtable)datos["encabezado"];
            detalle = (Array)datos["detalle"];
            /*strDetalleFactura.DataSource = factura.getDetalle();
            strDetalleFactura.DataBind();

            txtCliente.SetText(encabezado["cliente"].ToString());
            txtMedico.SetText(encabezado["medico"].ToString());
            txtFecha.SetText(encabezado["fecha"].ToString());*/


        }


        public Hashtable getEncabezado()
        {
            return encabezado;
        }

        public Array getDetalle()
        {
            return detalle;
        }

        public bool setFactura(string IdConsulta)
        {
            datosPago objPago = new datosPago();            
            return objPago.setFactura(IdConsulta);
        }
    }
}

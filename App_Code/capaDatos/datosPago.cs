using System;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de datosPago
/// </summary>
namespace capaDatos
{
    public class datosPago
    {
        public datosPago()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //getPendientesPago
        }

        public ArrayList getPendientesPago()
        {
            ArrayList records = new ArrayList();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString);
            string sql = "SELECT CLIENTE.nombre, CLIENTE.apellidos, FACTURA.monto, FACTURA.id_factura FROM CLIENTE INNER JOIN FACTURA ON CLIENTE.id_cliente = FACTURA.id_cliente WHERE (FACTURA.fecha_factura = GETDATE()) AND (FACTURA.estado = 0)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader mydr = null;
            try
            {
                conn.Open();
                mydr = cmd.ExecuteReader();
                if (mydr.HasRows)
                {
                    while (mydr.Read())
                    {
                        records.Add(new { paciente = mydr["nombre"].ToString() + " "+ mydr["apellidos"].ToString(), monto = mydr["monto"].ToString(), factura = mydr["id_factura"].ToString() });
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (mydr != null) { mydr.Close(); mydr.Dispose(); cmd.Dispose(); }

                if (conn != null) { conn.Close(); conn.Dispose(); }
            }
            return records;
        }
    }
}
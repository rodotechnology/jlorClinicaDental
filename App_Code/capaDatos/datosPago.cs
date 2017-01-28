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
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd;
        SqlDataReader dr;

        Hashtable encabezado = new Hashtable();
        Array detalle = null;

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
                        records.Add(new { paciente = mydr["nombre"].ToString() + " " + mydr["apellidos"].ToString(), monto = mydr["monto"].ToString(), factura = mydr["id_factura"].ToString() });
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


        public datosPago(string idconsulta)
        {
            try
            {
                encabezado = new Hashtable();

                conn.ConnectionString = ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString;
                conn.Open();
                string sql = "SELECT cliente,medico, fecha_fin from consulta,medico,cliente where consulta.id_cliente=cliente.id_cliente and consulta.id_medico=medico.id_medico and consulta.id_consulta=@idconsulta";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idconsulta", idconsulta);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    encabezado.Add("cliente", dr["cliente"]);
                    encabezado.Add("medico", dr["medico"]);
                    encabezado.Add("fecha", dr["fecha_fin"]);
                }

                dr.Close(); cmd.Dispose();


                ArrayList record = new ArrayList();
                sql = "select servicios.id_servicio, nombre, costo from servicios,detalle_consulta where servicios.id_servicio=detalle_consulta.id_servicio and detalle_consulta.id_consulta=@idconsulta";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idconsulta", idconsulta);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var htable = new { id_servicio = dr["id_servicio"].ToString(), nombre = dr["nombre"].ToString(), costo = dr["costo"].ToString() };
                        record.Add(htable);
                    }
                }
                dr.Close(); dr.Dispose(); cmd.Dispose();
                detalle = record.ToArray();

                //Cierre de Conexiones
                conn.Close(); conn.Dispose();
            }
            catch (Exception ex)
            {
            }
        }

        public Hashtable getEncabezado()
        {
            return encabezado;
        }

        public Array getDetalle()
        {
            return detalle;
        }
    }
}
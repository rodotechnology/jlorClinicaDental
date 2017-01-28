using System;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;

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
            //string sql = "SELECT CLIENTE.nombre, CLIENTE.apellidos, FACTURA.monto, FACTURA.id_factura FROM CLIENTE INNER JOIN FACTURA ON CLIENTE.id_cliente = FACTURA.id_cliente WHERE (FACTURA.fecha_factura = GETDATE()) AND (FACTURA.estado = 0)";
            string sql = "SELECT CONSULTA.id_consulta, CLIENTE.nombre AS ncliente, CLIENTE.apellidos AS acliente, MEDICO.nombre AS nmedico, MEDICO.apellidos AS amedico, CONSULTA.fecha_fin, SUM(SERVICIOS.costo) AS monto FROM CONSULTA INNER JOIN CLIENTE ON CONSULTA.id_cliente = CLIENTE.id_cliente INNER JOIN MEDICO ON CONSULTA.id_medico = MEDICO.id_medico INNER JOIN DETALLE_CONSULTA ON CONSULTA.id_consulta = DETALLE_CONSULTA.id_consulta INNER JOIN SERVICIOS ON DETALLE_CONSULTA.id_servicio = SERVICIOS.id_servicio WHERE(CONSULTA.estado = 1) GROUP BY CONSULTA.id_consulta, CLIENTE.nombre, MEDICO.nombre, CONSULTA.fecha_fin, CLIENTE.apellidos, MEDICO.apellidos";
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
                        records.Add(new { paciente = mydr["ncliente"].ToString() + " " + mydr["acliente"].ToString(), monto = mydr["monto"].ToString(), consulta = mydr["id_consulta"].ToString() });
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


        public Hashtable datosFactura(string idconsulta)
        {
            Hashtable r = new Hashtable();
            Hashtable encabezado = new Hashtable();
            ArrayList record = new ArrayList();

            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString;
                conn.Open();
                string sql = "SELECT cliente.nombre +' '+ cliente.apellidos as cliente,medico.nombre +' '+ medico.apellidos as medico, fecha_fin from consulta,medico,cliente where consulta.id_cliente=cliente.id_cliente and consulta.id_medico=medico.id_medico and consulta.id_consulta=@idconsulta";
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

                sql = "select servicios.id_servicio, nombre, costo from servicios,detalle_consulta where servicios.id_servicio=detalle_consulta.id_servicio and detalle_consulta.id_consulta=@idconsulta";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idconsulta", idconsulta);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var htable = new { id_servicio = dr["id_servicio"].ToString(), nombre = dr["nombre"].ToString(), cantidad = 1, costo = dr["costo"].ToString() };
                        record.Add(htable);
                    }
                }
                dr.Close(); dr.Dispose(); cmd.Dispose();

                r.Add("encabezado", encabezado);
                r.Add("detalle", record.ToArray());

                //Cierre de Conexiones
                conn.Close(); conn.Dispose();
            }
            catch (Exception ex)
            {
            }
            return r;
        }

        public bool setFactura(string IdConsulta)
        {
            bool ok = false;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString;
            try
            {
                conn.Open();
                SqlCommand cmd;

                string updateRol = "UPDATE consulta SET estado = 2 WHERE id_consulta = @id_consulta";
                cmd = new SqlCommand(updateRol, conn);

                cmd.Parameters.AddWithValue("@id_consulta", Convert.ToInt64(IdConsulta));

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                ok = true;
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return ok;
        }
    }
}
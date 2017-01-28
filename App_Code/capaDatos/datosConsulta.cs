using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Ext.Net;
using System.Configuration;
using System.Collections;

/// <summary>
/// Descripción breve de datosConsulta
/// </summary>
/// 
namespace capaDatos
{
    public class datosConsulta
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd;
        SqlDataReader dr;
        public datosConsulta()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        public Array dbSelectAllItemsConsulta()
        {
            ArrayList record = new ArrayList();
            try
            {

                //Recuperando los registros de la tabla Servicios
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString;
                conn.Open();
                string sql = "SELECT id_consulta, id_cita, nomMedico, apeMedico, nomCliente, apeCliente, id_tipo_cliente, estado, fecha_inicio, hora_inicio FROM vConsultaEnProceso";
                cmd = new SqlCommand(sql, conn);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var htable = new { id_consulta = dr["id_consulta"].ToString(), id_cita = dr["id_cita"].ToString(), nomMedica = string.Format("{0} {1}", dr["nomMedico"].ToString(), dr["apeMedico"].ToString()), nomCliente = string.Format("{0} {1}", dr["nomCliente"].ToString(), dr["apeCliente"].ToString()), id_tipo_cliente = dr["id_tipo_cliente"].ToString(), estado = dr["estado"].ToString(), fecha_inicio= dr["fecha_inicio"].ToString().Substring(0,10), horaConsulta = dr["hora_inicio"].ToString() };
                        record.Add(htable);
                    }
                }

                //Cierre de conexciones 
                dr.Close();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                X.Msg.Alert("Error", "Al retornar los registros.").Show();
            }
            //Retornando el valor del arreglo
            return record.ToArray();
        }

        public void dbFinalizarConsulta(string idConsulta) {
            try
            {
                //Cambiando el estado de la consulta a finalizado
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString;
                conn.Open();
                string sql = "UPDATE CONSULTA SET estado=1 WHERE id_consulta=@id_consulta";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id_consulta", idConsulta);
                cmd.ExecuteNonQuery();

                //cierre de conexiones
                conn.Close();
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex) {
                X.Msg.Alert("Error", "No se puede Finalizar la consulta.").Show();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Ext.Net;
using System.Configuration;
using System.Collections;
/// <summary>
/// Descripción breve de datosDetalleConsulta
/// </summary>
/// 
namespace capaDatos
{
    public class datosDetalleConsulta
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd;
        SqlDataReader dr;
        public datosDetalleConsulta()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        public void dbSaveItems(string id_consulta, string id_servicio, string id_pieza, string allazgo)
        {
            try
            {
                //Insertando los registros en la tabla Detalle Consulta
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString;
                conn.Open();
                string sql = "INSERT INTO DETALLE_CONSULTA (id_consulta,id_servicio,id_pieza,allazgo) VALUES (@id_consulta,@id_servicio,@id_pieza,@allazgo)";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id_consulta", id_consulta);
                cmd.Parameters.AddWithValue("@id_servicio", id_servicio);
                cmd.Parameters.AddWithValue("@id_pieza", id_pieza);
                cmd.Parameters.AddWithValue("@allazgo", allazgo);
                cmd.ExecuteNonQuery();
                //Cierre de conexiones
                conn.Close();
                conn.Dispose();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                X.Msg.Alert("Error", "No se puede insertar el registro.").Show();
            }

        }

        public Array dbSelectAllItems(string idConsulta)
        {
            ArrayList record = new ArrayList();
            try
            {

                //Recuperando los registros de la tabla Servicios
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString;
                conn.Open();
                string sql = "SELECT id_detalle_consulta, id_consulta, id_servicio, nombre, id_pieza, Pieza_dental, allazgo FROM vDetalleConsulta  WHERE id_consulta = @idConsulta";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idConsulta", idConsulta);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var htable = new { id_detalle_consulta = dr["id_detalle_consulta"].ToString(), nombre = dr["nombre"].ToString(), Pieza_dental = dr["Pieza_dental"].ToString(), allazgo = dr["allazgo"].ToString()};
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

        public void dbDeleteItems(string idDetalleConsulta)
        {
            try
            {

                //Eliminando los registros de la tabla Servicios
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString;
                conn.Open();
                string sql = "DELETE FROM DETALLE_CONSULTA WHERE id_detalle_consulta=@idDetalleConsulta";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idDetalleConsulta", idDetalleConsulta);
                cmd.ExecuteNonQuery();
                //Cierre de conexiones
                conn.Close();
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                X.Msg.Alert("Error", "Al borrar los registros.").Show();
            }
        }
    }
}
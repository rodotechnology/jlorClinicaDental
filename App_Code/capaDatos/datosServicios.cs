using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using Ext.Net;

/// <summary>
/// Descripción breve de datosServicios
/// </summary>
namespace capaDatos
{
    public class datosServicios
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd;
        SqlDataReader dr;
        public datosServicios()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }
        public void dbSaveItems(string nombreS, string costoS)
        {
            try
            {
                //Insertando los registros en la tabla Servicios
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString;
                conn.Open();
                string sql = "INSERT INTO SERVICIOS (nombre, costo) VALUES (@nombreServicios, @costoServicios)";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nombreServicios", nombreS);
                cmd.Parameters.AddWithValue("@costoServicios", costoS);
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
        public Array dbSelectAllItems()
        {
            ArrayList record = new ArrayList();
            try
            {

                //Recuperando los registros de la tabla Servicios
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString;
                conn.Open();
                string sql = "SELECT id_servicio, nombre, costo FROM SERVICIOS";
                cmd = new SqlCommand(sql, conn);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var htable = new { id_servicio = dr["id_servicio"].ToString(), nombre = dr["nombre"].ToString(), costo = dr["costo"].ToString() };
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

        public void dbDeleteItems(string idServicio)
        {
            try
            {

                //Eliminando los registros de la tabla Servicios
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString;
                conn.Open();
                string sql = "DELETE FROM SERVICIOS WHERE id_servicio=@idServicio";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idServicio", idServicio);
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

        public void dbUpdateData(string id_Servicios, string nombre, string costo)
        {
            try
            {
                //Modificando los registros de la tabla servicios
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString;
                conn.Open();
                string sql = "UPDATE SERVICIOS SET nombre=@nombre, costo = @costo WHERE id_servicio=@idServicio";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@costo", costo);
                cmd.Parameters.AddWithValue("@idServicio", id_Servicios);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                X.Msg.Alert("Error", "Al modificar los registros.").Show();
            }
        }

    }
}
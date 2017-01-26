using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using Ext.Net;

/// <summary>
/// Descripción breve de datosEspecialidad
/// </summary>
public class datosEspecialidad
{
    SqlConnection conn = new SqlConnection();
    SqlCommand cmd;
    SqlDataReader dr;
    public datosEspecialidad()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public void dbSaveItems(string nombreS)
    {
        try
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString;
            conn.Open();
            string sql = "INSERT INTO ESPECIALIDAD (nombre) VALUES (@nombreEspecialidad)";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nombreEspecialidad", nombreS);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            //Ultimo RegistroGuardado
            string sqlInsert = "select last_insert_id() as lid";
            cmd = new SqlCommand(sqlInsert, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            string idEspecialidad = dr["lid"].ToString();

            //Cierre de conexiones
            dr.Close();
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

    public void dbUpdateData(string id_Servicios, string nombre)
    {
        try
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString;
            conn.Open();
            string sql = "UPDATE SERVICIOS SET nombre=@nombre, costo = @costo WHERE id_servicio=@idServicio";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@idServicio", id_Servicios);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Error", "Al modificar los registros.").Show();
        }
    }
}
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
/// 
namespace capaDatos
{
    public class datosEspecialidad
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd;
        SqlDataReader dr;
        //Instanciando a la case DAO
        datosServiciosEspecialidad objServiciosEspecialidad = new datosServiciosEspecialidad();
        public datosEspecialidad()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        public void dbSaveItems(string nombreS, string idServicio)
        {
            try
            {
                //Insertando los registros en la tabla Especialidad
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString;
                conn.Open();
                string sql = "INSERT INTO EPECIALIDAD (nombre) VALUES (@nombreEspecialidad)";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nombreEspecialidad", nombreS);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                //Ultimo RegistroGuardado
                string sqlInsert = "SELECT @@IDENTITY as lid";
                cmd = new SqlCommand(sqlInsert, conn);
                string idEspecialidad = cmd.ExecuteScalar().ToString();

                //Cierre de conexiones

                conn.Close();
                conn.Dispose();
                cmd.Dispose();
                objServiciosEspecialidad.dbSaveItems(idEspecialidad, idServicio);
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
                //Recuperando los registros de la vista EspecialidadServicios 
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString;
                conn.Open();
                string sql = "SELECT  id_servicio_especialidad, id_especialidad, Especialidad, id_servicio, Servicio FROM EspecialidadServicios";
                cmd = new SqlCommand(sql, conn);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var htable = new { id_especialidad = dr["id_especialidad"].ToString(), nombre = dr["Especialidad"].ToString(), nomServicio = dr["Servicio"].ToString(), idServicios = dr["id_servicio"].ToString() };
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

        public void dbDeleteItems(string idEspecialidad)
        {

            try
            {
                //Eliminando los registro de la tabla Especialidad
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString;
                conn.Open();
                string sql = "DELETE FROM EPECIALIDAD WHERE id_especialidad=@idEspecialidad";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idEspecialidad", idEspecialidad);
                cmd.ExecuteNonQuery();
                //Limpiando Variable
                cmd.Dispose();
                sql = "DELETE FROM SERVICIO_ESPECIALIDAD WHERE id_especialidad=@idEspecialidad";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idEspecialidad", idEspecialidad);
                cmd.ExecuteNonQuery();
                //Cierre de conexiones
                conn.Close();
                conn.Dispose();
                cmd.Dispose();
                X.Msg.Alert("Exito", "Sea eliminado el regitro.").Show();
            }
            catch (Exception ex)
            {
                X.Msg.Alert("Error", "Al borrar los registros.").Show();
            }
        }

        public void dbUpdateData(string id_especialidad, string nombre, string id_Servicio)
        {
            try
            {
                //Modificando los registros de la tabla EPECIALIDAD
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString;
                conn.Open();
                string sql = "UPDATE EPECIALIDAD SET nombre=@nombre WHERE id_especialidad=@idEspecialidad;";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@idEspecialidad", id_especialidad);
                cmd.ExecuteNonQuery();

                //Cierre de conexiones
                cmd.Dispose();
                conn.Close();
                conn.Dispose();

                //LLamando al método para modificar los registros
                objServiciosEspecialidad.dbUpdateData(id_especialidad, id_Servicio);

            }
            catch (Exception ex)
            {
                X.Msg.Alert("Error", "Al modificar los registros.").Show();
            }
        }
    }
}
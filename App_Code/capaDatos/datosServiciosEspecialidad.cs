﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using Ext.Net;

/// <summary>
/// Descripción breve de datosServiciosEspecialidad
/// </summary>
namespace capaDatos
{
    public class datosServiciosEspecialidad
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd;
        SqlDataReader dr;
        public datosServiciosEspecialidad()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        public void dbSaveItems(string idEspecialidad, string idServicios)
        {
            try
            {
                //Insertando los registros en la tabla Servicio_Especialidad

                conn.ConnectionString = ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString;
                conn.Open();
                string sql = "INSERT INTO SERVICIO_ESPECIALIDAD (id_servicio,id_especialidad) VALUES (@id_servicio, @id_especialidad)";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id_especialidad", idEspecialidad);
                cmd.Parameters.AddWithValue("@id_servicio", idServicios);
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

        public void dbUpdateData(string id_especialidad, string id_Servicio)
        {
            try
            {
                //Modificando los registros de la tabla EPECIALIDAD
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString;
                conn.Open();
                //Modificando la tabla servicio_especialidad
                string sql = "UPDATE SERVICIO_ESPECIALIDAD SET id_servicio=@id_servicio WHERE id_especialidad=@idEspecialidad;";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id_servicio", id_Servicio);
                cmd.Parameters.AddWithValue("@idEspecialidad", id_especialidad);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                //Cierre de conexiones
                conn.Close();
                conn.Dispose();

            }
            catch (Exception ex)
            {
                X.Msg.Alert("Error", "Al modificar los registros.").Show();
            }
        }
    }
}
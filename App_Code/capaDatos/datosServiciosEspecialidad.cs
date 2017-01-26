using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

/// <summary>
/// Descripción breve de datosServiciosEspecialidad
/// </summary>
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
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString;
            conn.Open();
            string sql = "INSERT INTO SERVICIO_ESPECIALIDAD (id_servicio,id_especialidad) VALUES (@id_servicio, @id_especialidad)";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id_especialidad", idEspecialidad);

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
}
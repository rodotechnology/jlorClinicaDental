using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de datosAlerta
/// </summary>
public class datosAlerta
{
    public datosAlerta()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public ArrayList getDataAlertas()
    {
        ArrayList alertas = new ArrayList();
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString);
        //sentencia que busca la cita que cambia a confirmado
        string sql = "select id_alerta,alerta,fecha_creacion,id_unico from alerta where fecha_recepcion IS NULL ORDER BY fecha_creacion";
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
                    //lectura
                    alertas.Add(new { id_alerta = mydr["id_alerta"].ToString(), alerta = mydr["alerta"].ToString(), fecha_creacion =Convert.ToDateTime(mydr["fecha_creacion"].ToString()), id_unico = mydr["id_unico"].ToString() });
                }
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            //cierre de conexion y lectura
            if (mydr != null) { mydr.Close(); mydr.Dispose(); cmd.Dispose(); }

            if (conn != null) { conn.Close(); conn.Dispose(); }
        }
        //retorna arreglo
        return alertas;
    }

    public Int32 updateVistoAlerta(Int64 id_alerta)
    {
        Int32 affectedrow = 0;
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString);
        try
        {
            conn.Open();
            string sql = "update alerta set fecha_recepcion=getdate() where id_alerta=@id_alerta";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id_alerta", id_alerta);
            cmd.Dispose();
            affectedrow = cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            if (conn != null) { conn.Close(); conn.Dispose(); }
        }
        //retorna arreglo
        return affectedrow;
    }
}
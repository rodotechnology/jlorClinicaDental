using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de datosConfirmacion
/// </summary>
public class datosConfirmacion
{
    public datosConfirmacion()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public ArrayList getCitasPorConfirmar()
    {
        ArrayList confirmar = new ArrayList();
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString);
        string sql = "SELECT CITA.id_cita, CITA.id_cliente, CLIENTE.nombre, CLIENTE.apellidos, SERVICIOS.nombre AS servicio, CITA.dia_cita, CITA.hora_inicio, MEDICO.nombre +' '+ MEDICO.apellidos AS medico,CITA.fecha_registro,MEDICO.id_medico FROM CITA INNER JOIN MEDICO ON CITA.id_medico = MEDICO.id_medico INNER JOIN CLIENTE ON CITA.id_cliente = CLIENTE.id_cliente INNER JOIN SERVICIOS ON CITA.id_servicio = SERVICIOS.id_servicio WHERE (CITA.id_estado_cita = 0) order by CITA.dia_cita asc,CITA.hora_inicio asc,fecha_registro asc";
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
                    confirmar.Add(new { id_cita = mydr["id_cita"].ToString(), id_cliente = mydr["id_cliente"].ToString(), nombre = mydr["nombre"].ToString(), apellidos = mydr["apellidos"].ToString(), servicio = mydr["servicio"].ToString(), dia_cita = Convert.ToDateTime(mydr["dia_cita"].ToString()), hora_inicio = Convert.ToDateTime(mydr["hora_inicio"].ToString()), id_medico = mydr["id_medico"].ToString(), medico = mydr["medico"].ToString(), fecha_registro = Convert.ToDateTime(mydr["fecha_registro"].ToString()) });
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
        return confirmar;
    }

    public ArrayList getCitaPorIdCita(Int64 id_cita)
    {
        ArrayList citas = new ArrayList();
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString);
        //sentencia que busca la cita que cambia a confirmado
        string sql = "select id_medico,dia_cita,hora_inicio,hora_fin from CITA where id_cita=@id_cita";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id_cita", id_cita);
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
                    Hashtable campos = new Hashtable();
                    campos.Add("id_medico", mydr["id_medico"].ToString());
                    campos.Add("dia_cita", mydr["dia_cita"].ToString());
                    campos.Add("hora_inicio", mydr["hora_inicio"].ToString());
                    campos.Add("hora_fin", mydr["hora_fin"].ToString());
                    citas.Add(campos);
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
        return citas;
    }

    public Int32 updateTipoCliente(Int64 id_cliente, Int16 estado)
    {
        Int32 affectedrow = 0;
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString);
        try
        {
            conn.Open();
            string sql = "update CLIENTE set id_tipo_cliente=@id_tipo_cliente where id_cliente=@id_cliente";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
            cmd.Parameters.AddWithValue("@id_tipo_cliente", estado);
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

    public Int32 updateEstadoConfirmadaCita(Int64 id_cita, Int64 id_estado_cita)
    {
        Int32 affectedrow = 0;
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString);
        try
        {
            conn.Open();
            string sql = "update CITA set id_estado_cita=@id_estado_cita where id_cita=@id_cita";//confirmada
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id_cita", id_cita);
            cmd.Parameters.AddWithValue("@id_estado_cita", id_estado_cita);
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

    public Int64 insertConsulta(Int64 id_cita, Int64 id_medico, Int64 id_cliente, DateTime fecha_inicio, DateTime fecha_fin, string hora_inicio, string hora_fin)
    {
        Int64 id = 0;
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString);
        try
        {
            conn.Open();
            string sql = "insert into CONSULTA (id_cita,id_medico,id_cliente,fecha_inicio,fecha_fin,hora_inicio,hora_fin,estado) values (@id_cita,@id_medico,@id_cliente,@fecha_inicio,@fecha_fin,@hora_inicio,@hora_fin,0);SELECT IDENT_CURRENT('CONSULTA') as id;";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id_cita", id_cita);
            cmd.Parameters.AddWithValue("@id_medico", id_medico);
            cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
            cmd.Parameters.AddWithValue("@fecha_inicio", fecha_inicio);
            cmd.Parameters.AddWithValue("@fecha_fin", fecha_fin);
            cmd.Parameters.AddWithValue("@hora_inicio", hora_inicio);
            cmd.Parameters.AddWithValue("@hora_fin", hora_fin);
            id = Convert.ToInt64(cmd.ExecuteScalar());
            cmd.Dispose();
        }
        catch (SqlException ex)
        {
            //return "Error al intentar enviar los datos:" + ex;
            return id;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        return id;
    }
}
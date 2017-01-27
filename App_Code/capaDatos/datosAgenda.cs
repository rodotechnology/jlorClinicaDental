using System;
using System.Collections;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de datosAgenda
/// </summary>
public class datosAgenda
{
    public datosAgenda()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public ArrayList getServicios()
    {
        ArrayList servicios = new ArrayList();
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString);
        string sql = "SELECT id_servicio,nombre FROM SERVICIOS";
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
                    servicios.Add(new { id_servicio = mydr["id_servicio"].ToString(), servicio = mydr["nombre"].ToString() });
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
        return servicios;
    }

    public ArrayList getMedicoPorServicio(Int64 id_servicio)
    {
        ArrayList medicos = new ArrayList();
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString);
        string sql = "SELECT DISTINCT MEDICO.id_medico, MEDICO.nombre FROM MEDICO INNER JOIN MEDICO_ESPECIALIDAD ON MEDICO.id_medico = MEDICO_ESPECIALIDAD.id_medico INNER JOIN ESPECIALIDAD ON MEDICO_ESPECIALIDAD.id_especialidad = ESPECIALIDAD.id_especialidad INNER JOIN SERVICIO_ESPECIALIDAD ON ESPECIALIDAD.id_especialidad = SERVICIO_ESPECIALIDAD.id_servicio WHERE(SERVICIO_ESPECIALIDAD.id_servicio = @id_servicio)";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id_servicio", id_servicio);
        SqlDataReader mydr = null;
        try
        {
            conn.Open();
            mydr = cmd.ExecuteReader();
            if (mydr.HasRows)
            {
                while (mydr.Read())
                {
                    medicos.Add(new { id_medico = mydr["id_medico"].ToString(), medico = mydr["nombre"].ToString() });
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
        return medicos;
    }

    public Int64 insertCita(Int64 id_medico,DateTime dia_cita,string hora_inicio,string hora_fin,Int64 id_servicio,Int64 id_cliente)
    {
        Int64 id = 0;
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString);
        try
        {
            conn.Open();
            string sql = "insert into CITA (id_medico,dia_cita,hora_inicio,hora_fin,id_servicio,id_cliente) values (@id_medico,@dia_cita,@hora_inicio,@hora_fin,@id_servicio,@id_cliente);SELECT IDENT_CURRENT('CITA') as id;";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id_medico", id_medico);
            cmd.Parameters.AddWithValue("@dia_cita", dia_cita);
            cmd.Parameters.AddWithValue("@hora_inicio", hora_inicio);
            cmd.Parameters.AddWithValue("@hora_fin", hora_fin);
            cmd.Parameters.AddWithValue("@id_servicio", id_servicio);
            cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
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

    public ArrayList getCitas()
    {
        ArrayList citas = new ArrayList();
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString);
        //sentencia que busca todas las citas que no esten confirmadas para el cliente potencial
        string sql = "SELECT id_cita,dia_cita,hora_inicio,hora_fin  FROM CITA where id_estado_cita=0";
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
                    Hashtable campos = new Hashtable();
                    campos.Add("id_cita", mydr["id_cita"].ToString());
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
}
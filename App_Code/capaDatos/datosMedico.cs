using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

/// <summary>
/// Descripción breve de datosMedico
/// </summary>
public class datosMedico
{
    public datosMedico()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public ArrayList getEspecialidad()
    {
        ArrayList especialidad = new ArrayList();
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString);
        string sql = "SELECT id_especialidad,nombre FROM especialidad";
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
                    especialidad.Add(new { id_especialidad = mydr["id_especialidad"].ToString(), nombre = mydr["nombre"].ToString() });
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
        return especialidad;
    }

    public ArrayList getHorarios()
    {
        ArrayList horarios = new ArrayList();
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString);
        string sql = "SELECT id_horario,raw FROM horario";
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
                    horarios.Add(new { id_horario = mydr["id_horario"].ToString(), raw = mydr["raw"].ToString() });
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
        return horarios;
    }

    public ArrayList getMedicos()
    {
        ArrayList medicos = new ArrayList();
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString);
        string sql = "SELECT id_medico,nombre +' ' +apellidos as nombre,telefono,celular,correo,titulo,id_especialidad,id_horario FROM medico";
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
                    medicos.Add(new { id_medico = mydr["id_medico"].ToString(), nombre = mydr["nombre"].ToString(), telefono = mydr["telefono"].ToString(), celular = mydr["celular"].ToString(), correo = mydr["correo"].ToString(), titulo = mydr["titulo"].ToString() });
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

    public Int64 insertMedico(string nombre,string apellidos,string telefono,string celular,string correo,string titulo,Int64 id_especialidad,Int64 id_horario)
    {
        Int64 id = 0;
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString);
        try
        {
            conn.Open();
            string sql = "insert into medico (nombre,apellidos,telefono,celular,correo,titulo,id_especialidad,id_horario) values (@nombre,@apellidos,@telefono,@celular,@correo,@titulo,@id_especialidad,@id_horario);SELECT IDENT_CURRENT('medico') as id;";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellidos", apellidos);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@celular", celular);
            cmd.Parameters.AddWithValue("@correo", correo);
            cmd.Parameters.AddWithValue("@titulo", titulo);
            cmd.Parameters.AddWithValue("@id_especialidad", id_especialidad);
            cmd.Parameters.AddWithValue("@id_horario", id_horario);
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

    public Int64 insertMedicoEspecialidad(Int64 id_medico, Int64 id_especialidad)
    {
        Int64 id = 0;
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString);
        try
        {
            conn.Open();
            string sql = "insert into medico_especialidad (id_medico,id_especialidad) values (@id_medico,@id_especialidad);SELECT IDENT_CURRENT('medico_especialidad') as id;";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id_medico", id_medico);
            cmd.Parameters.AddWithValue("@id_especialidad", id_especialidad);
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
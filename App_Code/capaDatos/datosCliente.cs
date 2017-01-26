using System;
using System.Collections;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de datosCliente
/// </summary>
public class datosCliente
{
    public datosCliente()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public Int64 insertCliente(string nombre,string apellidos,string telefono,string correo,string dui)
    {
        Int64 id = 0;
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString);
        try
        {
            conn.Open();
            string sql = "insert into CLIENTE (nombre,apellidos,telefono,correo,dui) values (@nombre,@apellidos,@telefono,@correo,@dui);SELECT IDENT_CURRENT('CLIENTE') as id;";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellidos", apellidos);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@correo", correo);
            cmd.Parameters.AddWithValue("@dui", dui);
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
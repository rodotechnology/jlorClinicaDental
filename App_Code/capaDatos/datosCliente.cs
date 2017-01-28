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
            //sentencia a ejecutar
            string sql = "insert into CLIENTE (nombre,apellidos,telefono,correo,dui,id_tipo_cliente) values (@nombre,@apellidos,@telefono,@correo,@dui,0);SELECT IDENT_CURRENT('CLIENTE') as id;";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellidos", apellidos);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@correo", correo);
            cmd.Parameters.AddWithValue("@dui", dui);
            //capturando el ultimo id generado
            id = Convert.ToInt64(cmd.ExecuteScalar());
            cmd.Dispose();
        }
        catch (SqlException ex)
        {
            //retorna cero si hay error
            return id;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        //valor a retornar
        return id;
    }
}
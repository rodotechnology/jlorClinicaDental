using System;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.Globalization;

/// <summary>
/// Descripción breve de datosRol
/// </summary>
namespace capaDatos
{
    public class datosRol
    {
        public datosRol()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        public ArrayList getRoles()
        {
            ArrayList records = new ArrayList();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString);
            string sql = "SELECT id_rol,rol FROM Rol";
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
                        records.Add(new { id_rol = mydr["id_rol"].ToString(), rol = mydr["rol"].ToString() });
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
            return records;
        }

        public ArrayList getPermissionData(string idRol)
        {
            ArrayList records = new ArrayList();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString);
            string sql = "SELECT id_rol,rol FROM Rol  WHERE id_rol = @idRol";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@idRol", idRol);
            SqlDataReader mydr = null;
            try
            {
                conn.Open();
                mydr = cmd.ExecuteReader();
                if (mydr.HasRows)
                {
                    while (mydr.Read())
                    {
                        Hashtable items = new Hashtable();
                        items.Add("id_rolA", mydr["id_rol"].ToString());
                        items.Add("rolA", mydr["rol"].ToString());
                        records.Add(items);
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
            return records;
        }

        public bool validateRol(string txtNombreRol, string txtIdRolA, string txtNombreRolA, string type)
        {
            bool resultado = false;
            SqlConnection connV = new SqlConnection(ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString);
            string sql = string.Empty;
            SqlCommand cmdV = new SqlCommand(sql, connV);
            SqlDataReader mydrV = null;
            try
            {
                connV.Open();

                if (type == "1")
                {
                    string sqlStr1 = "SELECT id_rol FROM rol WHERE (rol = @nomRol)";
                    cmdV = new SqlCommand(sqlStr1, connV);
                    cmdV.Parameters.AddWithValue("@nomRol", txtNombreRol);
                    mydrV = cmdV.ExecuteReader();
                }
                else if (type == "2")
                {
                    string sqlStr1 = "SELECT id_rol FROM rol WHERE (rol = @nomRol) AND (id_rol <> @idRol)";
                    cmdV = new SqlCommand(sqlStr1, connV);
                    cmdV.Parameters.AddWithValue("@nomRol", txtNombreRolA);
                    cmdV.Parameters.AddWithValue("@idRol", txtIdRolA);
                    mydrV = cmdV.ExecuteReader();
                }

                if (mydrV.HasRows)
                {
                    mydrV.Read();
                    if (!mydrV["id_rol"].Equals(string.Empty))
                    { resultado = true; }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (mydrV != null) { mydrV.Close(); mydrV.Dispose(); cmdV.Dispose(); }

                if (connV != null) { connV.Close(); connV.Dispose(); }
            }

            return resultado;
        }

        public bool setRol(string txtNombreRol)
        {
            bool ok = false;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString;
            try
            {
                conn.Open();
                SqlCommand cmd;

                string insertRol = "INSERT INTO rol VALUES(@nomRol)";
                cmd = new SqlCommand(insertRol, conn);

                cmd.Parameters.AddWithValue("@nomRol", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtNombreRol.Trim().ToLower()));

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                ok = true;
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return ok;
        }

        public bool updateRol(string txtIdRolA, string txtNombreRolA)
        {
            bool ok = false;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString;
            try
            {
                conn.Open();
                SqlCommand cmd;

                string updateRol = "UPDATE rol SET rol = @nom_Rol WHERE id_rol = @id_Rol";
                cmd = new SqlCommand(updateRol, conn);

                cmd.Parameters.AddWithValue("@nom_Rol", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtNombreRolA.Trim().ToLower()));
                cmd.Parameters.AddWithValue("@id_Rol", Convert.ToInt64(txtIdRolA));

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                ok = true;
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return ok;
        }
    }
}
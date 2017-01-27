using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data.SqlClient;

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
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString);
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
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString);
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
            SqlConnection connV = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString);
            string sql = "SELECT id_rol,rol FROM Rol";
            SqlCommand cmdV = new SqlCommand(sql, connV);
            SqlDataReader mydrV = null;
            try
            {
                connV.Open();
                mydrV = cmdV.ExecuteReader();

                if (type == "1")
                {
                    string sqlStr1 = "SELECT id_rol FROM rol WHERE (rol = @nomRol)";
                    cmdV = new SqlCommand(sqlStr1, connV);
                    cmdV.Parameters.AddWithValue("@nomRol", txtNombreRol);
                }
                else if (type == "2")
                {
                    string sqlStr1 = "SELECT id_rol FROM rol WHERE (rol = @nomRol) AND (id_rol <> @idRol)";
                    cmdV = new SqlCommand(sqlStr1, connV);
                    cmdV.Parameters.AddWithValue("@nomRol", txtNombreRolA);
                    cmdV.Parameters.AddWithValue("@idRol", txtIdRolA);
                }

                if (mydrV.HasRows)
                {
                    mydrV.Read();
                    resultado = true;
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
    }
}
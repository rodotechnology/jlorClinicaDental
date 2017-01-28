using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using Ext.Net;

/// <summary>
/// Descripción breve de datosDiente
/// </summary>
namespace capaDatos
{
    public class datosDiente
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd;
        SqlDataReader dr;
        public datosDiente()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        public Array dbSelectFiltroItems(string idEmisferio)
        {
            ArrayList record = new ArrayList();
            try
            {

                //Recuperando los registros de la tabla Servicios
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString;
                conn.Open();
                string sql = "SELECT id_pieza, emisferio, descripcion FROM DIENTE WHERE emisferio=@idEmisferio";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idEmisferio", idEmisferio);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var htable = new { id_pieza = dr["id_pieza"].ToString(), emisferio = dr["emisferio"].ToString(), descripcion = dr["descripcion"].ToString() };
                        record.Add(htable);
                    }
                }

                //Cierre de conexciones 
                dr.Close();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                X.Msg.Alert("Error", "Al retornar los registros.").Show();
            }
            //Retornando el valor del arreglo
            return record.ToArray();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

/// <summary>
/// Descripción breve de datosServicios
/// </summary>
namespace capaDatos
{
    public class datosServicios
    {
        public datosServicios()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }
        public void dbSaveItems(string nombreS, string costoS)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString;
            conn.Open();
            string sql = "INSERT INTO SERVICIOS VALUES (@nombreServicios, @costoServicios)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nombreServicios", nombreS);
            cmd.Parameters.AddWithValue("@costoServicios", costoS);
            cmd.ExecuteNonQuery();
            //Cierre de conexiones
            conn.Close();
            conn.Dispose();
            cmd.Dispose();
        }
        public ArrayList dbSelectAllItems() {
            ArrayList record = new ArrayList();


            return record;
        }

        public void dbDeleteItems(Int64 idServicio) {

        }

    }
}
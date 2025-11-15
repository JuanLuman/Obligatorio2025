using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Obligatorio.Datos
{
    public class ConexionBD
    {
        //String connectionString = "data source = JUAN\\SQLEXPRESS; initial catalog = Tienda; integrated security = true";
        SqlConnection conexion = new SqlConnection("data source = JUAN\\SQLEXPRESS; " +
                                                                                         "initial catalog = Obligatorio2025; " +
                                                                                         "integrated security = true");

        public SqlConnection AbrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
            return conexion;
        }

        public SqlConnection CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
            return conexion;
        }










    }

}

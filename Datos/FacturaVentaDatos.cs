using Objetos;
using Obligatorio.Datos;
using Obligatorio2025.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio2025.Datos
{
    public class FacturaVentaDatos
    {




        public DataTable ListarFacturaVenta()
        {
            DataTable tabla = new DataTable();
            ConexionBD conexion = new ConexionBD();
            try
            {

                using (SqlConnection con = conexion.AbrirConexion())
                using (SqlCommand comando = new SqlCommand("ListarFacturaVenta", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader leer = comando.ExecuteReader())
                    {
                        tabla.Load(leer);
                    }
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al listar Factura: " + ex.Message);
                throw;
            }
            finally
            {
                //leer.Close();
                conexion.CerrarConexion();
            }
            return tabla;
        }




        // Obtener cálculo mensual

        public Calculo ObtenerCalculoMensual(int mes, int año)
        {
            Calculo calculo = new Calculo { Mes = mes, Año = año };

            ConexionBD conexion = new ConexionBD();
            try
            {
                using (SqlConnection con = conexion.AbrirConexion())
                {

                    double totalVentas = 0;
                    using (SqlCommand comando = new SqlCommand("ObtenerVentaMensual", con))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@Mes", SqlDbType.Int).Value = mes;
                        comando.Parameters.AddWithValue("@Año", SqlDbType.Int).Value = año;

                        object result = comando.ExecuteScalar();
                        totalVentas = result != DBNull.Value ? Convert.ToDouble(result) : 0;
                    }

                    // ===== OBTENER TOTAL COMPRAS =====
                    double totalCompras = 0;
                    using (SqlCommand comando = new SqlCommand("ObtenerCompraMensual", con))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@Mes", SqlDbType.Int).Value = mes;
                        comando.Parameters.Add("@Año", SqlDbType.Int).Value = año;

                        object result = comando.ExecuteScalar();
                        totalCompras = result != DBNull.Value ? Convert.ToDouble(result) : 0;
                    }

                    // calculo IVA , IRAE
                    calculo.Calcular(totalVentas, totalCompras);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener cálculo mensual: " + ex.Message);
            }

            return calculo;
        }













    }
}

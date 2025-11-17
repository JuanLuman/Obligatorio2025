using Obligatorio.Datos;
using Obligatorio2025.Datos;
using Obligatorio2025.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio2025.Logica
{
    public class CalculoLogica
    {



        // Obtener cálculo mensual

        public Calculo ObtenerCalculoMensual(int mes, int año)
        {
            Calculo calculo = new Calculo { Mes = mes, Año = año };

            ConexionBD conexion = new ConexionBD();

            // valido meses y años
            if (mes < 1 || mes > 12)
                throw new Exception("El mes debe estar entre 1 y 12");

            if (año > DateTime.Now.Year)
                throw new Exception("Año inválido");

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

                        object resultado = comando.ExecuteScalar();

                        if (resultado == null || resultado == DBNull.Value)
                        {
                            totalVentas = 0;
                        }
                        else
                        {
                            totalVentas = Convert.ToDouble(resultado);
                        }

                       
                    }

                    // obtengo total compra
                    double totalCompras = 0;
                    using (SqlCommand comando = new SqlCommand("ObtenerCompraMensual", con))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@Mes", SqlDbType.Int).Value = mes;
                        comando.Parameters.Add("@Año", SqlDbType.Int).Value = año;

                        object resultado = comando.ExecuteScalar();

                        if (resultado == null || resultado == DBNull.Value)
                        {
                            totalVentas = 0;
                        }
                        else
                        {
                            totalVentas = Convert.ToDouble(resultado);
                        }
                        
                    }

                    // calculo IVA , IRAE
                    calculo.Calcular(totalVentas, totalCompras);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener cálculo mensual: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
            return calculo;
        }












    }
}

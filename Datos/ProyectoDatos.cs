using Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Obligatorio.Datos
{
    public class ProyectoDatos
    {
        ConexionBD conexion = new ConexionBD();

        public DataTable ListarProyectos()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = conexion.AbrirConexion())
                using (SqlCommand comando = new SqlCommand("ListarProyectos", con))
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
                Console.WriteLine("Error al listar proyectos: " + ex.Message);
                throw; 
            }
            finally
            {
                conexion.CerrarConexion();
            }
            return tabla;
        }


        public void IngresarProyecto(Proyecto proyecto)
        {
            try
            {
                using (SqlConnection con = conexion.AbrirConexion())
                using (SqlCommand comando = new SqlCommand("IngresarProyecto", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.Add("@id", SqlDbType.Int).Value = proyecto.Id;
                    comando.Parameters.Add("@idcliente", SqlDbType.Int).Value = proyecto.IdCliente;
                    comando.Parameters.Add("@nombreproyecto", SqlDbType.VarChar, 100).Value = proyecto.NombreProyecto;
                    comando.Parameters.Add("@tipo", SqlDbType.VarChar, 50).Value = proyecto.Tipo;
                    comando.Parameters.Add("@fechainicio", SqlDbType.Date).Value = proyecto.FechaInicio;
                    comando.Parameters.Add("@presinicial", SqlDbType.Decimal).Value = proyecto.PresupuestoInicial;
                    comando.Parameters.Add("@fechafinplan", SqlDbType.Date).Value = proyecto.FechaFinPlanificada;
                    comando.Parameters.Add("@fechafin", SqlDbType.Date).Value = proyecto.FechaFin;
                    comando.Parameters.Add("@estado", SqlDbType.VarChar, 20).Value = proyecto.Estado;

                    comando.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al ingresar proyecto: " + ex.Message);
                throw; 
            }
            finally
            {

                conexion.CerrarConexion();
            }
        }




        public void EliminarProyecto(int id)
        {
            try
            {
                using (SqlConnection con = conexion.AbrirConexion())
                using (SqlCommand comando = new SqlCommand("EliminarProyecto", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;

                    comando.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al eliminar proyecto: " + ex.Message);
                throw; 
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }







       








        
    }
}
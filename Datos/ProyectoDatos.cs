using Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Obligatorio.Datos
{
    public class ProyectoDatos
    {
        private ConexionBD conexion = new ConexionBD();

        public DataTable ListarProyectos()
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "ListarProyectos";
                comando.CommandType = CommandType.StoredProcedure;

                SqlDataReader leer = comando.ExecuteReader();
                DataTable tabla = new DataTable();
                tabla.Load(leer);

                return tabla;
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public void IngresarProyecto(Proyecto proyecto)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "IngresarProyecto";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id", proyecto.Id);
                comando.Parameters.AddWithValue("@idcliente", proyecto.IdCliente);
                comando.Parameters.AddWithValue("@nombreproyecto", proyecto.NombreProyecto);
                comando.Parameters.AddWithValue("@tipo", proyecto.tipo);
                comando.Parameters.AddWithValue("@fechainicio", proyecto.FechaInicio);
                comando.Parameters.AddWithValue("@presinicial", proyecto.PresupuestoInicial);
                comando.Parameters.AddWithValue("@fechafinplan", proyecto.FechaFinPlanificada);
                comando.Parameters.AddWithValue("@fechafin", proyecto.FechaFin);
                comando.Parameters.AddWithValue("@estado", proyecto.Estado);

                comando.ExecuteNonQuery();
            }catch(SqlException ex)
            {
                Console.WriteLine("Error al ingresar proyecto");
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
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "EliminarProyectos";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
            }catch(SqlException ex)
            {
                Console.WriteLine("Error al eliminar proyecto");
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public void ActualizarProyecto(Proyecto proyecto)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "ActualizarProyectos";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id", proyecto.Id);
                comando.Parameters.AddWithValue("@idcliente", proyecto.IdCliente);
                comando.Parameters.AddWithValue("@nombreproyecto", proyecto.NombreProyecto);
                comando.Parameters.AddWithValue("@tipo", proyecto.tipo);
                comando.Parameters.AddWithValue("@fechainicio", proyecto.FechaInicio);
                comando.Parameters.AddWithValue("@presinicial", proyecto.PresupuestoInicial);
                comando.Parameters.AddWithValue("@fechafinplan", proyecto.FechaFinPlanificada);
                comando.Parameters.AddWithValue("@fechafin", proyecto.FechaFin);
                comando.Parameters.AddWithValue("@estado", proyecto.Estado);

                comando.ExecuteNonQuery();
            }
            catch (SqlException ex) 
            {
                Console.WriteLine("Error al actualizar proyecto");
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }
    }
}
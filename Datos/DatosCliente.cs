using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using Objetos;
using System.Runtime.InteropServices;
using System.Linq.Expressions;


namespace Obligatorio.Datos
{
    public class ClienteDatos
    {

        ConexionBD conexion = new ConexionBD();
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        //  Cliente clientes = new Cliente();


        public DataTable ListarClientes()
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "ListarClientes";
                comando.CommandType = CommandType.StoredProcedure;
                leer = comando.ExecuteReader();
                tabla.Load(leer);


                return tabla;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al listar clientes: " + ex.Message);
                return null;
            }
            finally
            {
                conexion.CerrarConexion();
            } }


        public void IngresarClientes(Cliente cliente)
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "IngresarClientes";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id", cliente.Id);
                comando.Parameters.AddWithValue("@razonsocial", cliente.RazonSocial);
                comando.Parameters.AddWithValue("@rut", cliente.RUT);
                comando.Parameters.AddWithValue("@direccion", cliente.Direccion);

                comando.ExecuteNonQuery();
                comando.Parameters.Clear();

            }
            catch (SqlException ex)
            {

                Console.WriteLine("Error al ingresar cliente: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        //eliminar clientes
        public void EliminarClientes(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarClientes";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();

        }

        //actualizar clientes
        public void ActualizarClientes(Cliente cliente)
        {
            try
            {

                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "ActualizarClientes";
                comando.CommandType = CommandType.StoredProcedure;


                comando.Parameters.AddWithValue("@razonsocial", cliente.RazonSocial);
                comando.Parameters.AddWithValue("@rut", cliente.RUT);
                comando.Parameters.AddWithValue("@direccion", cliente.Direccion);

                comando.ExecuteNonQuery();
                comando.Parameters.Clear();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al actualizar cliente: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }














        }
    }

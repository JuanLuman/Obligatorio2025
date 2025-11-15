using System.Data;
using System.Data.SqlClient;
using Objetos;
using Obligatorio2025.Objetos;


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

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al listar clientes: " + ex.Message);
                return null;
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return tabla;
        }


        public void IngresarClientes(Cliente cliente)
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "IngresarCliente";
                comando.CommandType = CommandType.StoredProcedure;

             
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



        public void EliminarCliente(int id)
        {
            try
            {
               
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "EliminarCliente";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@IdCliente", id);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();

            }
            catch (SqlException ex)
            {

                Console.WriteLine("Error al eliminar cliente: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }




        //actualizar clientes
        public void ModificarClientes(Cliente cliente)
        {
            try
            {

                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "ModificarCliente";
                comando.CommandType = CommandType.StoredProcedure;

                
                comando.Parameters.AddWithValue("@RazonSocial", cliente.RazonSocial);
                comando.Parameters.AddWithValue("@RUT", cliente.RUT);
                comando.Parameters.AddWithValue("@Direccion", cliente.Direccion);

                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al modificar el cliente: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
         }



        public Cliente BuscarClientePorId(int id)
        {
            Cliente cliente = null;
            SqlDataReader reader = null;

            try
            {
                // Abrir conexión
                comando.Connection = conexion.AbrirConexion();

                // Configurar comando
                comando.CommandText = "BuscarClientePorId";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();    

                comando.Parameters.AddWithValue("@IdCliente", id);

                // Ejecutar lectura
                reader = comando.ExecuteReader();

                // Si se encuentra el registro
                if (reader.Read())
                {
                    cliente = new Cliente
                    {
                        Id = Convert.ToInt32(reader["IdCliente"]),
                        RazonSocial = reader["RazonSocial"].ToString(),
                        RUT = reader["RUT"].ToString(),
                        Direccion = reader["Direccion"].ToString()
                    };
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al buscar cliente por ID: " + ex.Message);
                return null;
            }
            finally
            {
                
                    reader.Close();

                conexion.CerrarConexion();
            }

            return cliente;
        }













    
}
}

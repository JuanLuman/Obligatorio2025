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

       


        public List<Cliente> ListarClientes()
        {
            var listaClientes = new List<Cliente>();

            using (SqlConnection con = conexion.AbrirConexion())
            {
                using (SqlCommand comando = new SqlCommand("ListarClientes", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        

                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var cliente = new Cliente
                                {
                                    IdCliente = reader.GetInt32(reader.GetOrdinal("IdCliente")),
                                    RazonSocial = reader.GetString(reader.GetOrdinal("RazonSocial")),
                                    RUT = reader.GetString(reader.GetOrdinal("RUT")),
                                    Direccion = reader.GetString(reader.GetOrdinal(" Direccion")),
                                    
                                };

                                listaClientes.Add(cliente);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error al listar clientes: " + ex.Message);
                    }
                }
            }

            return listaClientes;
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
            ConexionBD conexion = new ConexionBD();
            try
            {
                using (SqlConnection con = conexion.AbrirConexion())
                using (SqlCommand comando = new SqlCommand("EliminarCliente", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;

                    comando.ExecuteNonQuery();
                    comando.Parameters.Clear();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al eliminar cliente: " + ex.Message);
                throw;
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

               
                comando.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
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

                // Ejecutar lectura  para iterar
                reader = comando.ExecuteReader();

                // Si se encuentra el registro
                if (reader.Read())
                {
                    cliente = new Cliente
                    {
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
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

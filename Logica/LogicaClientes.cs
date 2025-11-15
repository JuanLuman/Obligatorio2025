using Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Obligatorio2025.Datos;
using Obligatorio.Datos;

namespace Logica
{
    public class LogicaClientes
    {

        Cliente cliente = new Cliente();
        ClienteDatos clientedatos = new ClienteDatos();


        //metodo para listar clientes
        public DataTable ListarClientes()
        {
            try
            {
                DataTable tabla = new DataTable();
                if (clientedatos.ListarClientes() != null)
                {
                    tabla = clientedatos.ListarClientes();

                }

                return tabla;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar clientes: " + ex.Message);
                return null;
            }
        }


        //metodo para ingresar clientes
        public String IngresarClientes(Cliente cliente)
        {
            try
            {
                clientedatos.IngresarClientes(cliente);
                return "Cliente ingresado con exito";
            }
            catch (Exception ex)
            {
                return "Error al ingresar cliente: " + ex.Message;
            }
        }

        //metodo para modificar clientes
        public String ModificarClientes(Cliente cliente)
        {

            // Validaciones
            if (cliente.Id <= 0)
                throw new Exception("ID de cliente inválido");

            if (string.IsNullOrWhiteSpace(cliente.RazonSocial))
                throw new Exception("La razón social es obligatoria");

            if (string.IsNullOrWhiteSpace(cliente.RUT))
                throw new Exception("El RUT es obligatorio");

            try
            {
                clientedatos.ModificarClientes(cliente);
                return "Cliente modificado con exito";
            }
            catch (Exception ex)
            {
                return "Error al modificar cliente: " + ex.Message;
            }
        }





        //eliminar clientes
        public String EliminarClientes(int id)
        {
            try
            {
                clientedatos.EliminarCliente(id);
                return "Cliente eliminado con exito";
            }
            catch (Exception ex)
            {
                return "Error al eliminar cliente: " + ex.Message;
            }
        }



        // metodo para buscar cliente por Id
        public Cliente BuscarCliente(int id)
        {
            
            if (id <= 0)
                throw new Exception("ID de cliente inválido");

            try
            {
                return clientedatos.BuscarClientePorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar cliente: " + ex.Message);
            }
        }






    }
}
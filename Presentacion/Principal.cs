using Logica;
using Objetos;
using Obligatorio.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Obligatorio2025.Objetos.EnumeradosProyecto;

namespace Obligatorio2025.Presentacion
{
    public class Principal
    {

        LogicaClientes cliente = new LogicaClientes();
        LogicaProyecto proyecto = new LogicaProyecto();


        static void Main(string[] args)
        {
            int opcion = 0;

            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("            GESTION    PRINCIPAL                ");
                    Console.WriteLine();
                    Console.WriteLine("1. Gestión de Clientes");
                    Console.WriteLine("2. Gestión de Proyectos");
                    Console.WriteLine("0. Salir");
                    Console.Write("\nSeleccione una opción: ");

                    opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            MenuClientes();
                            break;
                        case 2:
                            MenuProyectos();
                            break;
                        case 0:
                            Console.WriteLine("\n Saliendo ");
                            break;
                        default:
                            Console.WriteLine("\nOpción inválida");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nError: " + ex.Message);
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }



        static void MenuClientes()
        {
            int opcion = 0;

            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("         GESTIÓN DE CLIENTES           ");
                Console.WriteLine();
                Console.WriteLine("1. Listar clientes");
                Console.WriteLine("2. Agregar cliente");
                Console.WriteLine("3. Modificar cliente");
                Console.WriteLine("4. Eliminar cliente");
                Console.WriteLine("0. Volver");
                Console.Write("\nSeleccione una opción: ");

                opcion = Convert.ToInt32(Console.ReadLine());

                try
                {
                    switch (opcion)
                    {
                        case 1:
                            ListarClientes();
                            break;
                        case 2:
                            AgregarCliente();
                            break;
                        case 3:
                            ModificarCliente();
                            break;
                        case 4:
                            EliminarCliente();
                            break;
                        case 0:
                            break;
                        default:
                            Console.WriteLine("\nOpción inválida");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nError: " + ex.Message);
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }



        static void ListarClientes()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("                        LISTADO DE CLIENTES :                                      ");
            Console.WriteLine();

            LogicaClientes logicacliente = new LogicaClientes();
            List<Cliente> clientes = logicacliente.ListarClientes();

            if (clientes.Count == 0)
            {
                Console.WriteLine("No hay clientes registrados.");
            }
            else
            {


                foreach (Cliente item in clientes)
                {
                    Console.WriteLine($" ID: {item.IdCliente}");
                    Console.WriteLine($"Nombre: {item.RazonSocial}");
                    Console.WriteLine($"Cliente ID: {item.RUT}");
                    Console.WriteLine($"Tipo: {item.Direccion}");

                }

                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }


        static void AgregarCliente()
        {
            LogicaClientes logicaClientes = new LogicaClientes();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("                        AGREGAR CLIENTE");
            Console.WriteLine();

            Console.Write("\nRazón Social: ");
            string razonSocial = Console.ReadLine();

            Console.Write("RUT (12 dígitos): ");
            string rut = Console.ReadLine();

            Console.Write("Dirección: ");
            string direccion = Console.ReadLine();

            Cliente nuevoCliente = new Cliente(razonSocial, rut, direccion);

            logicaClientes.IngresarClientes(nuevoCliente);

            Console.WriteLine("   Cliente agregado exitosamente!");
            Console.ReadKey();
        }




        static void ModificarCliente()
        {
            LogicaClientes logicaClientes = new LogicaClientes();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("                       MODIFICAR CLIENTE");
            Console.WriteLine();

            Console.Write("ID del cliente a modificar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Cliente cliente = logicaClientes.BuscarCliente(id);

            if (cliente == null)
            {
                Console.WriteLine(" Cliente no encontrado");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Datos actuales:");
            Console.WriteLine($"Razón Social: {cliente.RazonSocial}");
            Console.WriteLine($"RUT: {cliente.RUT}");
            Console.WriteLine($"Dirección: {cliente.Direccion}");

            Console.Write("\nNueva Razón Social: ");
            string nuevaRazon = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevaRazon))
                cliente.RazonSocial = nuevaRazon;

            Console.Write("Nuevo RUT: ");
            string nuevoRUT = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoRUT))
                cliente.RUT = nuevoRUT;

            Console.Write("Nueva Dirección: ");
            string nuevaDireccion = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevaDireccion))
                cliente.Direccion = nuevaDireccion;

            logicaClientes.ModificarClientes(cliente);

            Console.WriteLine(" Cliente modificado exitosamente!");
            Console.ReadKey();
        }




        static void EliminarCliente()
        {
            LogicaClientes logicacliente = new LogicaClientes();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("                       ELIMINAR CLIENTE");
            Console.WriteLine();

            Console.Write("ID del cliente a eliminar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Cliente cliente = logicacliente.BuscarCliente(id);

            if (cliente == null)
            {
                Console.WriteLine(" Cliente no encontrado");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($" Cliente: {cliente.RazonSocial}");
            Console.Write("\n ¿Está seguro de eliminar este cliente? (S/N): ");
            string confirmacion = Console.ReadLine().ToUpper();

            if (confirmacion == "S")
            {
                logicacliente.EliminarCliente(id);
                Console.WriteLine("   Cliente eliminado exitosamente!");
            }
            else
            {
                Console.WriteLine("\n  Operación cancelada");
            }

            Console.ReadKey();
        }



        static void MenuProyectos()
        {
            int opcion = 0;

            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("       GESTIÓN DE PROYECTOS             ");
                Console.WriteLine();
                Console.WriteLine("1. Listar proyectos");
                Console.WriteLine("2. Agregar proyecto");
                Console.WriteLine("0. Volver");
                Console.Write("  Seleccione una opción: ");

                opcion = Convert.ToInt32(Console.ReadLine());

                try
                {
                    switch (opcion)
                    {
                        case 1:
                            ListarProyectos();
                            break;
                        case 2:
                            AgregarProyecto();
                            break;
                        case 0:
                            break;
                        default:
                            Console.WriteLine("   Opción inválida");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("   Error: " + ex.Message);
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }



        static void ListarProyectos()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("                       LISTADO DE PROYECTOS");
            Console.WriteLine();

            LogicaProyecto logicaproyecto = new LogicaProyecto();
            List<Proyecto> proyectos = logicaproyecto.ListarProyecto();

            if (proyectos.Count == 0)
            {
                Console.WriteLine(" No hay proyectos registrados.");
            }
            else
            {
                foreach (Proyecto pro in proyectos)
                {
                    Console.WriteLine($" ID: {pro.Id}");
                    Console.WriteLine($"Nombre: {pro.NombreProyecto}");
                    Console.WriteLine($"Cliente ID: {pro.IdCliente}");
                    Console.WriteLine($"Tipo: {pro.Tipo}");
                    Console.WriteLine($"Presupuesto: ${pro.PresupuestoInicial:N2}");
                    Console.WriteLine($"Estado: {pro.Estado}");

                }
            }
        }


            static void AgregarProyecto()
            {


                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("                        AGREGAR PROYECTO");
                Console.WriteLine();

                Console.Write(" ID del Cliente: ");
                int clienteId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Nombre del Proyecto: ");
                string nombre = Console.ReadLine();

                Console.WriteLine(" Tipo de Proyecto:");
                Console.WriteLine("0. Por Hora");
                Console.WriteLine("1. Monto Mensual");
                Console.WriteLine("2. Precio Fijo");
                Console.Write("Seleccione: ");
                int tipoInt = Convert.ToInt32(Console.ReadLine());
                TipoProyecto tipo = (TipoProyecto)tipoInt;

                Console.Write("  Presupuesto Inicial: ");
                double presupuesto = Convert.ToDouble(Console.ReadLine());

                Console.Write("Fecha de Inicio (dd/mm/yyyy): ");
                DateTime fechaInicio = DateTime.Parse(Console.ReadLine());

                Proyecto nuevoProyecto = new Proyecto(clienteId, nombre, tipo, presupuesto, fechaInicio);

                LogicaProyecto logicaproyecto = new LogicaProyecto();
                logicaproyecto.AgregarProyecto(nuevoProyecto);

                Console.WriteLine("  Proyecto agregado exitosamente!");
                Console.ReadKey();
            }



        











    }
}


using Logica;
using Objetos;
using System;
using System.Data;

public class Menu
{
    public Menu()
    {

        public void menuCrearCliente()
    {
        console.writeline("1.CREAR CLIENTE");
        Console.writeline("");
        String rutCliente = console.readline("ingrese su rut");
        string razonSocial = console.readline("ingrese su razon social");
        string direccion = console.readline("ingrese su direccion");
        Cliente nuevoCliente = new Cliente(razonSocial, rutCliente, direccion);
        LogicaClientes logicaClientes = new LogicaClientes();
        String resultado = logicaClientes.IngresarClientes(nuevoCliente);
        consle.writeline(resultado);
    }

    public void menuListarClientes()
    {
        console.writeline("2.LISTAR CLIENTES");
        LogicaClientes logicaClientes = new LogicaClientes();
        DataTable tablaClientes = logicaClientes.ListarClientes();
        foreach (DataRow row in tablaClientes.Rows)
        {
            console.writeline($"ID: {row["Id"]} - Razon Social: {row["RazonSocial"]} - RUT: {row["RUT"]} - Direccion: {row["Direccion"]}");
        }

    }
    public void menuModificarCliente()
    {
        Console.WriteLine("3.MODIFICAR CLIENTE");
        String idClienteStr = console.readline("ingrese el ID del cliente a modificar");
        int idCliente = int.parse(idClienteStr);
        string nuevoRazonSocial = console.readline("ingrese la nueva razon social");
        string nuevoRut = console.readline("ingrese el nuevo RUT");
        string nuevaDireccion = console.readline("ingrese la nueva direccion");
        Cliente clienteModificado = new Cliente(nuevoRazonSocial, nuevoRut, nuevaDireccion);
        clienteModificado.Id = idCliente;
        LogicaClientes logicaClientes = new LogicaClientes();
        String resultado = logicaClientes.ModificarClientes(clienteModificado);
        console.writeline(resultado);
    }
    public void menuEliminarCliente()
    {
        console.writeline("4.ELIMINAR CLIENTE");
        String idClienteStr = console.readline("ingrese el ID del cliente a eliminar");
        int idCliente = int.parse(idClienteStr);
        LogicaClientes logicaClientes = new LogicaClientes();
        String resultado = logicaClientes.EliminarClientes(idCliente);
        console.writeline(resultado);

    }
}

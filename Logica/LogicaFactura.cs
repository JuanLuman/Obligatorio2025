using Objetos;
using Obligatorio.Datos;
using Obligatorio2025.Datos;
using Obligatorio2025.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio2025.Logica
{
    public class LogicaFactura
    {

        public List<FacturaVenta> ListarFactura()
        {
            
            FacturaVentaDatos factura = new FacturaVentaDatos();
            try
            {
                return factura.ListarFacturas();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en listar facturas " + ex.Message);
            }
        }



        public string AgregarFacturaVenta(FacturaVenta factura)
        {
            ClienteDatos clientedatos = new ClienteDatos();
            FacturaVentaDatos facturaventa =new FacturaVentaDatos();

            // Validaciones
            if (factura.IdCliente <= 0)
                throw new Exception("Debe especificar un cliente");

            Cliente cliente = clientedatos.BuscarClientePorId(factura.IdCliente);
            if (cliente == null)
                throw new Exception("El cliente especificado no existe");

            if (factura.Renglones == null || factura.Renglones.Count == 0)
                throw new Exception("La factura debe tener al menos un renglón");

            // Validar montos
            foreach (var renglon in factura.Renglones)
            {
                if (renglon.Monto <= 0)
                    throw new Exception("Los montos deben ser mayores a cero");
            }

            // Calcular totales automáticamente
            factura.CalcularTotales();
           
            try
            {
                facturaventa.AgregarFacturaVenta(factura);
                return "Factura agregada con exito";
            }
            catch (Exception ex)
            {
                return "Error al agregar factura " + ex.Message;
            }
        }




      







    }
}

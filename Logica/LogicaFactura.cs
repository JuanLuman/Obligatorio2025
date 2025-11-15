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

        public List<FacturaVenta> ListarFacturaVenta (DataTable tabla)
        {
            List<FacturaVenta> lista = new List<FacturaVenta>();

            foreach (DataRow fila in tabla.Rows)
            {
                lista.Add(new FacturaVenta
                {
                    NroFactura = Convert.ToInt32(fila["NroFactura "]),
                    IdCliente = Convert.ToInt32(fila["IdCliente"]),
                    FechaInicio = Convert.ToDateTime(fila["FechaInicio"]),
                    SubTotal = Convert.ToDouble(fila["SubTotal"]),
                    IVA = Convert.ToDouble(fila["IVA"]),
                    Total = Convert.ToDouble(fila["Total"])
                });
            }

            return lista;
        }



        

        // Obtener cálculo mensual de IVA e IRAE
        public Calculo ObtenerCalculoMensual(int mes, int anio)
        {
            FacturaVentaDatos facturaventa = new FacturaVentaDatos();

            if (mes < 1 || mes > 12)
                throw new Exception("El mes debe estar entre 1 y 12");

            if (anio < 2000 || anio > DateTime.Now.Year)
                throw new Exception("Año inválido");

            try
            {
                return facturaventa.ObtenerCalculoMensual(mes, anio);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al calcular mensual: " + ex.Message);
            }
        }







    }
}

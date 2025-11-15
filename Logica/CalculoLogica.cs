using Obligatorio2025.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio2025.Logica
{
    public class CalculoLogica
    {



        private FacturaDAO facturaDAO;
        private FacturaCompraDAO facturaCompraDAO;
        private CalculoMensualDAO calculoDAO;

        public CalculoMensualLogica()
        {
            facturaDAO = new FacturaDAO();
            facturaCompraDAO = new FacturaCompraDAO();
            calculoDAO = new CalculoMensualDAO();
        }

        public CalculoMensual CalcularMensual(int anio, int mes)
        {
            try
            {
                var facturas = facturaDAO.ListarPorMes(anio, mes);
                var compras = facturaCompraDAO.ListarPorMes(anio, mes);

                decimal totalVentas = facturas.Sum(f => f.SubTotal);
                decimal ivaVentas = facturas.Sum(f => f.IVA);
                decimal totalCompras = compras.Sum(c => c.SubTotal);
                decimal ivaCompras = compras.Sum(c => c.IVA);

                var calculo = new CalculoMensual
                {
                    Anio = anio,
                    Mes = mes,
                    TotalVentas = totalVentas,
                    TotalCompras = totalCompras,
                    IVAVentas = ivaVentas,
                    IVACompras = ivaCompras,
                    IVAResultante = ivaVentas - ivaCompras,
                    IRAE = totalVentas * 0.12m, // 12% de facturación
                    FechaCalculo = DateTime.Now
                };

                // Guardar el cálculo
                calculoDAO.GuardarCalculo(calculo);

                return calculo;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al calcular mensual: " + ex.Message);
            }
        }

        public CalculoMensual ConsultarCalculo(int anio, int mes)
        {
            try
            {
                return calculoDAO.ObtenerPorMes(anio, mes);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar cálculo: " + ex.Message);
            }
        }




















    }
}

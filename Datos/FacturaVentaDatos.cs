using Objetos;
using Obligatorio.Datos;
using Obligatorio2025.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio2025.Datos
{
    public class FacturaVentaDatos
    {



        public List<FacturaVenta> ListarFacturas()
        {
            var listarFacturas = new List<FacturaVenta>();
            ConexionBD conexion = new ConexionBD();

            using (SqlConnection con = conexion.AbrirConexion())
            {
                using (SqlCommand comando = new SqlCommand("ListarFacturas", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    try
                    {


                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var factura = new FacturaVenta
                                {
                                    NroFactura = reader.GetInt32(reader.GetOrdinal("NroFactura")),
                                    IdCliente = reader.GetInt32(reader.GetOrdinal("IdCliente ")),
                                    IdProyecto = reader.GetInt32(reader.GetOrdinal("IdProyecto ")),
                                    FechaInicio = reader.GetDateTime(reader.GetOrdinal("  FechaInicio  ")),
                                    SubTotal = reader.GetDouble(reader.GetOrdinal(" SubTotal")),
                                    IVA = reader.GetDouble(reader.GetOrdinal(" IVA ")),
                                    Total = reader.GetDouble(reader.GetOrdinal("Total")),
                                    Descripcion = reader.GetString(reader.GetOrdinal(" Descripcion  ")),



                                };

                                listarFacturas.Add(factura);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error al listar facturas " + ex.Message);
                    }
                    finally 
                    {
                        conexion.CerrarConexion();
                        
                    }
                }
            }

            return listarFacturas;
        }




        public void AgregarFacturaVenta(FacturaVenta factura)
        {

            if (factura.IdCliente <= 0)
                throw new Exception("Debe seleccionar un cliente.");

            foreach (var ren in factura.Renglones)
            {
                if (ren.Monto <= 0)
                    throw new Exception("Debe ingresar un monto mayor a cero.");
                if (string.IsNullOrWhiteSpace(ren.Descripcion))
                    throw new Exception("Debe tener una descripción.");
            }

            ConexionBD conexion = new ConexionBD();

            using (SqlConnection con = conexion.AbrirConexion())
            {
                
                SqlTransaction tx = con.BeginTransaction();

                try
                {
                    int nuevoIdFactura = 0;

                    using (SqlCommand comando = new SqlCommand("InsertarFacturaVenta", con, tx))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.AddWithValue("@IdCliente", factura.IdCliente);
                        comando.Parameters.AddWithValue("@NroFactura", factura.NroFactura);
                        comando.Parameters.AddWithValue("@IdProyecto", factura.IdProyecto);
                        comando.Parameters.AddWithValue("@FechaInicio", factura.FechaInicio);

                        SqlParameter outputId = new SqlParameter("@NuevoIdFactura", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        comando.Parameters.Add(outputId);
                        comando.ExecuteNonQuery();

                        nuevoIdFactura = Convert.ToInt32(outputId.Value);
                    }

                    // inserto renglon
                    foreach (var renglon in factura.Renglones)
                    {
                        using (SqlCommand comando = new SqlCommand("InsertarDetalleFactura", con, tx))
                        {
                            comando.CommandType = CommandType.StoredProcedure;

                            comando.Parameters.AddWithValue("@IdFactura", nuevoIdFactura);
                            comando.Parameters.AddWithValue("@Monto", renglon.Monto);
                            comando.Parameters.AddWithValue("@Descripcion", renglon.Descripcion);

                            comando.ExecuteNonQuery();
                            comando.Parameters.Clear();
                        }
                    }

                    // Confirmar si todo salió bien
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
                finally 
                {
                    conexion.CerrarConexion();
                  
                }
            }
        }




        




    }
}

using Objetos;
using Obligatorio.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    internal class LogicaProyecto
    {
        Proyecto proyecto = new Proyecto();
        ProyectoDatos datos = new ProyectoDatos();
        //metodo para agregar proyecto

        public String agregarProyecto(Proyecto proyecto)
        {
            try
            {
                
                datos.IngresarProyecto(proyecto);
                return "Proyecto agregado con exito";
            }
            catch (Exception ex)
            {
                return "Error al agregar proyecto: " + ex.Message;
            }
        }

        public String EliminarProyecto(int idProyecto)
        {
            try
            {
                datos.EliminarProyecto(idProyecto);
                return "Proyecto eliminado con exito";
            }
            catch (Exception ex)
            {
                return "Error al eliminar proyecto: " + ex.Message;
            }
        }

        public String ActualizarProyecto(Proyecto proyecto)
        {
            try
            {
                datos.ActualizarProyecto(proyecto);
                return "Proyecto actualizado con exito";
            }
            catch (Exception ex)
            {
                return "Error al actualizar proyecto: " + ex.Message;
            }
        }
    }
}

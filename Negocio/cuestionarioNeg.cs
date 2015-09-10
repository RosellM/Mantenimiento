using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
namespace Negocio
{
   public class cuestionarioNeg
    {

        public List<seccion> ListarSecciones()
        {
            return new cuestionarioDat().ListarSecciones();
        }

        public List<test> ListarTest()
        {
            return new cuestionarioDat().ListarTest();
        }

        public List<cuestionarioEntidad> cuestionario(int id_seccion) 
        {
            return new cuestionarioDat().obtenerCuestionarios(id_seccion);
        }

       public List<resultado> ListarResultados()
        {
          
            return new cuestionarioDat().resultados();
        }
    }
}

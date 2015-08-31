using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
namespace Negocio
{
   public class resultadoNeg
    {

        public List<resultado> listarresultado()
        {
            return new ResultadoDat().listarresultado();
        }

        public void nuevoresultado(resultado resultado)
        {
            new ResultadoDat().nuevoresultado(resultado);
        }

        public resultado obtenerresultadoPorID(int id)
        {
            return new ResultadoDat().obtenerresultadoPorId(id);
        }

        public void eliminarresultado(int id)
        {
            new ResultadoDat().eliminarresultado(id);
        }

        public void modificarresultado(resultado resultado)
        {
            new ResultadoDat().modificarresultado(resultado);
        }

    }
}

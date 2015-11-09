using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entidades
{
    public class cuestionarioEntidad
    {
        public cuestionarioEntidad(pregunta pregunta,List<resultado> resultados)
        {
          
            this.pregunta = pregunta;
            this.resultados = resultados;
        }

        public cuestionarioEntidad() 
        {

        }

        public pregunta pregunta { get; set; }
        public List<resultado> resultados { get; set; }
      

    }
}

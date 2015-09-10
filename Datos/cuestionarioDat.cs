using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Datos
{
    public class cuestionarioDat
    {

        public List<seccion> ListarSecciones() 
        {
            return new bdscecEntities().seccion.ToList();
        }

        public List<test> ListarTest() 
        {
            return new bdscecEntities().test.ToList();
        }

        public List<cuestionarioEntidad> obtenerCuestionarios(int id_seccion) 
        {
            List<cuestionarioEntidad> cuestionariosEntidad = new List<cuestionarioEntidad>();
            bdscecEntities bd = new bdscecEntities();
            List<pregunta> cuestionarios = (from p in bd.pregunta where p.id_seccion == id_seccion select p).ToList();
            List<resultado> resultados = bd.resultado.ToList();
            foreach(var c in  cuestionarios)
            {
                cuestionariosEntidad.Add(new cuestionarioEntidad(c,this.resultados()));
            }

            return cuestionariosEntidad;
        }

        public List<resultado>resultados() 
        {
            bdscecEntities bd = new bdscecEntities();
           List<resultado> resultados = (from res in bd.resultado select res).OrderBy(s=>Guid.NewGuid()).Take(3).ToList<resultado>();
           
            return resultados;
        }

    }
}


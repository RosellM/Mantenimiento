using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ResultadoDat
    {

        public List<resultado> listarresultado()
        {
           
                return new bdscecEntities().resultado.ToList();
            
        }

        public void nuevoresultado(resultado resultado)
        {
            using (bdscecEntities bd = new bdscecEntities())
            {

                try
                {
                    bd.resultado.Add(resultado);
                    bd.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    throw e;
                }

            }
        }

        public void modificarresultado(resultado resultado)
        {
            resultado getresultado;
            using (var ctx = new bdscecEntities())
            {
                try
                {
                    getresultado = ctx.resultado.Where(s => s.id == resultado.id).FirstOrDefault<resultado>();
                }
                catch (DbEntityValidationException e)
                {
                    throw e;
                }

            }

            if (getresultado != null)
            {

                getresultado.respuesta = resultado.respuesta;
                getresultado.id_pregunta = resultado.id_pregunta;

            }


            using (var dbCtx = new bdscecEntities())
            {

                dbCtx.Entry(getresultado).State = EntityState.Modified;

                dbCtx.SaveChanges();
            }
        }

        public resultado obtenerresultadoPorId(int id)
        {
            using (bdscecEntities bd = new bdscecEntities())
            {
                resultado resultado = (from e in bd.resultado where e.id == id select e).First();
                return resultado;
            }
        }

        public void eliminarresultado(int id)
        {
            using (bdscecEntities bd = new bdscecEntities())
            {
                try
                {
                    var resultadoAEliminar = (from e in bd.resultado where e.id == id select e).First();
                    bd.resultado.Remove(resultadoAEliminar);
                    bd.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    throw e;
                }
            }
        }


    }
}

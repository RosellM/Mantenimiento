using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.Entity.Validation;
using System.Data.Entity;
namespace Datos
{
   public class estadoDat
    {

       public List<estados> listarEstados() 
       {

           using (bdscecEntities bd = new bdscecEntities()) 
           {

               return bd.estados.ToList();
           
           }
       
       }

       public void guardarEstado(estados estado)
       {
           using (bdscecEntities bd = new bdscecEntities())
           {

               try
               {

                   bd.estados.Add(estado);
                   bd.SaveChanges();
               }
               catch (DbEntityValidationException e)
               {

                   throw e;
               }

           }
       }

       public int eliminarEstado( int id) 
       {
           using(bdscecEntities bd = new bdscecEntities())
           {
               try {

                  

                      var estadoAEliminar = (from e in bd.estados where e.id == id select e).First();
                      bd.estados.Remove(estadoAEliminar);
                      bd.SaveChanges();
                      return 1;
                  
                   
               }catch(DbEntityValidationException e)
               {
                   return 0;
               }
           }

          
       }

       public estados obtenerEstadoPorId(int id)
       {
          using(bdscecEntities bd = new bdscecEntities())
          {
              estados estadoAModificar = (from e in bd.estados where e.id == id select e).First();
              return estadoAModificar;
          }
       }



       public void modificarEstado(estados estado)
       {
          try
            {
                estados getEstado;
                using (var ctx = new bdscecEntities())
                {
                    try {
                        getEstado = ctx.estados.Where(s => s.id == estado.id).FirstOrDefault<estados>();
                    }
                    catch (DbEntityValidationException e) 
                    
                    {
                        throw e;
                    }
               
                }

                if (getEstado != null)
                {
                    getEstado.nombre = estado.nombre;
                    getEstado.descripcion = estado.descripcion;
                }

                
                using (var dbCtx = new bdscecEntities())
                {

                    dbCtx.Entry(getEstado).State = EntityState.Modified;

                    dbCtx.SaveChanges();
                }
            }
          catch (DbEntityValidationException r)
          {
              throw r;
          }
       }


    }


}

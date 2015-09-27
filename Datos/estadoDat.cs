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
                      if (estadoAEliminar != null) 
                      {
                          this.eliminarRelacionEstadoCiudad(estadoAEliminar.id);
                          bd.estados.Remove(estadoAEliminar);
                          bd.SaveChanges();
                          return 1;    
                      }
                      return 0;
                    
               }catch(DbEntityValidationException e)
               {
                   return 0;
               }
           }   
       }

       public void eliminarRelacionEstadoCiudad(int idEstado) 
       {

           using (bdscecEntities bd = new bdscecEntities())
           {
               try
               {
                   List<ciudad> ciudadAEliminar = (from e in bd.ciudad where e.idEstado == idEstado select e).ToList();

                   if (ciudadAEliminar != null) 
                   {
                       foreach (var ciudad in ciudadAEliminar)
                       {

                           this.obtenerPersonasporIdCiudad(ciudad.id);
                           bd.ciudad.Remove(ciudad);
                           bd.SaveChanges();
                       }
                   
                   }

                   
            }
               catch (DbEntityValidationException e)
               {
                   throw e; ;
               }
           }
       }

       public void obtenerPersonasporIdCiudad(int idciudad )
       {

           using (bdscecEntities bd = new bdscecEntities()) 
           {
               List<personas> personaList = (from e in bd.personas where e.idCiudad == idciudad select e).ToList();
               if (personaList != null) 
               {
                   foreach (var persona in personaList)
                   {
                       bd.personas.Remove(persona);
                       bd.SaveChanges();
                   }
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

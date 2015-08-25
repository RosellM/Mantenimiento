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
   public class personasDat
    {

       public List<personas> listarPersonas() 
       {
           return new bdscecEntities().personas.ToList();
       }


       public void nuevaPersona(personas persona)
       {

           using (bdscecEntities bd = new bdscecEntities()) 
           {

               try
               {

                   bd.personas.Add(persona);
                   bd.SaveChanges();
               }
               catch (DbEntityValidationException e)
               {

                   return;
               }


           }

       }

       public personas obtenerPersonaPorID(int id)
       {
       
           using(bdscecEntities bd = new bdscecEntities())
           {

               try
               {
                   var personas = (from p in bd.personas where p.id == id select p).First();

                   return personas;
               }
               catch (DbEntityValidationException e)
               {

                   throw e;

               }

             
           }

       }

       public void modificarPersona(personas personas)
       {
           try
           {
               personas getPersonas;
               using (var ctx = new bdscecEntities())
               {
                   try
                   {
                       getPersonas = ctx.personas.Where(p => p.id == personas.id).FirstOrDefault<personas>();
                   }
                   catch (DbEntityValidationException e)
                   {
                       throw e;
                   }

               }

               if (getPersonas != null)
               {
                   getPersonas.Nombres = personas.Nombres;
                   getPersonas.Direccion = personas.Direccion;
                   getPersonas.Apellidos = personas.Apellidos;
                   getPersonas.idCiudad = personas.idCiudad;
                   getPersonas.id = personas.id;

               }


               using (var dbCtx = new bdscecEntities())
               {

                   dbCtx.Entry(getPersonas).State = EntityState.Modified;

                   dbCtx.SaveChanges();
               }
           }
           catch (DbEntityValidationException e)
           {
               throw e;
           }
       }

       public void eliminarPersonas(int id) 
       {
           using (bdscecEntities bd = new bdscecEntities()) 
           {

               try
               {

                   var personasEliminar = (from p in bd.personas where p.id == id select p).First();
                   bd.personas.Remove(personasEliminar);
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

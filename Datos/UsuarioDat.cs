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
   public class UsuarioDat
    {

       public void nuevoUser(usuario user)
       {
           using (bdscecEntities bd = new bdscecEntities()) 
           {
               try {
                   bd.usuario.Add(user);
                   bd.SaveChanges();
               }
               catch(Exception e)
               {
                   throw e;
               
               }  
           }
       }    

       public usuario obtenerUsuarioPorNombre(String name)
       {
           using (bdscecEntities bd = new bdscecEntities()) 
           {
               try {

                   usuario user = (from us in bd.usuario where us.nombre == name select us).First();

                   if (user != null)
                   {
                       return user;
                   }
                   return null;
               }

               catch(Exception e)
               {
                   return null;
               }
               
             
           }
       }

       public roles obtenerRol(int id_rol)
       {
           using (bdscecEntities bd = new bdscecEntities()) 
           {

               roles rol = (from rl in bd.roles where rl.id == id_rol select rl).First();
               return rol;
           }

       }

       public void modificarUsuario(usuario usuario)
       {

           using (bdscecEntities bd = new bdscecEntities())
           {
               usuario getUsuario;
               using (var ctx = new bdscecEntities())
               {
                   try
                   {
                       getUsuario = ctx.usuario.Where(s => s.id == usuario.id).FirstOrDefault<usuario>();

                       if (getUsuario != null)
                       {
                           getUsuario.nombre = usuario.nombre;
                           getUsuario.nombreApellidoMaterno =usuario.nombreApellidoMaterno;
                           getUsuario.nombreApellidoPaterno = usuario.nombreApellidoPaterno;
                          
                       }

                       ctx.Entry(getUsuario).State = EntityState.Modified;

                       ctx.SaveChanges();
                   }
                   catch (DbEntityValidationException e)
                   {
                       throw e;
                   }

               }
           }
       
       }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
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



    }
}


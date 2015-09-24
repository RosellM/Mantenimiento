using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
namespace Negocio
{
   public class UsuarioNeg
    {

       public void nuevoUser(usuario user)
       {
           new UsuarioDat().nuevoUser(user);
       }

       public roles obtenerRol(int id_rol) 
       {

           return new UsuarioDat().obtenerRol(id_rol);
       
       }

       public usuario obtenerUsuario( string name ) 
       {


           usuario user = new UsuarioDat().obtenerUsuarioPorNombre(name);
           if (user != null) 
           {

               return user;
           
           }

           return null;
           
       }



    }
}

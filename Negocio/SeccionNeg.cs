using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
namespace Negocio
{
   public class SeccionNeg
   {

       public List<seccion> listarseccion()
       {
           return new SeccionDat().listarseccion();
       }

       public void nuevoseccion(seccion seccion)
       {
           new SeccionDat().nuevoseccion(seccion);
       }

       public seccion obtenerseccionPorID(int id)
       {
           return new SeccionDat().obtenerseccionPorId(id);
       }

       public void eliminarseccion(int id)
       {
           new SeccionDat().eliminarseccion(id);
       }

       public void modificarseccion(seccion seccion)
       {
           new SeccionDat().modificarseccion(seccion);
       }

    }
}

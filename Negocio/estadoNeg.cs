using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
namespace Negocio
{
   public class estadoNeg
    {

       public List<estados> listarEstados() 
       {

           return new estadoDat().listarEstados();
       
       }

       public void nuevoEstado(estados estado) 
       {
           new estadoDat().guardarEstado(estado);
       }

       public int eliminarEstado(int id)
       {
        return new estadoDat().eliminarEstado(id);
       }

       public estados obtenerEstadoPorId(int id) 
       {
         return new estadoDat().obtenerEstadoPorId(id);
       }

       public void modificarEstado(estados estado)
       {
           new estadoDat().modificarEstado(estado);
       }

    }
}

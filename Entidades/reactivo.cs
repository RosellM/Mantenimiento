using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class reactivo
   {
       public reactivo( int idPregunta, string respuesta) 
       {
           this.idPregunta = idPregunta;
           this.respuesta = respuesta;
       
       }
       public int id { get; set; }
       public int idPregunta { get; set; }
       public string respuesta { get; set; }  
   }
}

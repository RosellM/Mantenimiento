//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entidades
{
    using Datos;
    using System;
    using System.Collections.Generic;
    
    public partial class pregunta
    {
        public pregunta()
        {
            this.resultado = new HashSet<resultado>();
        }
    
        public int id { get; set; }
        public int id_seccion { get; set; }
        public string pregunta1 { get; set; }
        public string respuesta { get; set; }
        public string reactivo_a { get; set; }
        public string reactivo_b { get; set; }
        public string reactivo_c { get; set; }
    
        public virtual seccion seccion { get; set; }
        public virtual ICollection<resultado> resultado { get; set; }
    }
}

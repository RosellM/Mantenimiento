using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades;
using Negocio;
using System.Collections;
using Datos;
namespace Mantenimiento.Models
{
    public class cuestionarioModel
    {
        public List<seccion> secciones = new List<seccion>();
        public int flag{ get;set;}
        public Array respuestas;
        /*Auxialiares para Json*/
        public int id_pregunta { get; set; }
        public string respuesta { get; set; }

        public int auxiliarSeccion { get;set; }
        /*Auxialiares para Json*/
        public int id_Tst { get; set; }
        public int Auxiliarname = 0;
        public int id { get; set; }
        public string nombre { get; set; }
        public List<pregunta> listaPreguntas {get;set;}
        public List<resultado> r { get; set; }
       
        
        public List<seccion> ListarSecciones()
        {
            return new cuestionarioNeg().ListarSecciones();
        }

        public void ListarSecciones(int id_Test)
        {
            this.secciones = new cuestionarioNeg().ListarSecciones(id_Test);
        }

        public List<seccion> listForCuestions() 
        {
            return this.secciones;
        }

        public List<test> ListarTest()
        {
            return new cuestionarioNeg().ListarTest();
        }

        public void cuestionario(int id_seccion)
        {
            listaPreguntas =  new cuestionarioNeg().cuestionario(id_seccion);
         //   this.auxiliarSeccion = id_seccion;
        }


        public List<String> verResultados(string[] ids_pregunta, string[] respuesta,string id_seccion) 
        {
            this.auxiliarSeccion = Int32.Parse(id_seccion);
            cuestionarioNeg negocio = new cuestionarioNeg();
            return negocio.calificarCuestionario(ids_pregunta,respuesta,this.auxiliarSeccion);
        
        }





    }
}
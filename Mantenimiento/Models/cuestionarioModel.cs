﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades;
using Negocio;
namespace Mantenimiento.Models
{
    public class cuestionarioModel
    {
        public int Auxiliarname = 0;
        public int id { get; set; }
        public string nombre { get; set; }
        public List<cuestionarioEntidad> listaPreguntas {get;set;}
        public List<resultado> r { get; set; }
        public List<seccion> ListarSecciones()
        {
            return new cuestionarioNeg().ListarSecciones();
        }

        public List<test> ListarTest()
        {
            return new cuestionarioNeg().ListarTest();
        }

        public void cuestionario(int id_seccion)
        {
            listaPreguntas =  new cuestionarioNeg().cuestionario(id_seccion);
        }

        public void ListarResultados(List<resultado> reas) 
        {
            r = new cuestionarioNeg().ListarResultados();
            reas = r;
            
        }

        




    }
}
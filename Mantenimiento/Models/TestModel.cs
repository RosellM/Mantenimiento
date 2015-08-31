using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Entidades;
using Negocio;

namespace Mantenimiento.Models
{
    public class TestModel
    {

        public int id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "NOMBRE DEL NUEVO TEST")]
        public string nombre { get; set; }

        public List<test> listarTest()
        {
            return new TestNeg().listarTest();
        }

        public void nuevoTest(test test)
        {
            new TestNeg().nuevoTest(test);
        }

        public test obtenerTestPorId(int id) 
        {
            return new TestNeg().obtenerTestPorID(id);
        }

        public void modificarTest(test test) 
        {
            new TestNeg().modificarTest(test);
        }


        public void eliminarTest(int id)
        {
            new TestNeg().eliminarTest(id);
        }
    }
}
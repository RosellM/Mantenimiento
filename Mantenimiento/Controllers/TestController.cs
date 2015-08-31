using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mantenimiento.Models;
using Entidades;

namespace Mantenimiento.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            return View(new TestModel());
        }

        public ActionResult Nuevo() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TestModel test)
        {
           test t = new test();
           t.nombre = test.nombre;
           new TestModel().nuevoTest(t);
           return View("Index", new TestModel());

        }

        public ActionResult modificarTest(int id) 
        {
            TestModel tm = new TestModel();
            test test = new TestModel().obtenerTestPorId(id);
            tm.nombre = test.nombre;
            tm.id = test.id;
            return View(tm);
            
        }

        [HttpPost]
        public ActionResult modificarTest(TestModel test) 
        {
            test t = new test();
            t.nombre = test.nombre;
            t.id = test.id;
            new TestModel().modificarTest(t);
            return View("Index",new TestModel());
        }

        public ActionResult eliminarTest(int id) 
        {
            new TestModel().eliminarTest(id);
            return View("Index", new TestModel());
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mantenimiento.Models;
using Entidades;
namespace Mantenimiento.Controllers
{
    public class SeccionController : Controller
    {
        //
        // GET: /Seccion/

        public ActionResult Index()
        {
            return View(new SeccionModel());
        }

        public ActionResult Nuevo(int? id)
        {

            if (id == null)
            {
                SeccionModel model = new SeccionModel();
                return View(model);
            }
            else
            {
                SeccionModel model = new SeccionModel();
                model.id_test= (int)id;
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Nuevo(SeccionModel Seccion)
        {

            seccion p = new seccion();
            p.id_test = Seccion.id_test;
            p.nombre = Seccion.nombre;
            new SeccionModel().NuevaSeccion(p);
            return RedirectToAction("Index", "Test", new TestModel());

        }

        public ActionResult modificarSeccion(int id)
        {
            seccion seccion = new SeccionModel().obtenerSeccionPorId(id);
            SeccionModel pm = new SeccionModel();
            pm.nombre = seccion.nombre;
            pm.id_test = seccion.id_test;
            pm.id = seccion.id;
            return View(pm);
        }

        [HttpPost]
        public ActionResult modificarSeccion(SeccionModel Seccion)
        {
            new SeccionModel().modificarSeccion(Seccion);
            return RedirectToAction("Index", "Seccion", new SeccionModel());
        }

        public ActionResult eliminarSeccion(int id)
        {
            new SeccionModel().eliminarSeccion(id);
            return RedirectToAction("Index", "Seccion", new SeccionModel());

            // return View("Index", new SeccionModel());
        }

    }
}

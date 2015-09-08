using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mantenimiento.Models;
namespace Mantenimiento.Controllers
{
    public class cuestionarioController : Controller
    {
        //
        // GET: /cuestionario/

        public ActionResult Index()
        {
            
            return View(new cuestionarioModel());
        }

        public ActionResult Secciones() 
        {
            return View(new cuestionarioModel());
        }

        public ActionResult IniciarTest(int id)
        {
            cuestionarioModel model = new cuestionarioModel();
            model.cuestionario(id);
            return View(model);
        }
       

    }
}

using Mantenimiento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mantenimiento.Controllers
{
    public class ciudadController : Controller
    {
        //
        // GET: /ciudad/

        public ActionResult Index()
        {
            
            return View(new ciudadModel());
        }

        public ActionResult nuevaCiudad() 
        {
            return View(new ciudadModel());
        }

        public ActionResult nuevaCiudad(ciudadModel ciudad)
        {
            return View(new ciudadModel());
        }
    }
}

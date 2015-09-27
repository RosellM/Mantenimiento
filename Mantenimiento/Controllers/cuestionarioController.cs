using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mantenimiento.Models;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Collections;
namespace Mantenimiento.Controllers
{
    public class cuestionarioController : Controller
    {
        //
        // GET: /cuestionario/
       
        public ActionResult Index( int? flag)
        {
            if (Session["user"] as string == "user")
                ViewBag.user = "user";
            else
                ViewBag.user = null;
            return View(new cuestionarioModel());
        }

      
        public ActionResult Secciones(int id,int? flag) 
        {
            if (Session["user"] as string == "user")
                ViewBag.user = "user";
            else
                ViewBag.user = null;

            cuestionarioModel model = new cuestionarioModel();
            model.id_Tst = id;
            model.ListarSecciones(id);
            return View(model);
        }
  
        public ActionResult IniciarTest(int id, int? flag)
        {
            if (Session["user"] as string == "user")
                ViewBag.user = "user";
            else
                ViewBag.user = null;
            cuestionarioModel model = new cuestionarioModel();
            model.cuestionario(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult enviarRespuestas(string [] array_id,string [] array_value)
        {

            cuestionarioModel model = new cuestionarioModel();
            return Json(model.verResultados(array_id,array_value));

        }
    }
}

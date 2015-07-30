using Entidades;
using Mantenimiento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Mantenimiento.Controllers
{
    public class rolController : Controller
    {
        //
        // GET: /rol/

        public ActionResult Index()
        {
            RolModel rol = new RolModel();
            return View(rol);
        }


        public ActionResult Nuevo(RolModel rol) 
        {
            RolModel rl = new RolModel();
            roles Rol = new roles();
            Rol.nombre = rol.nombre;
            Rol.descripcion = rol.descripcion;
            rl.nuevoRol(Rol);
            ViewBag.Rol = rl;
            return View("All");

        }

        public ActionResult All() 
        {
            RolModel rl = new RolModel();
            ViewBag.Rol = rl;
            return View();
        
        }

        public ActionResult Eliminar(int id) 
        {

            RolModel rl = new RolModel();
            rl.eliminarRol(id);
            ViewBag.Rol = rl;
            return View("All");
        }
    }
}

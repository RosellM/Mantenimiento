using Entidades;
using Mantenimiento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mantenimiento.Controllers
{
    public class principalController : Controller
    {
        //
        // GET: /principal/

        public ActionResult Index()
        {
            if (Session["user"] as string == "admin")
            {

                ViewBag.user = Session["username"] as string;
                return View();
            }
            else 
            {
                return RedirectToAction("Index", "Home");
            }
                           
        }

        public ActionResult user(String name) 
        {
            UsuarioModel model = new UsuarioModel();
            if(model.obtenerUsuario(name))
            {
                if (model.rol.nombre == "user") 
                {
                    ViewBag.user = name;
                    return View();
                }
                else
                {
                    return RedirectToAction("Index","Home");
                }
            }
            else{
                return RedirectToAction("Index","Home");
            }
        }

        public ActionResult modificarUsuario(string name) 
        {

            UsuarioModel model = new UsuarioModel();
            model.obtenerUsuario(name);
            return View("modificar",model);

        }

        [HttpPost]
        public ActionResult modificarUsuario(UsuarioModel user) 
        {
            usuario us = new usuario();
            us.nombre = user.nombre;
            us.id = user.id;
            us.nombreApellidoMaterno = user.nombreApellidoMaterno;
            us.nombreApellidoPaterno = user.nombreApellidoPaterno;

            user.modificarUsuario(us);

            if (Session["user"] as string == "admin") 
            {
                return RedirectToAction("Index","Principal");
            }
            else
            {
                Session.Remove("username");
                UsuarioModel model = new UsuarioModel();
                model.obtenerUsuario(user.nombre);
                Session["username"] = model.nombre;
                string usuario = Session["username"] as string;
                return RedirectToAction("user", "Principal", new { name = usuario});

            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mantenimiento.Models;
namespace Mantenimiento.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            Session.Remove("user");
            Session.Remove("username");
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username) 
        {
            Session.Remove("user");
            Session.Remove("username");
            UsuarioModel model = new UsuarioModel();

            if (model.obtenerUsuario(username))
            {

                if (model.rol.nombre == "admin")
                {
                    Session["user"] = model.rol.nombre;
                    Session["username"] = username;
                    return RedirectToAction("Index","principal");
                }
                else 
                {
                    Session["username"] = username;
                    Session["user"] = model.rol.nombre;
                    string nombre = Session["username"] as string;
                    return RedirectToAction("user", "principal", new {name= nombre });
                    
                }

            }
            else {

                return RedirectToAction("Registrarse", "Home");
            
            }


         

        }

        public ActionResult Registrarse() 
        {
            return View();
        }


        [HttpPost]
        public ActionResult Registrarse(string[] array_data) 
        {
            try
            {
                UsuarioModel model = new UsuarioModel();
                model.nombre = array_data[0].ToString();
                model.nombreApellidoMaterno = array_data[1].ToString();
                model.nombreApellidoPaterno = array_data[2].ToString();
                model.idRol = Int32.Parse(array_data[3]);
                model.nuevoUser();
                 return this.RedirectToAction("Index","Home");
            }
            
            catch (Exception e) 
            {
                return this.RedirectToAction("Index","Home");
            }


           

          
        }

    }
}

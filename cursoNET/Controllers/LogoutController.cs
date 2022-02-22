using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cursoNET.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult LogOut()
        {
            Session["User"] = null;

            return RedirectToAction("Index", "Access"); //Metodo, controlado
        }
    }
}
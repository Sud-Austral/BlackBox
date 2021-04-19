using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AplicacionBlanco.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Resultado()
        {
            return View();
        }

        public ActionResult Subscripciones()
        {
            return View();
        }
    }
}
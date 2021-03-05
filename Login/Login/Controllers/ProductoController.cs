using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Elecciones_HN()
        {
            ViewBag.url = "https://odooutil.azurewebsites.net/design/eleccioneshn";
            return View();
        }
    }
}
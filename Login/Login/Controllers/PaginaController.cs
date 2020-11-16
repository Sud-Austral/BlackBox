using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login.Models;
using Microsoft.AspNet.Identity;

namespace Login.Controllers
{
    [Authorize]
    public class PaginaController : Controller
    {
        Correos correos = new Correos();
        // GET: Pagina
        public ActionResult Index(string Hola)
        {
            if (Request.IsAuthenticated)
            {
                ViewBag.saludo = "Paso por aca";
            }
            //ViewBag.saludo = Hola;
            return View();
        }

        public ActionResult Validador(string url, string idOrden)
        {
            //var url = db.pedidos.Where(x => x.cliente.id == id && x.producto.id == producto).FirstOrDefault();
            if (url == null)
            {
                return View("Restriccion");
            }
            if (url.Contains("showLayers"))
            {
                bool flag = true;
            }
            Session["url"] = url;
            Session.Timeout = 1;

            return Redirect("Dashboard");
        }

        public ActionResult Restriccion(int cliente, int producto)
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            ViewBag.url = (string)Session["url"];
            string user = User.Identity.GetUserName();
            ViewBag.user = user;
            List<string> aux = correos.correos;
            if (!aux.Contains(user))
            {
                return View("Restriccion");
            }
            if (ViewBag.url == null)
            {
                return View("Restriccion");
            }
            return View();
        }

        public ActionResult DashboardDataImpacto()
        {
            return View();
        }
    }
}
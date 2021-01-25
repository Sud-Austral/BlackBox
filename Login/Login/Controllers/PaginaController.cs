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

        public ActionResult Validador(string url, string idOrden, string saturno, string nombre)
        {
            string ola = url;
            if (!Util.fechaLimite(saturno, nombre))
            {
                ViewBag.enlaceShopify = "https://dataintelligence.store/" + nombre;
                return View("errorTiempo");
            }
            //url = "https://sud-austral.maps.arcgis.com/apps/View/index.html?appid=8968a78812d644858916532e46c7dec3&extent=-120.5127,6.3355,-45.2343,37.5955";
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
        [OutputCache(Duration =1, Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult DashboardDataImpacto()
        {
            return View();
        }
        [AllowAnonymous]
        [OutputCache(Duration = 1, Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult DashboardDataImpactoFree()
        {
            return View("DashboardDataImpacto");
        }
        [AllowAnonymous]
        public ActionResult DashboardArgis()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Trayectorias()
        {
            return View();
        }

        public ActionResult errorTiempo()
        {
            return View();
        }


    }
}
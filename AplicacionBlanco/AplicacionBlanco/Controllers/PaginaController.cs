using AplicacionBlanco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AplicacionBlanco.Controllers
{
    public class PaginaController : Controller
    {
        static Database db = new Database();
        // GET: Pagina
        public ActionResult Index(string id, string producto)
        {
            var url = db.pedidos.Where(x => x.cliente.id == id && x.producto.id == producto).FirstOrDefault();
            return View();
        }

        public ActionResult Dashboard()
        {
            ViewBag.url = (string)Session["url"];
            if(ViewBag.url == null)
            {
                return View("Restriccion");
            }
            return View();
        }

        public ActionResult Validador(string id, string producto)
        {
            var url = db.pedidos.Where(x => x.cliente.id == id && x.producto.id == producto).FirstOrDefault();
            if(url == null)
            {
                return View("Restriccion");
            }
            Session["url"] = url.producto.url;
            Session.Timeout = 1;

            return Redirect("Dashboard");
        }

        public ActionResult Restriccion(int cliente, int producto)
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult Clent(string id)
        {
            return View();
        }


    }
}
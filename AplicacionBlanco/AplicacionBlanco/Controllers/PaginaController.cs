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
        public ActionResult Index()
        {
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

        public ActionResult Validador(int cliente, int producto)
        {
            var url = db.pedidos.Where(x => x.cliente.id == cliente && x.producto.id == producto).FirstOrDefault();
            if(url == null)
            {
                return View("Restriccion");
            }
            Session["url"] = url.producto.url;

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


    }
}
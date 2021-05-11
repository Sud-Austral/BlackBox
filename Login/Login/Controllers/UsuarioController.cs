using Login.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        //Base de datos de los graficos
        private graficosEntities dbGrafico = new graficosEntities();

        //Constructor del controlador
        public UsuarioController()
        {

        }
        // GET: Usuario
        public ActionResult Index()
        {
            //Lista de productos de Shopify
            List<Producto_Shopify> productos = new List<Producto_Shopify>();
            //Nombre de Usuario
            ViewBag.User = User.Identity.GetUserName();
            //foreach (var item in APIShopify.BuscarOrdenesPorMail(User.Identity.GetUserName()))
            foreach (var item in APIShopify.BuscarOrdenesPorMail(User.Identity.GetUserName()))
            {
                foreach (var item2 in item["line_items"])
                {
                    try
                    {
                        productos.Add(new Producto_Shopify(item2, (string)item["order_status_url"], item));
                    }
                    catch (Exception)
                    {

                        string hola = "";
                    }
                    
                }
            }
            //Objeto que separa Productos y Suscripciones
            ShopifyYSuscripciones shopifyYSuscripciones = new ShopifyYSuscripciones(productos);
            //Productos
            productos = shopifyYSuscripciones.producto_Shopifies;
            //ViewBag.url = (string)Session["url"];
            Session["Productos"] = productos;
            //Suscripciones
            Session["Suscripcion"] = shopifyYSuscripciones.suscripcions;
            ViewBag.Resultado = productos;
            //ViewBag.Menu = dbGrafico.INDUSTRIA.ToList();
            //Menu que esta suscrito el usuario
            //ViewBag.Menu = dbGrafico.INDUSTRIA.Where(x => shopifyYSuscripciones.industrias.Contains(x.id)).ToList();
            ViewBag.Menu = dbGrafico.INDUSTRIA.Where(x => x.id==10).ToList();
            return View();
        }

        
        public ActionResult Suscripcion()
        {
            List<Producto_Shopify> productos = new List<Producto_Shopify>();
            ViewBag.User = User.Identity.GetUserName();
            //ViewBag.Resultado = APIShopify.BuscarOrdenes();
            //ViewBag.Resultado = APIShopify.BuscarOrdenesPorMail();
            //var test = APIShopify.BuscarOrdenesPorMail();
            //foreach (var item in APIShopify.BuscarOrdenesPorMail(User.Identity.GetUserName()))
            foreach (Newtonsoft.Json.Linq.JToken item in APIShopify.BuscarOrdenesPorMail())
            {
                foreach (var item2 in item["line_items"])
                {

                    productos.Add(new Producto_Shopify(item2, (string)item["order_status_url"], item));
                }
            }
            //ViewBag.url = (string)Session["url"];
            Session["Productos"] = productos;
            ViewBag.Resultado = productos;
            return View();
        }

        //**************************************************************************************************************************************************************************
        //**************************************************************************************************************************************************************************
        //**************************************************************************************************************************************************************************
        //**************************************************************************************************************************************************************************
        //
        //                                                    Desde Aqui todos los objetos son de pruebas para desarrollo
        //
        //**************************************************************************************************************************************************************************
        //**************************************************************************************************************************************************************************
        //**************************************************************************************************************************************************************************
        //**************************************************************************************************************************************************************************
        //**************************************************************************************************************************************************************************

        public JsonResult MenuBusqueda(int id, int id2)
        {
            //var salida;
            switch (id2)
            {
                case 1:
                    string salida = dbGrafico.INDUSTRIA.Where(x => x.id == id).First().nombre;
                    return Json(salida, JsonRequestBehavior.AllowGet);
                    //break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    break;
            }
            return null;
            
        }
        public JsonResult MenuBusqueda(string id)
        {
            return Json(id, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetNombre()
        {
            List<Producto_Shopify> productos = new List<Producto_Shopify>();
            ViewBag.User = User.Identity.GetUserName();
            //ViewBag.Resultado = APIShopify.BuscarOrdenes();
            //ViewBag.Resultado = APIShopify.BuscarOrdenesPorMail();
            //var test = APIShopify.BuscarOrdenesPorMail();
            //foreach (var item in APIShopify.BuscarOrdenesPorMail(User.Identity.GetUserName()))
            foreach (var item in APIShopify.BuscarOrdenesPorMail())
            {
                foreach (var item2 in item["line_items"])
                {

                    productos.Add(new Producto_Shopify(item2, (string)item["order_status_url"], item));
                }
            }
            ShopifyYSuscripciones shopifyYSuscripciones = new ShopifyYSuscripciones(productos);

            //return Json(shopifyYSuscripciones.producto_Shopifies, JsonRequestBehavior.AllowGet);
            //return Json(productos[0].SKU.Contains("datasuscripcion"), JsonRequestBehavior.AllowGet);
            //return Json(dbGrafico.INDUSTRIA.Where(x => shopifyYSuscripciones.industrias.Contains(x.id)).ToList(), JsonRequestBehavior.AllowGet);
            return Json(productos, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Usuaria2()
        {
            ViewBag.Lista = dbGrafico.INDUSTRIA.ToList();

            //Lista de productos de Shopify
            List<Producto_Shopify> productos = new List<Producto_Shopify>();
            //Nombre de Usuario
            ViewBag.User = User.Identity.GetUserName();
            //foreach (var item in APIShopify.BuscarOrdenesPorMail(User.Identity.GetUserName()))
            foreach (var item in APIShopify.BuscarOrdenesPorMail())
            {
                foreach (var item2 in item["line_items"])
                {
                    productos.Add(new Producto_Shopify(item2, (string)item["order_status_url"], item));
                }
            }
            //Objeto que separa Productos y Suscripciones
            ShopifyYSuscripciones shopifyYSuscripciones = new ShopifyYSuscripciones(productos);
            //Productos
            productos = shopifyYSuscripciones.producto_Shopifies;
            //ViewBag.url = (string)Session["url"];
            Session["Productos"] = productos;
            //Suscripciones
            Session["Suscripcion"] = shopifyYSuscripciones.suscripcions;
            ViewBag.Resultado = productos;
            //ViewBag.Menu = dbGrafico.INDUSTRIA.ToList();
            //Menu que esta suscrito el usuario
            ViewBag.Menu = dbGrafico.INDUSTRIA.Where(x => shopifyYSuscripciones.industrias.Contains(x.id)).ToList();
            return View();
        }

        public ActionResult Dashboard(string id = null)
        {
            List<Producto_Shopify> productos = (List<Producto_Shopify>)Session["Productos"];
            if (productos == null)
            {
                 productos = new List<Producto_Shopify>();
                //Nombre de Usuario
                ViewBag.User = User.Identity.GetUserName();
                //foreach (var item in APIShopify.BuscarOrdenesPorMail(User.Identity.GetUserName()))
                foreach (var item in APIShopify.BuscarOrdenesPorMail())
                {
                    foreach (var item2 in item["line_items"])
                    {
                        productos.Add(new Producto_Shopify(item2, (string)item["order_status_url"], item));
                    }
                }
                //Objeto que separa Productos y Suscripciones
                ShopifyYSuscripciones shopifyYSuscripciones = new ShopifyYSuscripciones(productos);
                //Productos
                productos = shopifyYSuscripciones.producto_Shopifies;
                //ViewBag.url = (string)Session["url"];
                Session["Productos"] = productos;
                //Suscripciones
                Session["Suscripcion"] = shopifyYSuscripciones.suscripcions;
            }
            string url = "";
            try
            {
                 url = productos.Where(x => x.ID == id).First().SKU;
            }
            catch (Exception)
            {

                url = productos[0].SKU;
            }
            

            ViewBag.url = url; //"https://www.c-sharpcorner.com/article/html-action-and-html-renderaction-in-Asp-Net-mvc/";
            string user = User.Identity.GetUserName();
            ShopifyYSuscripciones shopifyYSuscripciones2 = new ShopifyYSuscripciones(productos);
            ViewBag.Menu = dbGrafico.INDUSTRIA.Where(x => shopifyYSuscripciones2.industrias.Contains(x.id)).ToList();
            ViewBag.Resultado = productos;
            /*
            ViewBag.user = user;
            List<string> aux = correos.correos;
            if (!aux.Contains(user))
            {
                return View("Restriccion");
            }
            */
            if (ViewBag.url == null)
            {
                return View("Restriccion");
            }
            return View();
        }
    }
}
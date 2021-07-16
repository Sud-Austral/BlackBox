using Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class Data_UsuarioController : Controller
    {
        private graficosEntities1 db = new graficosEntities1();
        private graficosEntities dbGrafico = new graficosEntities();
        // GET: Data_Usuario
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult VisualizarGraficos(decimal id = 1234)
        {
            var rand = new Random();
            TABLA_GENERICA_PRUEBA graf = new TABLA_GENERICA_PRUEBA();
            try
            {
                graf = db.TABLA_GENERICA_PRUEBA.Where(x => x.id == id).First();
            }
            catch (Exception)
            {
                graf = db.TABLA_GENERICA_PRUEBA.First();
            }
            ViewBag.Elemento = graf;//graficos 
            ViewBag.time2 = DateTime.Now;
            return PartialView();
        }
        public ActionResult VisualizarGraficoColecion_Usuario(decimal id = 1234)
        {
            var rand = new Random();
            TABLA_GENERICA_PRUEBA graf = new TABLA_GENERICA_PRUEBA();
            try
            {
                graf = db.TABLA_GENERICA_PRUEBA.Where(x => x.id == id).First();
            }
            catch (Exception)
            {
                graf = db.TABLA_GENERICA_PRUEBA.First();
            }
            ViewBag.Elemento = graf;//graficos 
            ViewBag.time2 = DateTime.Now;
            ViewBag.time2 = DateTime.Now;
            return View();
        }
        public PartialViewResult ContenidoColección()
        {
            return PartialView();
        }
        public PartialViewResult Gráfico_Contenido_Colección()
        {
            return PartialView();
        }
        public PartialViewResult FuentesUsuario()
        {
            return PartialView();
        }
        public PartialViewResult Recursos_Usuario()
        {
            return PartialView();
        }
        public PartialViewResult Tematica()
        {
            return PartialView();
        }
        public PartialViewResult Cosecha()
        {
            return PartialView();
        }
        public PartialViewResult Empresas()
        {
            return PartialView();
        }
        public PartialViewResult Empleados()
        {
            return PartialView();
        }
        public PartialViewResult Produccion()
        {
            return PartialView();
        }
        public PartialViewResult Precios()
        {
            return PartialView();
        }
        public PartialViewResult Importaciones()
        {
            return PartialView();
        }
        public PartialViewResult Exportaciones()
        {
            return PartialView();
        }
        public PartialViewResult Rendimiento()
        {
            return PartialView();
        }
        public ActionResult Suscripciones()
        {
            return View();
        }
        public ActionResult PaginaBusqueda(string id = "1")
        {
            ViewBag.palabra = id;
            IEnumerable<TABLA_GENERICA_PRUEBA> union = UtilBusqueda.PaginaBusquedaData(id);
            if (union.Count() == 0)
            {
                ViewBag.Concepto = id;
                return View("No_Resultado");
            }
            ViewBag.Resultado = union;
            //coleccion	sector	tema	contenido	escala	territorio

            List<string> Coleccion = new List<string>();
            List<string> Sector = new List<string>();
            List<string> Tema = new List<string>();
            List<string> Contenido = new List<string>();
            List<string> Escala = new List<string>();
            List<string> Territorio = new List<string>();

            //var Escala = db.TABLA_GENERICA_PRUEBA.SqlQuery("select DISTINCT escala from tabla_generica_prueba;");
            foreach (var item in union)
            {
                if (!Coleccion.Contains(item.coleccion))
                {
                    Coleccion.Add(item.coleccion);
                }
                if (!Sector.Contains(item.sector))
                {
                    Sector.Add(item.sector);
                }
                if (!Escala.Contains(item.escala))
                {
                    Escala.Add(item.escala);
                }
                if (!Tema.Contains(item.tema))
                {
                    Tema.Add(item.tema);
                }
                if (!Contenido.Contains(item.contenido))
                {
                    Contenido.Add(item.contenido);
                }
                if (!Escala.Contains(item.escala))
                {
                    Escala.Add(item.escala);
                }
                if (!Territorio.Contains(item.territorio))
                {
                    Territorio.Add(item.territorio);
                }

            }
            ViewBag.Coleccion = Coleccion;
            ViewBag.Sector = Sector;
            ViewBag.Escala = Escala;
            ViewBag.Tema = Tema;
            ViewBag.Contenido = Contenido;
            ViewBag.Escala = Escala;
            ViewBag.Territorio = Territorio;
         
            return View();
        }

        public PartialViewResult Data_UsuarioGrafico(decimal id = 1234)
        {
            var rand = new Random();
            TABLA_GENERICA_PRUEBA graf = new TABLA_GENERICA_PRUEBA();
            try
            {
                graf = db.TABLA_GENERICA_PRUEBA.Where(x => x.id == id).First();
            }
            catch (Exception)
            {
                graf = db.TABLA_GENERICA_PRUEBA.First();
            }
            ViewBag.Elemento = graf;//graficos 
            ViewBag.time2 = DateTime.Now;
            ViewBag.time2 = DateTime.Now;
            return PartialView();
        }
    }
}
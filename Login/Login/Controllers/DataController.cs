using Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class DataController : Controller
    {
        private graficosEntities1 db = new graficosEntities1();
        private graficosEntities dbGrafico = new graficosEntities();
        public DataController()
        {

        }
        // GET: Data
        public ActionResult Index()
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

            //List<string> Coleccion = union.Select(x => x.coleccion).Distinct();  //new List<string>();
            //List<string> Sector = new List<string>();
            //List<string> Tema = new List<string>();
            //List<string> Contenido = new List<string>();
            //List<string> Escala = new List<string>();
            //List<string> Territorio = new List<string>();

            var Coleccion = union.Select(x => x.coleccion).Distinct();
            var Sector = union.Select(x => x.sector).Distinct();
            var Tema = union.Select(x => x.tema).Distinct();
            var Contenido = union.Select(x => x.contenido).Distinct();
            var Escala = union.Select(x => x.escala).Distinct();
            var Territorio = union.Select(x => x.coleccion).Distinct();

            //var Escala = db.TABLA_GENERICA_PRUEBA.SqlQuery("select DISTINCT escala from tabla_generica_prueba;");
            //foreach (var item in union)
            //{
            //    if (!Coleccion.Contains(item.coleccion))
            //    {
            //        Coleccion.Add(item.coleccion);
            //    }
            //    if (!Sector.Contains(item.sector))
            //    {
            //        Sector.Add(item.sector);
            //    }
            //    if (!Escala.Contains(item.escala))
            //    {
            //        Escala.Add(item.escala);
            //    }
            //    if (!Tema.Contains(item.tema))
            //    {
            //        Tema.Add(item.tema);
            //    }
            //    if (!Contenido.Contains(item.contenido))
            //    {
            //        Contenido.Add(item.contenido);
            //    }
            //    if (!Escala.Contains(item.escala))
            //    {
            //        Escala.Add(item.escala);
            //    }
            //    if (!Territorio.Contains(item.territorio))
            //    {
            //        Territorio.Add(item.territorio);
            //    }                
            //}
            ViewBag.Coleccion = Coleccion;
            ViewBag.Sector = Sector;
            ViewBag.Escala = Escala;
            ViewBag.Tema = Tema;
            ViewBag.Contenido = Contenido;
            ViewBag.Escala = Escala;
            ViewBag.Territorio = Territorio;
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
            // var listaAsociado = dbGrafico.PRODUCTO.Where(x => x.SECTOR_id == graf.CATEGORIA.PRODUCTO.SECTOR_id).ToList();
            //var listaAsociado = dbGrafico.DATA_GRAFICO.Where(x => x.CATEGORIA.PRODUCTO.SECTOR_id == graf.CATEGORIA.PRODUCTO.SECTOR_id).ToList();

            //List<int> aux = new List<int>();
            //for (int i = 0; i < 50; i++)
            //{
            //    aux.Add(rand.Next(dbGrafico.DATA_GRAFICO.Min(x => x.id), dbGrafico.DATA_GRAFICO.Max(x => x.id)));
            //}
            //var Graficos = dbGrafico.DATA_GRAFICO.Where(x => aux.Contains(x.id)).ToList();
            //ViewBag.Graficos = Graficos;//carrusel
            ViewBag.time2 = DateTime.Now;
            return PartialView();
        }
        //COLECCIONES
        public PartialViewResult Colecciones()
        {
            return PartialView();
        }
        public PartialViewResult Agricultura()
        {
            return PartialView();
        }
        public PartialViewResult Glaciares()
        {
            return PartialView();
        }
        public PartialViewResult Ganaderia()
        {
            return PartialView();
        }
        public PartialViewResult Salud_Enfermedades()
        {
            return PartialView();
        }
        public PartialViewResult Violencia()
        {
            return PartialView();
        }
        public PartialViewResult Pesca()
        {
            return PartialView();
        }
        public PartialViewResult Educacion()
        {
            return PartialView();
        }
        public PartialViewResult Emisiones()
        {
            return PartialView();
        }
        public PartialViewResult Salud_Pandemia()
        {
            return PartialView();
        }
        public PartialViewResult Elecciones()
        {
            return PartialView();
        }
        public PartialViewResult Contaminacion()
        {
            return PartialView();
        }
        public PartialViewResult IngresosCasen()
        {
            return PartialView();
        }
        //FIN COLECCIONES

        public PartialViewResult Visualizar_colección()
        {
            return PartialView();
        }
        public PartialViewResult BusquedaColecciónUsuario()
        {
            return PartialView();
        }
        public PartialViewResult IndexProductos()
        {
            return PartialView();
        }

        public ActionResult TerminosyCondiciones()
        {
            return View();
        }
        public ActionResult Soporte()
        {
            return View();
        }
        public ActionResult VentasCorporativas()
        {
            return View();
        }

        public ActionResult Empleo()
        {
            return View();
        }
        public ActionResult Inversion()
        {
            return View();
        }
        public ActionResult FAQ()
        {
            return View();
        }

        public PartialViewResult Paginacion(string id = "1", int id2 = 1)
        {
            //var NEW_GRAFICOS
            ViewBag.Resultado = db.TABLA_GENERICA_PRUEBA.Where(x => x.titulo.Contains(id) || x.tag.Contains(id))
                                                .OrderBy(x => x.id)
                                                .Skip(200 + 50 * id2)
                                                .Take(50);
            return PartialView();
        }

        public ActionResult PaginaBusqueda2(string id = "1", int id2 = 1)
        {
            //1 Coleccion
            //2 Sector
            //3 Tema
            //4 Contenido
            ViewBag.palabra = id;
            IEnumerable<TABLA_GENERICA_PRUEBA> union;
            switch (id2)
            {
                case 1:
                    union = db.TABLA_GENERICA_PRUEBA.Where(x => x.coleccion.Contains(id));
                    break;
                case 2:
                    union = db.TABLA_GENERICA_PRUEBA.Where(x => x.sector.Contains(id));
                    break;
                case 3:
                    union = db.TABLA_GENERICA_PRUEBA.Where(x => x.tema.Contains(id));
                    break;
                case 4:
                    union = db.TABLA_GENERICA_PRUEBA.Where(x => x.contenido.Contains(id));
                    break;
                default:
                    union = db.TABLA_GENERICA_PRUEBA.Take(200);
                    break;
            }
            ViewBag.Resultado = union;
            var Coleccion = union.Select(x => x.coleccion).Distinct();
            var Sector = union.Select(x => x.sector).Distinct();
            var Tema = union.Select(x => x.tema).Distinct();
            var Contenido = union.Select(x => x.contenido).Distinct();
            var Escala = union.Select(x => x.escala).Distinct();
            var Territorio = union.Select(x => x.coleccion).Distinct();
            ViewBag.Coleccion = Coleccion;
            ViewBag.Sector = Sector;
            ViewBag.Escala = Escala;
            ViewBag.Tema = Tema;
            ViewBag.Contenido = Contenido;
            ViewBag.Escala = Escala;
            ViewBag.Territorio = Territorio;
            return View("PaginaBusqueda");
        }
    }


}
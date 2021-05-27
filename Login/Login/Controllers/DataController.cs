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
        private graficosEntities dbGrafico = new graficosEntities();
        public DataController()
        {

        }
        // GET: Data
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HomeOdoo()
        {
            var rand = new Random();
            List<int> aux = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                aux.Add(rand.Next(dbGrafico.GRAFICO.Min(x => x.id), dbGrafico.GRAFICO.Max(x => x.id)));
            }
            var Graficos = dbGrafico.GRAFICO.Where(x => aux.Contains(x.id)).ToList();
            
            List<GRAFICO> listaGraficos = new List<GRAFICO>();
            for (int i = 0; i < 15; i++)
            {
                listaGraficos.Add(Graficos[rand.Next(Graficos.Count)]);
            }
            ViewBag.Graficos = listaGraficos;
            
            return View();
        }
    }
}
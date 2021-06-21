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
            List<decimal> aux = new List<decimal>();
            for (int i = 0; i < 20; i++)
            {
                aux.Add(rand.Next((int)dbGrafico.DATA_GRAFICO.Min(x => x.id), (int)dbGrafico.DATA_GRAFICO.Max(x => x.id)));
            }
            var Graficos = dbGrafico.DATA_GRAFICO.Where(x => aux.Contains(x.id)).ToList();
            
            List<DATA_GRAFICO> listaGraficos = new List<DATA_GRAFICO>();
            for (int i = 0; i < 15; i++)
            {
                listaGraficos.Add(Graficos[rand.Next(Graficos.Count)]);
            }
            ViewBag.Graficos = listaGraficos;
            
            return View();
        }
    }
}
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
        
    }
}
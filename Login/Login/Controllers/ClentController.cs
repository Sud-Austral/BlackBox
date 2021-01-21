using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class ClentController : Controller
    {
        // GET: Clent
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";

            DateTime fechaInicio = DateTime.Parse("2021, 1, 10");
            DateTime fechaActual = DateTime.Now;

            // Calculo de dias.
            TimeSpan td = fechaActual - fechaInicio;

            // Total de dias.
            //int differenceInDays = ts.Days;
            ViewBag.totalDias = td.Days;


            return View();
        }
    }
}
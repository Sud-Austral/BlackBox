using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Login.Models;

namespace Login.Controllers
{
    public class TABLA_GENERICA_PRUEBAController : Controller
    {
        private graficosEntities1 db = new graficosEntities1();

        // GET: TABLA_GENERICA_PRUEBA
        public ActionResult Index()
        {
            return View(db.TABLA_GENERICA_PRUEBA.ToList());
        }

        // GET: TABLA_GENERICA_PRUEBA/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TABLA_GENERICA_PRUEBA tABLA_GENERICA_PRUEBA = db.TABLA_GENERICA_PRUEBA.Find(id);
            if (tABLA_GENERICA_PRUEBA == null)
            {
                return HttpNotFound();
            }
            return View(tABLA_GENERICA_PRUEBA);
        }

        // GET: TABLA_GENERICA_PRUEBA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TABLA_GENERICA_PRUEBA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,coleccion,idcoleccion,sector,filtro_url,tema,contenido,escala,pais,territorio,filtro_integrado,muestra_temporalidad,temporalidad,unidad_medida,fuente,titulo,descripcion_larga,visualizacion,tag,url,suscripcion,color,id_grafico,id_territorio,id_tema,id_contenido,id_filtro,id_muestra")] TABLA_GENERICA_PRUEBA tABLA_GENERICA_PRUEBA)
        {
            if (ModelState.IsValid)
            {
                db.TABLA_GENERICA_PRUEBA.Add(tABLA_GENERICA_PRUEBA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tABLA_GENERICA_PRUEBA);
        }

        // GET: TABLA_GENERICA_PRUEBA/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TABLA_GENERICA_PRUEBA tABLA_GENERICA_PRUEBA = db.TABLA_GENERICA_PRUEBA.Find(id);
            if (tABLA_GENERICA_PRUEBA == null)
            {
                return HttpNotFound();
            }
            return View(tABLA_GENERICA_PRUEBA);
        }

        // POST: TABLA_GENERICA_PRUEBA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,coleccion,idcoleccion,sector,filtro_url,tema,contenido,escala,pais,territorio,filtro_integrado,muestra_temporalidad,temporalidad,unidad_medida,fuente,titulo,descripcion_larga,visualizacion,tag,url,suscripcion,color,id_grafico,id_territorio,id_tema,id_contenido,id_filtro,id_muestra")] TABLA_GENERICA_PRUEBA tABLA_GENERICA_PRUEBA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tABLA_GENERICA_PRUEBA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tABLA_GENERICA_PRUEBA);
        }

        // GET: TABLA_GENERICA_PRUEBA/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TABLA_GENERICA_PRUEBA tABLA_GENERICA_PRUEBA = db.TABLA_GENERICA_PRUEBA.Find(id);
            if (tABLA_GENERICA_PRUEBA == null)
            {
                return HttpNotFound();
            }
            return View(tABLA_GENERICA_PRUEBA);
        }

        // POST: TABLA_GENERICA_PRUEBA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            TABLA_GENERICA_PRUEBA tABLA_GENERICA_PRUEBA = db.TABLA_GENERICA_PRUEBA.Find(id);
            db.TABLA_GENERICA_PRUEBA.Remove(tABLA_GENERICA_PRUEBA);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

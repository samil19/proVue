using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using proVue;

namespace proVue.Controllers
{
    public class AutomovilesController : Controller
    {
        private VueEntities db = new VueEntities();

        // GET: Automoviles
        public ActionResult Index()
        {
            return View(db.Automovils.ToList());
        }

        public JsonResult Autos()
        {
            return Json(db.Automovils.ToList(), JsonRequestBehavior.AllowGet);
        }

        // GET: Automoviles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automovil automovil = db.Automovils.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            return View(automovil);
        }

        // GET: Automoviles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Automoviles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(Automovil automovil)
        {
            if (ModelState.IsValid)
            {
                db.Automovils.Add(automovil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(automovil);
        }

        // GET: Automoviles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automovil automovil = db.Automovils.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            return View(automovil);
        }

        // POST: Automoviles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Auto,Marca,Modelo,Año_Fabricacion,Tipo,CantPasajeros,TipoTrans,Precio,Tipo_Moneda")] Automovil automovil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(automovil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(automovil);
        }
        
        // GET: Automoviles/Delete/5
       

        // POST: Automoviles/Delete/5
        public ActionResult Delete(int ? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automovil automovil = db.Automovils.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.Automovils.Remove(automovil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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

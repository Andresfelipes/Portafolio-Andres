using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MiTiendaMejorada.Context;

namespace MiTiendaMejorada.Controllers
{
    public class ventasController : Controller
    {
        private Mi_TiendaEntities db = new Mi_TiendaEntities();

        // GET: ventas
        public ActionResult Index()
        {
            List<tb_ventas> ventas = new List<tb_ventas>();
            ventas = db.tb_ventas.ToList();
            int sumaVentas = ventas.Sum(x => x.venta_total);
            ViewBag.sumaVentas = sumaVentas;
            return View(db.tb_ventas.ToList());
        }

        // GET: ventas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ventas tb_ventas = db.tb_ventas.Find(id);
            if (tb_ventas == null)
            {
                return HttpNotFound();
            }
            return View(tb_ventas);
        }

        // GET: ventas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ventas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_ventas,venta_total")] tb_ventas tb_ventas)
        {
            if (ModelState.IsValid)
            {
                db.tb_ventas.Add(tb_ventas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_ventas);
        }

        // GET: ventas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ventas tb_ventas = db.tb_ventas.Find(id);
            if (tb_ventas == null)
            {
                return HttpNotFound();
            }
            return View(tb_ventas);
        }

        // POST: ventas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_ventas,venta_total")] tb_ventas tb_ventas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_ventas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_ventas);
        }

        // GET: ventas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ventas tb_ventas = db.tb_ventas.Find(id);
            if (tb_ventas == null)
            {
                return HttpNotFound();
            }
            return View(tb_ventas);
        }

        // POST: ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_ventas tb_ventas = db.tb_ventas.Find(id);
            db.tb_ventas.Remove(tb_ventas);
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

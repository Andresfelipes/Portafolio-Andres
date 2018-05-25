using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Renta_de_Peliculas.Models;

namespace Renta_de_Peliculas.Controllers
{
    public class RentasController : Controller
    {
        private DBpeliculasEntities1 db = new DBpeliculasEntities1();

        // GET: Rentas
        public ActionResult Index()
        {
            //var rentas = db.Rentas.Include(r => r.Clientes).Include(r => r.Peliculas).Include(r => r.Rentas1).Include(r => r.Rentas2);            
            return View(db.Rentas.ToList());
        }

        // GET: Rentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rentas rentas = db.Rentas.Find(id);
            if (rentas == null)
            {
                return HttpNotFound();
            }
            return View(rentas);
        }

        // GET: Rentas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Peliculas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRenta,idCliente,idPelicula,fecha")] Rentas rentas)
        {
            if (ModelState.IsValid)
            {
                db.Rentas.Add(rentas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rentas);
        }


        // GET: Rentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rentas rentas = db.Rentas.Find(id);
            if (rentas == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCliente = new SelectList(db.Clientes, "idCliente", "nombre", rentas.idCliente);
            ViewBag.idPelicula = new SelectList(db.Peliculas, "idPelicula", "titulo", rentas.idPelicula);
           
            return View(rentas);
        }

        // POST: Rentas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRenta,idCliente,idPelicula,fecha")] Rentas rentas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCliente = new SelectList(db.Clientes, "idCliente", "nombre", rentas.idCliente);
            ViewBag.idPelicula = new SelectList(db.Peliculas, "idPelicula", "titulo", rentas.idPelicula);
            
            return View(rentas);
        }

        // GET: Rentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rentas rentas = db.Rentas.Find(id);
            if (rentas == null)
            {
                return HttpNotFound();
            }
            return View(rentas);
        }

        // POST: Rentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rentas rentas = db.Rentas.Find(id);
            db.Rentas.Remove(rentas);
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

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
    public class productosController : Controller
    {
        private Mi_TiendaEntities db = new Mi_TiendaEntities();

        // GET: productos
        public ActionResult Index()
        {
            var tb_productos = db.tb_productos.Include(t => t.tb_proveedores);
            return View(tb_productos.ToList());
        }

        // GET: productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_productos tb_productos = db.tb_productos.Find(id);
            if (tb_productos == null)
            {
                return HttpNotFound();
            }
            return View(tb_productos);
        }

        // GET: productos/Create
        public ActionResult Create()
        {
            ViewBag.id_proveedor = new SelectList(db.tb_proveedores, "id_proveedor", "nombre_proveedor");
            return View();
        }

        // POST: productos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_productos,producto_nombre,producto_precio,producto_cantidad,producto_descripcion,id_proveedor")] tb_productos tb_productos)
        {
            if (ModelState.IsValid)
            {
                db.tb_productos.Add(tb_productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_proveedor = new SelectList(db.tb_proveedores, "id_proveedor", "nombre_proveedor", tb_productos.id_proveedor);
            return View(tb_productos);
        }

        // GET: productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_productos tb_productos = db.tb_productos.Find(id);
            if (tb_productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_proveedor = new SelectList(db.tb_proveedores, "id_proveedor", "nombre_proveedor", tb_productos.id_proveedor);
            return View(tb_productos);
        }

        // POST: productos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_productos,producto_nombre,producto_precio,producto_cantidad,producto_descripcion,id_proveedor")] tb_productos tb_productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_proveedor = new SelectList(db.tb_proveedores, "id_proveedor", "nombre_proveedor", tb_productos.id_proveedor);
            return View(tb_productos);
        }

        // GET: productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_productos tb_productos = db.tb_productos.Find(id);
            if (tb_productos == null)
            {
                return HttpNotFound();
            }
            return View(tb_productos);
        }

        // POST: productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_productos tb_productos = db.tb_productos.Find(id);
            db.tb_productos.Remove(tb_productos);
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
        // GET: productos/Edit/5
        public ActionResult ventaProductos(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_productos tb_productos = db.tb_productos.Find(id);
            if (tb_productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_proveedor = new SelectList(db.tb_proveedores, "id_proveedor", "nombre_proveedor", tb_productos.id_proveedor);
            return View(tb_productos);
        }

        // POST: productos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ventaProductos([Bind(Include = "id_productos,producto_nombre,producto_precio,producto_cantidad,producto_descripcion,id_proveedor")] tb_productos tb_productos, int cantidadProducto, int precioVenta)
        {
            if (ModelState.IsValid)
            {
                tb_ventas ventas = new tb_ventas();
                ventas.id_ventas++;
                ventas.venta_total = precioVenta;

                db.tb_ventas.Add(ventas);

                tb_productos.producto_cantidad = tb_productos.producto_cantidad - cantidadProducto;
                db.Entry(tb_productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_proveedor = new SelectList(db.tb_proveedores, "id_proveedor", "nombre_proveedor", tb_productos.id_proveedor);
            return View(tb_productos);
        }

        public ActionResult precioVenta(int id_Producto, int cantidad_producto)
        {
            var valorProducto = (from producto in db.tb_productos
                                 where producto.id_productos == id_Producto
                                 select producto.producto_precio).FirstOrDefault();
            int valor = int.Parse(valorProducto.ToString());
            return Content((valor * cantidad_producto).ToString());
        }
            
    }
}

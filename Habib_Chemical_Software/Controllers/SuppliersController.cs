using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Habib_Chemical_Software;
using Habib_Chemical_Software.BO;

namespace Habib_Chemical_Software.Controllers
{
    public class SuppliersController : Controller
    {
        SuppliersBO db = new SuppliersBO();

        // GET: Suppliers
        public ActionResult Index()
        {
            var suppliers = db.GetAll();
            return View(suppliers.ToList());
        }

        // GET: Suppliers/Details/5
        public ActionResult Details(int id = 0)
        {
            Supplier supplier = db.GetById(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // GET: Suppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "name,contact_number,address,email")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Add(supplier);
                return RedirectToAction("Index");
            }
            
            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public ActionResult Edit(int id = 0)
        {
            Supplier supplier = db.GetById(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,contact_number,address,email")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Update(supplier);
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public ActionResult Delete(int id = 0)
        {
            Supplier supplier = db.GetById(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Delete(id);
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

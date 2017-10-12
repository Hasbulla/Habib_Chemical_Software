using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Habib_Chemical_Software;

namespace Habib_Chemical_Software.Controllers
{
    public class ProductsController : Controller
    {
        private Habib_ChemicalsEntities db = new Habib_ChemicalsEntities();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.User).Include(p => p.User1).Include(p => p.Weight_Type1);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.category_id = new SelectList(db.Categories, "id", "Name");
            ViewBag.created_by = new SelectList(db.Users, "id", "name");
            ViewBag.updated_by = new SelectList(db.Users, "id", "name");
            ViewBag.weight_type = new SelectList(db.Weight_Type, "id", "name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,category_id,country,company,product_type,weight_type,weight_per_bag,description,current_amount,photo,created_by,updated_by,update_date,deleted")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.category_id = new SelectList(db.Categories, "id", "Name", product.category_id);
            ViewBag.created_by = new SelectList(db.Users, "id", "name", product.created_by);
            ViewBag.updated_by = new SelectList(db.Users, "id", "name", product.updated_by);
            ViewBag.weight_type = new SelectList(db.Weight_Type, "id", "name", product.weight_type);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.category_id = new SelectList(db.Categories, "id", "Name", product.category_id);
            ViewBag.created_by = new SelectList(db.Users, "id", "name", product.created_by);
            ViewBag.updated_by = new SelectList(db.Users, "id", "name", product.updated_by);
            ViewBag.weight_type = new SelectList(db.Weight_Type, "id", "name", product.weight_type);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,category_id,country,company,product_type,weight_type,weight_per_bag,description,current_amount,photo,created_by,updated_by,update_date,deleted")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.category_id = new SelectList(db.Categories, "id", "Name", product.category_id);
            ViewBag.created_by = new SelectList(db.Users, "id", "name", product.created_by);
            ViewBag.updated_by = new SelectList(db.Users, "id", "name", product.updated_by);
            ViewBag.weight_type = new SelectList(db.Weight_Type, "id", "name", product.weight_type);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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

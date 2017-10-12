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
    public class UsersController : Controller
    {
        UsersBO db = new UsersBO();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.GetAll();
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int id = 0)
        {
            User user = db.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            //ViewBag.created_by = new SelectList(db.Users, "id", "name");
            //ViewBag.updated_by = new SelectList(db.Users, "id", "name");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "name,contact_number,address,email,password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Add(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id = 0)
        {
            User user = db.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,contact_number,address,email,password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Update(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id = 0)
        {
            User user = db.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
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

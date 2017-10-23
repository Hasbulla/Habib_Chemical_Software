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
    public class Monthly_BillController : Controller
    {
        Monthly_Bill_BO db = new Monthly_Bill_BO();
        Habib_ChemicalsEntities hef = new Habib_ChemicalsEntities();

        // GET: Monthly_Bill
        public ActionResult Index()
        {

            var MonthlyBills = db.GetAll();
            return View(MonthlyBills.ToList());
        }

        // GET: Monthly_Bill/Details/5
        public ActionResult Details(int id = 0)
        {
            Monthly_Bill monthlyBill = db.GetById(id);

            if (monthlyBill == null)
            {
                return HttpNotFound();
            }
            return View(monthlyBill);
        }

        // GET: Monthly_Bill/Create
        public ActionResult Create()
        {
            ViewBag.monthly_bill_id = new SelectList(hef.Monthly_Bill_Name, "id", "name");
            return View();
        }

        // POST: Monthly_Bill/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "date,monthly_bill_id,description,amount,payment_date")] Monthly_Bill monthly_Bill)
        {
            if (ModelState.IsValid)
            {

                db.Add(monthly_Bill);
                return RedirectToAction("Index");
            }

            ViewBag.monthly_bill_id = new SelectList(hef.Monthly_Bill_Name, "id", "name", monthly_Bill.monthly_bill_id);
            return View(monthly_Bill);
        }

        // GET: Monthly_Bill/Edit/5
        public ActionResult Edit(int id = 0)
        {
            Monthly_Bill monthlyBill = db.GetById(id);
            if (monthlyBill == null)
            {
                return HttpNotFound();
            }
            ViewBag.monthly_bill_id = new SelectList(hef.Monthly_Bill_Name, "id", "name", monthlyBill.monthly_bill_id);
            return View(monthlyBill);
        }

        // POST: Monthly_Bill/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,date,monthly_bill_id,description,amount,payment_date")] Monthly_Bill monthly_Bill)
        {
            if (ModelState.IsValid)
            {
                db.Update(monthly_Bill);
                return RedirectToAction("Index");
            }
            ViewBag.monthly_bill_id = new SelectList(hef.Monthly_Bill_Name, "id", "name", monthly_Bill.monthly_bill_id);
            return View(monthly_Bill);
        }

        // GET: Monthly_Bill/Delete/5
        public ActionResult Delete(int id = 0)
        {
            Monthly_Bill monthlyBill = db.GetById(id);
            if (monthlyBill == null)
            {
                return HttpNotFound();
            }
            return View(monthlyBill);
        }

        // POST: Monthly_Bill/Delete/5
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

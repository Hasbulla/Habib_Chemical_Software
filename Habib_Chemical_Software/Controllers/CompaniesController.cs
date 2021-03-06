﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Habib_Chemical_Software;
using Habib_Chemical_Software.BO;
using System.Dynamic;

namespace Habib_Chemical_Software.Controllers
{
    public class CompaniesController : Controller
    {
        CompanyBO db = new CompanyBO();
        Habib_ChemicalsEntities habib_ChemicalsEntities = new Habib_ChemicalsEntities();

        // GET: Companies
        public ActionResult Index()
        {
            var companies = db.GetAll();
            return View(companies.ToList());
        }

        // GET: Companies/Details/5
        public ActionResult Details(int id = 0)
        {
            Company companies = db.GetById(id);
            if (companies == null)
            {
                return HttpNotFound();
            }
            return View(companies);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Garments", Value = "Garments", Selected = true });
            items.Add(new SelectListItem { Text = "Washing", Value = "Washing" });
            ViewBag.CompanyType = items;

            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "name,address,email,company_type")] Company company, string dynamicName1, string dynamicName2, string dynamicName3, string dynamicName4, string dynamicContact1, string dynamicContact2, string dynamicContact3, string dynamicContact4)
        {
            var RequestInformation = Request.Params.AllKeys.ToList();
            if (ModelState.IsValid)
            {
                db.Add(company, dynamicName1, dynamicName2, dynamicName3, dynamicName4, dynamicContact1, dynamicContact2, dynamicContact3, dynamicContact4);
                return RedirectToAction("Index");
            }

            return View(company);
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(int id = 0)
        {
            Company company = db.GetById(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            var contactPerson = habib_ChemicalsEntities.Company_Contact_Persons.Where(u => u.company_id == id).ToList();
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Garments", Value = "Garments", Selected = true });
            items.Add(new SelectListItem { Text = "Washing", Value = "Washing" });
            ViewBag.CompanyType = items;
            ViewBag.ContactPersons = contactPerson;
            //dynamic mymodel = new ExpandoObject();
            //mymodel.company = company;
            //mymodel.ContactPersons = contactPerson;

            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,address,email,company_type")] Company company, string dynamicName1, string dynamicName2, string dynamicName3, string dynamicName4, string dynamicContact1, string dynamicContact2, string dynamicContact3, string dynamicContact4)
        {
            if (ModelState.IsValid)
            {
                db.Update(company, dynamicName1, dynamicName2, dynamicName3, dynamicName4, dynamicContact1, dynamicContact2, dynamicContact3, dynamicContact4);
                return RedirectToAction("Index");
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(int id = 0)
        {
            Company company = db.GetById(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Delete/5
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

using Habib_Chemical_Software.BO;
using System.Linq;
using System.Web.Mvc;

namespace Habib_Chemical_Software.Controllers
{
    public class ProductsController : Controller
    {
        ProductsBO db = new ProductsBO();
        Habib_ChemicalsEntities hef = new Habib_ChemicalsEntities();

        // GET: Products
        public ActionResult Index()
        {
            var companies = db.GetAll();
            return View(companies.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int id = 0)
        {
            Product companies = db.GetById(id);
            if (companies == null)
            {
                return HttpNotFound();
            }
            return View(companies);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.category_id = new SelectList(hef.Categories, "id", "Name");
            ViewBag.weight_type = new SelectList(hef.Weight_Type, "id", "name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "name,category_id,country,company,product_type,weight_type,weight_per_bag,description,current_amount,photo")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Add(product);
                return RedirectToAction("Index");
            }

            ViewBag.category_id = new SelectList(hef.Categories, "id", "Name", product.category_id);
            ViewBag.weight_type = new SelectList(hef.Weight_Type, "id", "name", product.weight_type);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id = 0)
        {
            Product product = db.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.category_id = new SelectList(hef.Categories, "id", "Name", product.category_id);
            ViewBag.weight_type = new SelectList(hef.Weight_Type, "id", "name", product.weight_type);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,category_id,country,company,product_type,weight_type,weight_per_bag,description,current_amount,photo")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Update(product);
                return RedirectToAction("Index");
            }
            ViewBag.category_id = new SelectList(hef.Categories, "id", "Name", product.category_id);
            ViewBag.weight_type = new SelectList(hef.Weight_Type, "id", "name", product.weight_type);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id = 0)
        {
            Product product = db.GetById(id);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Habib_Chemical_Software.BO
{
    public class ProductsBO
    {
        Shared<Product> rep = new Shared<Product>();
        Habib_ChemicalsEntities hef = new Habib_ChemicalsEntities();
        public IEnumerable<Product> GetAll()
        {
            return rep.GetAll(c => c.deleted == false);
        }
        public Product GetById(int id)
        {
            return rep.GetById(id);
        }
        public Product Add(Product entity)
        {
            return rep.Add(entity);
        }
        public void Update(Product product, string path = null)
        {
            Product pro = hef.Products.Find(product.id);

            product.photo = pro.photo;
            product.deleted = pro.deleted;
            product.created_by = pro.created_by;
            product.updated_by = pro.updated_by;
            product.update_date = pro.update_date;
            product.current_amount = pro.current_amount;
            hef.Entry(pro).State = System.Data.Entity.EntityState.Detached;
            
            if (path != null)
            {
                product.photo = path;
            }

            hef.Entry(product).State = System.Data.Entity.EntityState.Modified;
            hef.SaveChanges();

            //rep.Update(product);
        }
        public void Delete(int id)
        {
            rep.Delete(id);
        }
        public void delete_only_image(int id)
        {
            Product pro = GetById(id);
            string fullPath = "";
            try
            {
                fullPath = HttpContext.Current.Request.MapPath(pro.photo);
            }
            catch
            { }
            if (fullPath != "" && File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
        public void Dispose()
        {
            rep.Dispose();
        }
    }
}
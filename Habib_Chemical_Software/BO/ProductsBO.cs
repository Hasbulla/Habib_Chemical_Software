using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Habib_Chemical_Software.BO
{
    public class ProductsBO
    {
        Shared<Product> rep = new Shared<Product>();
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
        public void Update(Product entity)
        {
            rep.Update(entity);
        }
        public void Delete(int id)
        {
            rep.Delete(id);
        }
        public void Dispose()
        {
            rep.Dispose();
        }
    }
}
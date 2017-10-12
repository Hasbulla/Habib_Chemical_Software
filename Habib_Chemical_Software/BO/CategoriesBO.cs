using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Habib_Chemical_Software.BO
{
    public class CategoriesBO
    {
        Shared<Category> rep = new Shared<Category>();
        public IEnumerable<Category> GetAll()
        {
            //var users = hc.Users.Select(x => new { x.address, x.name, x.contact_number, x.email, x.password }).ToList();
            return rep.GetAll(c=>c.deleted==false);
        }
        public Category GetById(int id)
        {
            return rep.GetById(id);
        }
        public Category Add(Category entity)
        {
            return rep.Add(entity);
        }
        public void Update(Category entity)
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Habib_Chemical_Software.BO
{
    public class CompanyBO
    {
        Shared<Company> rep = new Shared<Company>();
        public IEnumerable<Company> GetAll()
        {
            return rep.GetAll(c => c.deleted == false);
        }
        public Company GetById(int id)
        {
            return rep.GetById(id);
        }
        public Company Add(Company entity)
        {
            return rep.Add(entity);
        }
        public void Update(Company entity)
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
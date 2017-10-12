using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Habib_Chemical_Software.BO
{
    public class SuppliersBO
    {
        Shared<Supplier> rep = new Shared<Supplier>();
        Habib_ChemicalsEntities hc = new Habib_ChemicalsEntities();
        public IEnumerable<Supplier> GetAll()
        {
            //var users = hc.Users.Select(x => new { x.address, x.name, x.contact_number, x.email, x.password }).ToList();
            return rep.GetAll(c => c.deleted == false);
        }
        public Supplier GetById(int id)
        {
            return rep.GetById(id);
        }
        public Supplier Add(Supplier entity)
        {
            return rep.Add(entity);
        }
        public void Update(Supplier entity)
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
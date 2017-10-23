using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Habib_Chemical_Software.BO
{
    public class Monthly_Bill_BO
    {
        Shared<Monthly_Bill> rep = new Shared<Monthly_Bill>();
        public IEnumerable<Monthly_Bill> GetAll()
        {
            //var users = hc.Users.Select(x => new { x.address, x.name, x.contact_number, x.email, x.password }).ToList();
            return rep.GetAll(c => c.deleted == false);
        }
        public Monthly_Bill GetById(int id)
        {
            return rep.GetById(id);
        }
        public Monthly_Bill Add(Monthly_Bill entity)
        {
            return rep.Add(entity);
        }
        public void Update(Monthly_Bill entity)
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
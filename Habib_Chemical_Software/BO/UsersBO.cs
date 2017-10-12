using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Habib_Chemical_Software.BO
{
    public class UsersBO
    {
        Shared<User> rep = new Shared<User>();
        Habib_ChemicalsEntities hc = new Habib_ChemicalsEntities();
        public IEnumerable<User> GetAll()
        {
            //var users = hc.Users.Select(x => new { x.address, x.name, x.contact_number, x.email, x.password }).ToList();
            return rep.GetAll(c => c.deleted == false);
        }
        public User GetById(int id)
        {
            return rep.GetById(id);
        }
        public User Add(User entity)
        {
            return rep.Add(entity);
        }
        public void Update(User entity)
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
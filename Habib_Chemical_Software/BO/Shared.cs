using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace Habib_Chemical_Software.BO
{
    public class Shared<T> : IDisposable where T : class
    {
        Habib_ChemicalsEntities db = ContextHelper.GetContext(); // new Habib_ChemicalsEntities();
        DbSet<T> ds;
        public Shared()
        {
            ds = db.Set<T>();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return ds.Where(filter).ToList();
        }

        public T GetById(int id)
        {
            return ds.Find(id);
        }

        public T Add(T entity, int created_by = 0)
        {
            ds.Add(entity);
            //TrySetProperty(entity, "created_by", created_by);
            TrySetProperty(entity, "update_date", DateTime.UtcNow);
            db.SaveChanges();
            return entity;
        }

        public void Update(T entity, int updated_by = 0)
        {
            //TrySetProperty(entity, "updated_by", created_by);
            TrySetProperty(entity, "update_date", DateTime.UtcNow);
            db.Entry<T>(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = ds.Find(id);
            TrySetProperty(entity, "deleted", true);
            db.Entry<T>(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        private void TrySetProperty(object obj, string property, object value)
        {
            var prop = obj.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite)
                prop.SetValue(obj, value, null);
        }
    }
}
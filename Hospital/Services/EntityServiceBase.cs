using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Hospital.Services
{
    public class EntityServiceBase<T> : ICRUD<T> where T : class
    {
        protected ApplicationContext dbctx;
        protected Action<T[]> AfterRead;
        public EntityServiceBase()
        {
            dbctx = new ApplicationContext();
        }

        public void Create(T item)
        {
            dbctx = new ApplicationContext();
            dbctx.Add(item);
            dbctx.SaveChanges();
        }

        public void Update(T item)
        {
            dbctx = new ApplicationContext();
            dbctx.Attach(item);

            var collections = dbctx.Entry(item).Collections;
            foreach (var collection in collections)
            {
                if (collection.CurrentValue == null)
                    continue;

                foreach (var element in collection.CurrentValue)
                    if (dbctx.Entry(element).State == EntityState.Unchanged)
                        dbctx.Entry(element).State = EntityState.Modified;
            }

            foreach (var element in dbctx.Entry(item).References)
            {
                if (element.CurrentValue == null)
                    continue;

                if (dbctx.Entry(element.CurrentValue).State == EntityState.Unchanged)
                    dbctx.Entry(element.CurrentValue).State = EntityState.Modified;
            }

            dbctx.Update(item);
            dbctx.SaveChanges();

            dbctx.Entry(item).State = EntityState.Detached;
        }

        public T[] Read()
        {
            dbctx = new ApplicationContext();
            var dbset = dbctx.Set<T>();
            var items = dbset.ToArray();
            AfterRead?.Invoke(items);
            return items;
        }

        public void Delete(T item)
        {
            dbctx = new ApplicationContext();
            dbctx.Remove(item);
            dbctx.SaveChanges();
        }
    }
}

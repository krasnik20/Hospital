using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public T[] Read(Func<T, bool> Filter)
        {
            dbctx = new ApplicationContext();
            IEnumerable<T> query = dbctx.Set<T>();

            if(Filter != null)
                query = query.Where(Filter);

            var items = query.ToArray();
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

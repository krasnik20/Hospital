using System.Linq;

namespace Hospital.Services
{
    public class ServiceBase<T> where T : class
    {
        protected readonly ApplicationContext dbctx;
        public ServiceBase()
        {
            dbctx = new ApplicationContext();
        }

        public T Create(T item)
        {
            dbctx.Add(item);
            dbctx.SaveChanges();
            return item;
        }

        public void Update(T item)
        {
            dbctx.Update(item);
            dbctx.SaveChanges();
        }

        public T[] Read()
        {
            var dbset = dbctx.Set<T>();
            return dbset.ToArray();
        }

        public void Delete(T item)
        {
            dbctx.Remove(item);
            dbctx.SaveChanges();
        }
    }
}

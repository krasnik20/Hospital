using System;

namespace Hospital.Services
{
    public interface ICRUD <TEntity>
    {
        void Create(TEntity item);
        void Update(TEntity item);
        TEntity[] Read(Func<TEntity, bool> Filters = null);
        void Delete(TEntity item);
    }
}

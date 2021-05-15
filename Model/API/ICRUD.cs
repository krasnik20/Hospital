using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public interface ICRUD <TEntity>
    {
        TEntity Create(TEntity item);
        void Update(TEntity item);
        TEntity[] Read();
        TEntity Delete(TEntity item);
    }
}

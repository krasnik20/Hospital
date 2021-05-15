namespace Hospital.Services
{
    public interface ICRUD <TEntity>
    {
        void Create(TEntity item);
        void Update(TEntity item);
        TEntity[] Read();
        void Delete(TEntity item);
    }
}

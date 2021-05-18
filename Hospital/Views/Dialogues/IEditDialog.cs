namespace Hospital.Views.Dialogues
{
    public interface IEditDialog<T> where T : class
    {
        public void SetEntity(T entity);
    }
}

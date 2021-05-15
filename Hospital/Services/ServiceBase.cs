namespace Hospital.Services
{
    public abstract class ServiceBase
    {
        protected readonly ApplicationContext applicationContext;
        public ServiceBase()
        {
            applicationContext = new ApplicationContext();
        }
    }
}

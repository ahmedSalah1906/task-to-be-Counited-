namespace Task_1.Repository
{
    public interface IRepositoryCRUd<T> : IRepository
    {
         T GetById(int id);
         void DeleteById(int id);
         List<T> GetAll();
         T Create (T entity);
         T Update (T entity);

    }
}

namespace Task_1.Service
{
    public interface ICRUDSerive<T> : IService
    {
        void Create(T entity);
         void Update (T entity);
        List<T> GetAll();
        T GetById(int id);
        void Delete(int id);
    }
}

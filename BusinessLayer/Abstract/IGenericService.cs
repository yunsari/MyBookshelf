namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        T GetById(int id);
        List<T> GetListAll();
    }
}
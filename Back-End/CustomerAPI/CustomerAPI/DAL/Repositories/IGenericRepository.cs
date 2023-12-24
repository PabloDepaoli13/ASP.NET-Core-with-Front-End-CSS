using CustomerAPI.DTO;

namespace CustomerAPI.DAL.Repositories
{
    public interface IGenericRepository<T>  where T : class
    {
        Task<T> GetById(int id); 

        Task<IEnumerable<T>> GetAll();

        Task<bool> Create(T entity);

        Task<bool> Update(T entity);    

        Task<bool> DeleteById(int id);
    }
}

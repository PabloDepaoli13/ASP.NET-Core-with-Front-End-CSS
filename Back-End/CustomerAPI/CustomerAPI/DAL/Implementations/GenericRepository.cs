using CustomerAPI.DAL.DataContext;
using CustomerAPI.DAL.Repositories;
using CustomerAPI.DTO;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.DAL.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private AplicationDbContext _context;

        public GenericRepository(AplicationDbContext context)
        {
            _context = context;
        }

       
        public async Task<bool> Create(T entity)
        {
            {
                bool result;
                _context.Add(entity);
                result = await _context.SaveChangesAsync() > 0;
                if (!result)
                {
                    return result;
                }
                return true;
            }
        }

        public Task<bool> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

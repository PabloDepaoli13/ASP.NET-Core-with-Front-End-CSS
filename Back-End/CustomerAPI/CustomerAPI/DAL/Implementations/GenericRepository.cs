using CustomerAPI.DAL.DataContext;
using CustomerAPI.DAL.Repositories;
using CustomerAPI.DTO;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.DAL.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AplicationDbContext _context;

        public GenericRepository(AplicationDbContext context)
        {
            _context = context;
        }

       
        public async Task<bool> CreateCustomer(T entity)
        {
            {
                bool result;
                _context.Set<T>().Add(entity);
                result = await _context.SaveChangesAsync() > 0;
                if (!result)
                {
                    return result;
                }
                return true;
            }
        }

        public async Task<bool> DeleteById(int id)
        {
            bool result = false;
            var entity = await GetById(id);
            if (entity == null)
            {
                return result;
            }
            _context.Remove(entity);
            result = await _context.SaveChangesAsync() > 0;
            return result;

            
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<bool> Update(T entity)
        {
            bool result = false;
            _context.Set<T>().Update(entity);
            result = await _context.SaveChangesAsync() > 0;
            return result;
        }
    }
}

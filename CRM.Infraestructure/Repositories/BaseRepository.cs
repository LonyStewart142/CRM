using CRM.Domain.Interfaces;
using CRM.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infraestructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<T?> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

    }
}

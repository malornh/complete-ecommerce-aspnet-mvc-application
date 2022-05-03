using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _context;

        public EntityBaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
        }

        public IEnumerable<T> GetAllAsync()
        {
            var result = _context.Set<T>().ToList();
            return result;
        }

        public Task<T> GetById(int id)
        {
            var result = _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        //public IEnumerable<Actor> GetAllAsync()
        //{
        //    var result = _context.Actors.ToList();
        //    return result;
        //}

        //public Task<Actor> GetById(int id)
        //{
        //    var result = _context.Actors.FirstOrDefaultAsync(n => n.Id == id);
        //    return result;
        //}

        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
        }
    }
}

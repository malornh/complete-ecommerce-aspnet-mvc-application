using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Base
{
    public interface IEntityBaseRepository<T> where T: class, IEntityBase, new()
    {
        IEnumerable<T> GetAllAsync();
        Task<T> GetById(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }
}

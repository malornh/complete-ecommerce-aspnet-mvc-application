using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IActorsService
    {
        IEnumerable<Actor> GetAllAsync();
        Task<Actor> GetById(int id);
        void Add(Actor actor);
        Task<Actor> UpdateAsync(int id, Actor newActor);
        Task DeleteAsync(int id);
    }
}

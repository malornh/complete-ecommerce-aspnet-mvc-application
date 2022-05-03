using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _context;
        public ActorsService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Actor actor)
        {
            _context.Actors.Add(actor);
            _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = _context.Actors.FirstOrDefaultAsync(n => n.Id == id);
            _context.Actors.Remove(await result);
            await _context.SaveChangesAsync();
        }

        public async Task<Actor> UpdateAsync(int id, Actor newActor)
        {
            _context.Update(newActor);
            await _context.SaveChangesAsync();
            return newActor;
        }

        public IEnumerable<Actor> GetAllAsync()
        {
            var result = _context.Actors.ToList();
            return result;
        }

        public Task<Actor> GetById(int id)
        {
            var result = _context.Actors.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

    }
}

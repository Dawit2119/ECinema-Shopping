using ECinema.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECinema.Data.Services
{
    public class ActorsServie : IActorsService
    {
        private readonly AppDbContext _context;
        public ActorsServie(AppDbContext context)
        {
            _context = context;

        }
        public async Task AddAsync(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);
            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Actor>>  GetAllAsync()
        {
            var result =  await _context.Actors.ToListAsync();
            return result;
        }


        public async  Task<Actor> GetByIdAsync(int id)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(n=>n.Id == id);
                return actor;
            
        }

        public async Task<Actor> UpdateAsync(int id,Actor actor)
        {
            _context.Update(actor);
            await _context.SaveChangesAsync();
            return actor;
        }
    }
}

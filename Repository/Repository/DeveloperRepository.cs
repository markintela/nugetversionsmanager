using Management.Repository;
using Microsoft.EntityFrameworkCore;
using Model.Domain;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly DataContext _dataContext;
        public DeveloperRepository(DataContext context)
        {
            _dataContext = context;
        }
        public async  Task<Developer> CreateAsync(Developer developer)
        {
            await _dataContext.Developer.AddAsync(developer);
            await _dataContext.SaveChangesAsync();
            return developer;
        }
        public async Task DeleteAsync(Guid id)
        {
            var developerToDelete = await _dataContext.Developer.FindAsync(id);
            _dataContext.Developer.Remove(developerToDelete);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Developer>> GetAllAsync()
        {
            return await _dataContext.Developer.ToListAsync();
        }

        public async Task<Developer> GetAsync(Guid id)
        {
            return await _dataContext.Developer.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Developer> UpdateAsync(Developer developer)
        {
            var developerToUpdate = await _dataContext.Developer.FindAsync(developer.Id);

            if (developerToUpdate == null)
            {
                return null;
            }

            _dataContext.Entry(developerToUpdate).CurrentValues.SetValues(developer);

            _dataContext.Developer.Update(developerToUpdate);
            await _dataContext.SaveChangesAsync();
            return developerToUpdate;
        }
    }
}

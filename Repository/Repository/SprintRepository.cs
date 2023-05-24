using Management.Repository;
using Microsoft.EntityFrameworkCore;
using Model;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class SprintRepository : ISprintRepository
    {
        private readonly DataContext _dataContext;
        public SprintRepository(DataContext context)
        {
            _dataContext = context;
        }
        public async Task<Sprint> CreateAsync(Sprint sprint)
        {         
            await _dataContext.Sprint.AddAsync(sprint);
            await _dataContext.SaveChangesAsync();
            return sprint;
        }

        public async Task DeleteAsync(Guid id)
        {
            var sprintToDelete = await _dataContext.Sprint.FindAsync(id);
            _dataContext.Sprint.Remove(sprintToDelete);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Sprint>> GetAllAsync()
        {
            return await _dataContext.Sprint.ToListAsync();
        }

        public  async Task<Sprint> GetAsync(Guid id)
        {
            return await _dataContext.Sprint.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Sprint> UpdateAsync(Sprint sprint)
        {
            var sprintToUpdate = await _dataContext.Sprint.FindAsync(sprint.Id);

            if (sprintToUpdate == null)
            {
                return null;
            }

            _dataContext.Entry(sprintToUpdate).CurrentValues.SetValues(sprint);

            _dataContext.Sprint.Update(sprintToUpdate);
            await _dataContext.SaveChangesAsync();
            return sprintToUpdate;
        }
    }
}

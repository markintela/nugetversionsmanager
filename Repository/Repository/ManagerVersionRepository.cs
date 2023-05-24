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
    public class ManagerVersionRepository : IManagerVersionRepository
    {
        private readonly DataContext _dataContext;
        public ManagerVersionRepository(DataContext context)
        {
            _dataContext = context;
        }
        public async Task<ManagerVersion> CreateAsync(ManagerVersion managerVersion)
        {
            await _dataContext.ManagerVersion.AddAsync(managerVersion);
            await _dataContext.SaveChangesAsync();
            return managerVersion;
        }
        public async Task DeleteAsync(Guid id)
        {
            var managerVersionToDelete = await _dataContext.EpicFeature.FindAsync(id);
            _dataContext.EpicFeature.Remove(managerVersionToDelete);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ManagerVersion>> GetAllAsync()
        {
            return await _dataContext.ManagerVersion.ToListAsync();
        }

        public async Task<ManagerVersion> GetAsync(Guid id)
        {
            return await _dataContext.ManagerVersion.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ManagerVersion> UpdateAsync(ManagerVersion managerVersion)
        {
            var managerVersionToUpdate = await _dataContext.ManagerVersion.FindAsync(managerVersion.Id);

            if (managerVersionToUpdate == null)
            {
                return null;
            }

            _dataContext.Entry(managerVersionToUpdate).CurrentValues.SetValues(managerVersion);

            _dataContext.ManagerVersion.Update(managerVersionToUpdate);
            await _dataContext.SaveChangesAsync();
            return managerVersionToUpdate;
        }
    }
}

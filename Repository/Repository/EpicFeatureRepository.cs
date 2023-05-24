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
    public class EpicFeatureRepository : IEpicFeatureRepository
    {
        private readonly DataContext _dataContext;
        public EpicFeatureRepository(DataContext context)
        {
            _dataContext = context;
        }
        public async Task<EpicFeature> CreateAsync(EpicFeature epicFeature)
        {
            await _dataContext.EpicFeature.AddAsync(epicFeature);
            await _dataContext.SaveChangesAsync();
            return epicFeature;
        }
        public async Task DeleteAsync(Guid id)
        {
            var epicFeatureToDelete = await _dataContext.EpicFeature.FindAsync(id);
            _dataContext.EpicFeature.Remove(epicFeatureToDelete);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<EpicFeature>> GetAllAsync()
        {
            return await _dataContext.EpicFeature.ToListAsync();
        }

        public async Task<EpicFeature> GetAsync(Guid id)
        {
            return await _dataContext.EpicFeature.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<EpicFeature> UpdateAsync(EpicFeature epicFeature)
        {
            var epicFeatureToUpdate = await _dataContext.EpicFeature.FindAsync(epicFeature.Id);

            if (epicFeatureToUpdate == null)
            {
                return null;
            }

            _dataContext.Entry(epicFeatureToUpdate).CurrentValues.SetValues(epicFeature);

            _dataContext.EpicFeature.Update(epicFeatureToUpdate);
            await _dataContext.SaveChangesAsync();
            return epicFeatureToUpdate;
        }
    }
}

using Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Management.Repository
{
    public interface IEpicFeatureRepository
    {
        Task<IEnumerable<EpicFeature>> GetAllAsync();
        Task<EpicFeature> GetAsync(Guid id);
        Task<EpicFeature> CreateAsync(EpicFeature epicFeature);
        Task<EpicFeature> UpdateAsync(EpicFeature epicFeature);
        Task DeleteAsync(Guid id);
    }
}

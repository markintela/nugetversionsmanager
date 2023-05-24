using Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Management.Repository
{
    public interface ISolutionRepository
    {
        Task<IEnumerable<Solution>> GetAllAsync();
        Task<Solution> GetAsync(Guid id);
        Task<Solution> CreateAsync(Solution solution);
        Task<Solution> UpdateAsync(Solution solution);
        Task DeleteAsync(Guid id);
    }
}

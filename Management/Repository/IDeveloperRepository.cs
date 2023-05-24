using Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Management.Repository
{
    public interface IDeveloperRepository
    {
        Task<IEnumerable<Developer>> GetAllAsync();
        Task<Developer> GetAsync(Guid id);
        Task<Developer> CreateAsync(Developer developer);
        Task<Developer> UpdateAsync(Developer developer);
        Task DeleteAsync(Guid id);
    }
}

using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Management.Repository
{
    public interface ISprintRepository
    {
        Task<IEnumerable<Sprint>> GetAllAsync();
        Task<Sprint> GetAsync(Guid id);
        Task<Sprint> CreateAsync(Sprint sprint);
        Task<Sprint> UpdateAsync(Sprint sprint);
        Task DeleteAsync(Guid id);

    }
}

using Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Management.Repository
{
    public interface IManagerVersionRepository
    {
        Task<IEnumerable<ManagerVersion>> GetAllAsync();
        Task<ManagerVersion> GetAsync(Guid id);
        Task<ManagerVersion> CreateAsync(ManagerVersion managerVersion);
        Task<ManagerVersion> UpdateAsync(ManagerVersion managerVersion);
        Task DeleteAsync(Guid id);
    }
}

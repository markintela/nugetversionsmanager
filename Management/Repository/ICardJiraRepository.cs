using Model.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management
{
    public interface ICardJiraRepository
    {
        Task<IEnumerable<CardJira>> GetAllAsync();
        Task<CardJira> GetAsync(Guid id);
        Task<CardJira> CreateAsync(CardJira cardJira);
        Task<CardJira> UpdateAsync(CardJira cardJira);
        Task DeleteAsync(Guid id);
    }
}

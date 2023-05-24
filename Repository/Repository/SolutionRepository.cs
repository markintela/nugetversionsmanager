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
    public class SolutionRepository : ISolutionRepository
    {
        private readonly DataContext _dataContext;
        public SolutionRepository(DataContext context)
        {
            _dataContext = context;
        }
        public async Task<Solution> CreateAsync(Solution solution)
        {
            await _dataContext.Solution.AddAsync(solution);
            await _dataContext.SaveChangesAsync();
            return solution;
        }
        public async Task DeleteAsync(Guid id)
        {
            var solutionoDelete = await _dataContext.Solution.FindAsync(id);
            _dataContext.Solution.Remove(solutionoDelete);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Solution>> GetAllAsync()
        {
            return await _dataContext.Solution.ToListAsync();
        }

        public async Task<Solution> GetAsync(Guid id)
        {
            return await _dataContext.Solution.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Solution> UpdateAsync(Solution solution)
        {
            var solutionoUpdate = await _dataContext.Solution.FindAsync(solution.Id);

            if (solutionoUpdate == null)
            {
                return null;
            }

            _dataContext.Entry(solutionoUpdate).CurrentValues.SetValues(solution);

            _dataContext.Solution.Update(solutionoUpdate);
            await _dataContext.SaveChangesAsync();
            return solutionoUpdate;
        }
    }
}

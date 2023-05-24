using Management;
using Microsoft.EntityFrameworkCore;
using Model.Domain;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class CardJiraRepository : ICardJiraRepository
    {
        private readonly DataContext _dataContext;
        public CardJiraRepository(DataContext context)
        {
            _dataContext = context;
        }
        public async Task<CardJira> CreateAsync(CardJira cardJira)
        {
            await _dataContext.CardJira.AddAsync(cardJira);
            await _dataContext.SaveChangesAsync();
            return cardJira;
        }
        public async Task DeleteAsync(Guid id)
        {
            var cardJiraToDelete = await _dataContext.CardJira.FindAsync(id);
            _dataContext.CardJira.Remove(cardJiraToDelete);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CardJira>> GetAllAsync()
        {
            return await _dataContext.CardJira.ToListAsync();
        }

        public async Task<CardJira> GetAsync(Guid id)
        {
            return await _dataContext.CardJira.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<CardJira> UpdateAsync(CardJira cardJira)
        {
            var cardJiraToUpdate = await _dataContext.CardJira.FindAsync(cardJira.Id);

            if (cardJiraToUpdate == null)
            {
                return null;
            }

            _dataContext.Entry(cardJiraToUpdate).CurrentValues.SetValues(cardJira);

            _dataContext.CardJira.Update(cardJiraToUpdate);
            await _dataContext.SaveChangesAsync();
            return cardJiraToUpdate;
        }
    }
}

using Management;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NugetsVersionsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardJiraController : ControllerBase
    {
        private readonly ICardJiraRepository _cardJiraRepository;

        public CardJiraController(ICardJiraRepository cardJiraRepository)
        {
            _cardJiraRepository = cardJiraRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cardJiras = await _cardJiraRepository.GetAllAsync();
            if (cardJiras == null)
            {
                //throw new KeyNotFoundException("Comment list is empty.");
            }
            return Ok(cardJiras);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var cardJira = await _cardJiraRepository.GetAsync(id);
            if (cardJira == null)
            {
                //throw new KeyNotFoundException("Comment not found.");
            }
            return Ok(cardJira);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CardJira cardJira)
        {
            var cardJiraToCreate = await _cardJiraRepository.CreateAsync(cardJira);
            if (cardJiraToCreate == null)
            {
                //throw new ApplicationException("Comment not created.");
            }
            return CreatedAtAction(nameof(Get), new { id = cardJiraToCreate.Id }, cardJiraToCreate);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put([FromBody] CardJira cardJira)
        {
            var cardJiraToUpdate = await _cardJiraRepository.UpdateAsync(cardJira);

            if (cardJiraToUpdate == null)
            {
                //throw new ApplicationException("Comment not updated.");
            }
            return Ok(cardJiraToUpdate);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _cardJiraRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}

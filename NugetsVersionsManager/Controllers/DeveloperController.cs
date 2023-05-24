using Management.Repository;
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
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperRepository _developerRepository;

        public DeveloperController(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var developers = await _developerRepository.GetAllAsync();
            if (developers == null)
            {
                //throw new KeyNotFoundException("Comment list is empty.");
            }
            return Ok(developers);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var epicFeature = await _developerRepository.GetAsync(id);
            if (epicFeature == null)
            {
                //throw new KeyNotFoundException("Comment not found.");
            }
            return Ok(epicFeature);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Developer developer)
        {
            var developerToCreate = await _developerRepository.CreateAsync(developer);
            if (developerToCreate == null)
            {
                //throw new ApplicationException("Comment not created.");
            }
            return CreatedAtAction(nameof(Get), new { id = developerToCreate.Id }, developerToCreate);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put([FromBody] Developer developer)
        {
            var developerToUpdate = await _developerRepository.UpdateAsync(developer);

            if (developerToUpdate == null)
            {
                //throw new ApplicationException("Comment not updated.");
            }
            return Ok(developerToUpdate);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _developerRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}

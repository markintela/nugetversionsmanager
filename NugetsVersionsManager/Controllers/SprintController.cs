using Management.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NugetsVersionsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SprintController : ControllerBase
    {
        private readonly ISprintRepository _sprintRepository;

        public SprintController(ISprintRepository sprintRepository)
        {
            _sprintRepository = sprintRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sprints = await _sprintRepository.GetAllAsync();
            if (sprints == null)
            {
                //throw new KeyNotFoundException("Comment list is empty.");
            }
            return Ok(sprints);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var sprint = await _sprintRepository.GetAsync(id);
            if (sprint == null)
            {
                //throw new KeyNotFoundException("Comment not found.");
            }
            return Ok(sprint);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Sprint sprint)
        {
            var sprintToCreate = await _sprintRepository.CreateAsync(sprint);
            if (sprintToCreate == null)
            {
                //throw new ApplicationException("Comment not created.");
            }
            return CreatedAtAction(nameof(Get), new { id = sprintToCreate.Id }, sprintToCreate);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put([FromBody] Sprint sprint)
        {
            var sprintToUpdate = await _sprintRepository.UpdateAsync(sprint);

            if (sprintToUpdate == null)
            {
                //throw new ApplicationException("Comment not updated.");
            }
            return Ok(sprintToUpdate);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _sprintRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}

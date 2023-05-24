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
    public class SolutionController : ControllerBase
    {
        private readonly ISolutionRepository _solutionRepository;

        public SolutionController(ISolutionRepository solutionRepository)
        {
            _solutionRepository = solutionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var solutions = await _solutionRepository.GetAllAsync();
            if (solutions == null)
            {
                //throw new KeyNotFoundException("Comment list is empty.");
            }
            return Ok(solutions);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var solution = await _solutionRepository.GetAsync(id);
            if (solution == null)
            {
                //throw new KeyNotFoundException("Comment not found.");
            }
            return Ok(solution);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Solution solution)
        {
            var solutionToCreate = await _solutionRepository.CreateAsync(solution);
            if (solutionToCreate == null)
            {
                //throw new ApplicationException("Comment not created.");
            }
            return CreatedAtAction(nameof(Get), new { id = solutionToCreate.Id }, solutionToCreate);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put([FromBody] Solution solution)
        {
            var solutionToUpdate = await _solutionRepository.UpdateAsync(solution);

            if (solutionToUpdate == null)
            {
                //throw new ApplicationException("Comment not updated.");
            }
            return Ok(solutionToUpdate);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _solutionRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}

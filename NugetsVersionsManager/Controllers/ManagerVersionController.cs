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
    public class ManagerVersionController : ControllerBase
    {
        private readonly IManagerVersionRepository _managerVersionRepository;

        public ManagerVersionController(IManagerVersionRepository managerVersionRepository)
        {
            _managerVersionRepository = managerVersionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var managerVersions = await _managerVersionRepository.GetAllAsync();
            if (managerVersions == null)
            {
                //throw new KeyNotFoundException("Comment list is empty.");
            }
            return Ok(managerVersions);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var managerVersion = await _managerVersionRepository.GetAsync(id);
            if (managerVersion == null)
            {
                //throw new KeyNotFoundException("Comment not found.");
            }
            return Ok(managerVersion);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ManagerVersion managerVersion)
        {
            var managerVersionToCreate = await _managerVersionRepository.CreateAsync(managerVersion);
            if (managerVersionToCreate == null)
            {
                //throw new ApplicationException("Comment not created.");
            }
            return CreatedAtAction(nameof(Get), new { id = managerVersionToCreate.Id }, managerVersionToCreate);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put([FromBody] ManagerVersion managerVersion)
        {
            var managerVersionToUpdate = await _managerVersionRepository.UpdateAsync(managerVersion);

            if (managerVersionToUpdate == null)
            {
                //throw new ApplicationException("Comment not updated.");
            }
            return Ok(managerVersionToUpdate);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _managerVersionRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}

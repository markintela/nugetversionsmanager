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
    public class EpicFeatureController : ControllerBase
    {
        private readonly IEpicFeatureRepository _epicFeatureRepository;

        public EpicFeatureController(IEpicFeatureRepository epicFeatureRepository)
        {
            _epicFeatureRepository = epicFeatureRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var epicFeatures = await _epicFeatureRepository.GetAllAsync();
            if (epicFeatures == null)
            {
                //throw new KeyNotFoundException("Comment list is empty.");
            }
            return Ok(epicFeatures);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var epicFeature = await _epicFeatureRepository.GetAsync(id);
            if (epicFeature == null)
            {
                //throw new KeyNotFoundException("Comment not found.");
            }
            return Ok(epicFeature);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EpicFeature epicFeature)
        {
            var epicFeatureToCreate = await _epicFeatureRepository.CreateAsync(epicFeature);
            if (epicFeatureToCreate == null)
            {
                //throw new ApplicationException("Comment not created.");
            }
            return CreatedAtAction(nameof(Get), new { id = epicFeatureToCreate.Id }, epicFeatureToCreate);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put([FromBody] EpicFeature epicFeature)
        {
            var epicFeatureToUpdate = await _epicFeatureRepository.UpdateAsync(epicFeature);

            if (epicFeatureToUpdate == null)
            {
                //throw new ApplicationException("Comment not updated.");
            }
            return Ok(epicFeatureToUpdate);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _epicFeatureRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}

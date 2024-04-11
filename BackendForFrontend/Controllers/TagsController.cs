using BackendForFrontend.Models.EFModels;
using BackendForFrontend.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BackendForFrontend.Models.DTOs.BlogDto;

namespace BackendForFrontend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagRepository _tagRepository;

        public TagsController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        [HttpPost]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> CreateTag(CreateTagDto CreateTagDto)
        {
            var tag = new Tag
            {
                Name = CreateTagDto.Name
            };

            await _tagRepository.CreateTagAsync(tag);
            return CreatedAtAction(nameof(GetTagById), new { id = tag.Id }, tag);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> UpdateTag(int id, UpdateTagDto UpdateTagDto)
        {
            var tag = await _tagRepository.GetTagByIdAsync(id);

            if (tag == null)
                return NotFound();

            tag.Name = UpdateTagDto.Name;

            await _tagRepository.UpdateTagAsync(tag);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var tag = await _tagRepository.GetTagByIdAsync(id);

            if (tag == null)
                return NotFound();

            await _tagRepository.DeleteTagAsync(tag);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTags()
        {
            var tags = await _tagRepository.GetAllTagsAsync();
            return Ok(tags);
        }

        [HttpGet("{id}", Name = "GetTagById")]
        public async Task<IActionResult> GetTagById(int id)
        {
            var tag = await _tagRepository.GetTagByIdAsync(id);

            if (tag == null)
                return NotFound();

            return Ok(tag);
        }
    }
}

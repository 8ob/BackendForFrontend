using BackendForFrontend.Models;
using BackendForFrontend.Models.EFModels;
using BackendForFrontend.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BackendForFrontend.Models.DTOs.BlogDto;

namespace BackendForFrontend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto CreateCategoryDto)
        {
            var category = new Category1
            {
                Name = CreateCategoryDto.Name,
                Description = CreateCategoryDto.Description
            };

            await _categoryRepository.CreateCategoryAsync(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryDto UpdateCategoryDto)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);

            if (category == null)
                return NotFound();

            category.Name = UpdateCategoryDto.Name;
            category.Description = UpdateCategoryDto.Description;

            await _categoryRepository.UpdateCategoryAsync(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);

            if (category == null)
                return NotFound();

            await _categoryRepository.DeleteCategoryAsync(category);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{id}", Name = "GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);

            if (category == null)
                return NotFound();

            return Ok(category);
        }
    }
}

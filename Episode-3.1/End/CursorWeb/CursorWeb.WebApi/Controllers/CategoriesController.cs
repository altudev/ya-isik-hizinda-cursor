using CursorWeb.WebApi.Entities;
using CursorWeb.WebApi.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CursorWeb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var categories = await _context
                .Categories
                .ToListAsync(cancellationToken);

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var category = await _context
                .Categories
                .FindAsync(id, cancellationToken);

            if (category is null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Category category, CancellationToken cancellationToken)
        {
            await _context.Categories.AddAsync(category, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, Category category, CancellationToken cancellationToken)
        {
            var existingCategory = await _context.Categories.FindAsync(id, cancellationToken);

            if (existingCategory is null)
                return NotFound();

            existingCategory.Name = category.Name;

            await _context.SaveChangesAsync(cancellationToken);

            return Ok(existingCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FindAsync(id, cancellationToken);

            if (category is null)
                return NotFound();

            _context.Categories.Remove(category);

            await _context.SaveChangesAsync(cancellationToken);

            return NoContent();
        }
    }
}
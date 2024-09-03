using CursorWeb.WebApi.Entities;
using CursorWeb.WebApi.Enums;
using CursorWeb.WebApi.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CursorWeb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var products = await _context
                .Products
                .Include(p => p.Category)
                .ToListAsync(cancellationToken);

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var product = await _context
                .Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

            if (product is null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Product product, CancellationToken cancellationToken)
        {
            product.Status = ProductStatusEnum.Active; // Varsayılan olarak Active olarak ayarlayın.

            await _context.Products.AddAsync(product, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, Product product, CancellationToken cancellationToken)
        {
            var existingProduct = await _context.Products.FindAsync(id, cancellationToken);

            if (existingProduct is null)
                return NotFound();

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.CategoryId = product.CategoryId;
            existingProduct.Status = product.Status;

            await _context.SaveChangesAsync(cancellationToken);

            return Ok(existingProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(id, cancellationToken);

            if (product is null)
                return NotFound();

            _context.Products.Remove(product);

            await _context.SaveChangesAsync(cancellationToken);

            return NoContent();
        }
    }
}
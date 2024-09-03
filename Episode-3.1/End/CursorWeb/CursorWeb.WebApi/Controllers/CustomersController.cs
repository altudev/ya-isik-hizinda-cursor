using CursorWeb.WebApi.Entities;
using CursorWeb.WebApi.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CursorWeb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var customers = await _context
            .Customers
            .ToListAsync(cancellationToken);

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var customer = await _context
            .Customers
            .FindAsync(id, cancellationToken);

            if (customer is null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Customer customer, CancellationToken cancellationToken)
        {
            await _context.Customers.AddAsync(customer, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, Customer customer, CancellationToken cancellationToken)
        {
            var existingCustomer = await _context.Customers.FindAsync(id, cancellationToken);

            if (existingCustomer is null)
                return NotFound();

            existingCustomer.Type = customer.Type;
            existingCustomer.Name = customer.Name;
            existingCustomer.Email = customer.Email;
            existingCustomer.Phone = customer.Phone;
            existingCustomer.Address = customer.Address;
            existingCustomer.Country = customer.Country;
            existingCustomer.City = customer.City;
            existingCustomer.State = customer.State;
            existingCustomer.ZipCode = customer.ZipCode;

            await _context.SaveChangesAsync(cancellationToken);

            return Ok(existingCustomer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FindAsync(id, cancellationToken);

            if (customer is null)
                return NotFound();

            _context.Customers.Remove(customer);

            await _context.SaveChangesAsync(cancellationToken);

            return NoContent();
        }
    }
}

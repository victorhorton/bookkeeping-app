using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bookkeeping_app.Data;
using bookkeeping_app.Models;

namespace bookkeeping_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CompaniesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            return await _context.Companies.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var company = await _context.Companies.FindAsync(id);

            if (company == null)
            {
                return NotFound(); // Return 404 Not Found if company is not found
            }

            return Ok(company);; // Return the company if found
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] Company company)
        {
            if (company == null)
            {
                return BadRequest("Company data is null");
            }

            try
            {
                // Perform any necessary processing (e.g., validation, saving to database)
                // For demonstration purposes, assume saving to database
                _context.Companies.Add(company);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, [FromBody] Company updatedCompany)
        {
            if (id != updatedCompany.Id)
            {
                return BadRequest("Company ID mismatch");
            }

            var existingCompany = await _context.Companies.FindAsync(id);

            if (existingCompany == null)
            {
                return NotFound("Company not found");
            }

            try
            {
                // Update company properties
                existingCompany.Name = updatedCompany.Name;
                existingCompany.Code = updatedCompany.Code;

                // Save changes to database
                _context.Update(existingCompany);
                await _context.SaveChangesAsync();

                return NoContent(); // Return 204 No Content if update is successful
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _context.Companies.FindAsync(id);

            if (company == null)
            {
                return NotFound("Company not found");
            }

            try
            {
                // Save changes to database
                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();

                return NoContent(); // Return 204 No Content if update is successful
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }        

    }
}

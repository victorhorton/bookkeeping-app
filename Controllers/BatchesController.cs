using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bookkeeping_app.Data;
using bookkeeping_app.Models;

namespace bookkeeping_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BatchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Batches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Batch>>> GetBatches()
        {
            return await _context.Batches.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Batch>> GetBatch(int id)
        {
            var batch = await _context.Batches.FindAsync(id);

            if (batch == null)
            {
                return NotFound(); // Return 404 Not Found if batch is not found
            }

            return Ok(batch);; // Return the batch if found
        }

        [HttpPost]
        public async Task<IActionResult> CreateBatch([FromBody] Batch batch)
        {
            if (batch == null)
            {
                return BadRequest("Batch data is null");
            }

            try
            {
                // Perform any necessary processing (e.g., validation, saving to database)
                // For demonstration purposes, assume saving to database
                _context.Batches.Add(batch);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBatch(int id, [FromBody] Batch updatedBatch)
        {
            if (id != updatedBatch.Id)
            {
                return BadRequest("Batch ID mismatch");
            }

            var existingBatch = await _context.Batches.FindAsync(id);

            if (existingBatch == null)
            {
                return NotFound("Batch not found");
            }

            try
            {
                // Update batch properties
                existingBatch.Name = updatedBatch.Name; // Update other properties as needed

                // Save changes to database
                _context.Update(existingBatch);
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

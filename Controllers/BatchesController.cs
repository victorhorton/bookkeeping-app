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
    }
}

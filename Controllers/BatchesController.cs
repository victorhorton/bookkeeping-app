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
            var batch = await _context.Batches.Include(b => b.Transactions!).ThenInclude(t => t.Entries).FirstOrDefaultAsync(i => i.Id == id);;

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

            var existingBatch = await _context.Batches.Include(b => b.Transactions!).ThenInclude(t => t.Entries).FirstOrDefaultAsync(b => b.Id == id);

            if (existingBatch == null)
            {
                return NotFound("Batch not found");
            }

            try
            {
                // Update batch properties
                existingBatch.Name = updatedBatch.Name;
                existingBatch.Status = updatedBatch.Status;

                if (updatedBatch.Transactions is not null)
                {
                    // Update existing transaction entries
                    foreach (var transaction in updatedBatch.Transactions)
                    {
                        var existingTransaction = existingBatch.Transactions?.FirstOrDefault(t => t.Id == transaction.Id);
                        if (existingTransaction is not null)
                        {
                            existingTransaction.CompanyId = transaction.CompanyId;
                            existingTransaction.Date = transaction.Date;
                            // Update other properties as needed

                            // Update existing entry entities within the transaction
                            if (transaction.Entries is not null)
                            {
                                foreach (var entry in transaction.Entries)
                                {
                                    var existingEntry = existingTransaction.Entries?.FirstOrDefault(e => e.Id == entry.Id);
                                    if (existingEntry is not null)
                                    {
                                        existingEntry.AccountId = entry.AccountId;
                                        existingEntry.Amount = entry.Amount;
                                        // Update other properties as needed
                                    }
                                    else
                                    {
                                        // Handle new entry entities
                                        existingTransaction.Entries?.Add(entry);
                                    }
                                }
                            }
                        }
                        else
                        {
                            // Handle new transaction entries
                            existingBatch.Transactions?.Add(transaction);
                        }
                    }

                }

                await _context.SaveChangesAsync();

                return NoContent(); // Return 204 No Content if update is successful
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBatch(int id)
        {
            var batch = await _context.Batches.FindAsync(id);

            if (batch == null)
            {
                return NotFound("Batch not found");
            }

            try
            {
                // Save changes to database
                _context.Batches.Remove(batch);
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

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bookkeeping_app.Data;
using bookkeeping_app.Models;

namespace bookkeeping_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AccountsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            return await _context.Accounts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);

            if (account == null)
            {
                return NotFound(); // Return 404 Not Found if account is not found
            }

            return Ok(account);; // Return the account if found
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] Account account)
        {
            if (account == null)
            {
                return BadRequest("Account data is null");
            }

            try
            {
                // Perform any necessary processing (e.g., validation, saving to database)
                // For demonstration purposes, assume saving to database
                _context.Accounts.Add(account);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, [FromBody] Account updatedAccount)
        {
            if (id != updatedAccount.Id)
            {
                return BadRequest("Account ID mismatch");
            }

            var existingAccount = await _context.Accounts.FindAsync(id);

            if (existingAccount == null)
            {
                return NotFound("Account not found");
            }

            try
            {
                // Update account properties
                existingAccount.Name = updatedAccount.Name;
                existingAccount.Number = updatedAccount.Number;

                // Save changes to database
                _context.Update(existingAccount);
                await _context.SaveChangesAsync();

                return NoContent(); // Return 204 No Content if update is successful
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);

            if (account == null)
            {
                return NotFound("Account not found");
            }

            try
            {
                // Save changes to database
                _context.Accounts.Remove(account);
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

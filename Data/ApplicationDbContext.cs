using bookkeeping_app.Models;
using Microsoft.EntityFrameworkCore;

namespace bookkeeping_app.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Account> Accounts{ get; set; }
    public DbSet<Batch> Batches{ get; set; }
    public DbSet<Company> Companies{ get; set; }
    public DbSet<Entry> Entries{ get; set; }
    public DbSet<Transaction> Transactions{ get; set; }
}

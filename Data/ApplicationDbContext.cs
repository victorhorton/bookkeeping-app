using bookkeeping_app.Models;
using Microsoft.EntityFrameworkCore;

namespace bookkeeping_app.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Batch> Batches{ get; set; }
}

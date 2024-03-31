using System.ComponentModel.DataAnnotations;

namespace bookkeeping_app.Models;

public class Transaction
{
  [Key]
  public int Id { get; set; }
  public DateOnly Date { get; set; }
  public required Batch Batch { get; set; }
  public int BatchId { get; set; }
  public required Company Company { get; set; }
  public int CompanyId { get; set; }
  public required ICollection<Entry> Entries { get; set; }
}
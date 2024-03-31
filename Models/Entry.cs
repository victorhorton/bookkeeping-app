using System.ComponentModel.DataAnnotations;

namespace bookkeeping_app.Models;

public class Entry
{
  [Key]
  public int Id { get; set; }
  public decimal Amount { get; set; }
}
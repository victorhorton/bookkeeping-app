using System.ComponentModel.DataAnnotations;

namespace bookkeeping_app.Models;

public class Transaction
{
  [Key]
  public int Id { get; set; }
  public DateOnly Date { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace bookkeeping_app.Models;

public class Entry
{
  [Key]
  public int Id { get; set; }
  public decimal Amount { get; set; }
  public required Transaction Transaction { get; set; }
  public int TransactionId { get; set; }
  public required Account Account { get; set; }
  public int AccountId { get; set; }
}
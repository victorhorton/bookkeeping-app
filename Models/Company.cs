using System.ComponentModel.DataAnnotations;

namespace bookkeeping_app.Models;
public class Company
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public ICollection<Transaction>? Transactions { get; set; }
}

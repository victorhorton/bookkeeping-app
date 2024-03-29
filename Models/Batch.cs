// Models/User.cs
using System.ComponentModel.DataAnnotations;

namespace bookkeeping_app.Models;
public enum BatchStatus
{
    Pending,
    Posted
}

public class Batch
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public required BatchStatus Status { get; set; }

}

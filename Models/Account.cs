// Models/User.cs
using System.ComponentModel.DataAnnotations;

namespace bookkeeping_app.Models;
public class Account
{
    [Key]
    public int Id { get; set; }
    public string? Number { get; set; }
    public string? Name { get; set; }
    public ICollection<Entry>? Entries { get; set; }
}

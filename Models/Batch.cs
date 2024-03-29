// Models/User.cs
public enum BatchStatus
{
    Pending,
    Posted
}

public class Batch
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public required BatchStatus Status { get; set; }

}

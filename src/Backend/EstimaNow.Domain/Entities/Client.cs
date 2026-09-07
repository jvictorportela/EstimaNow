namespace EstimaNow.Domain.Entities;

public class Client
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
    public ICollection<OrderOfService> Orders { get; set; } = new List<OrderOfService>();
}
namespace EstimaNow.Web.Models;

public class ClientModel
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
}
using System.ComponentModel.DataAnnotations;

namespace EstimaNow.Domain.Entities;

public class CategoryOfService
{
    public long Id { get; set; }

    [Required(ErrorMessage ="The name of the category of service is required.")]
    [StringLength(80)]
    [Display(Name = "Categoria")]
    public string Name { get; set; } = string.Empty;

    [StringLength(200)]
    [Display(Name = "Descrição")]
    public string? Description { get; set; }

    public ICollection<OrderOfService> Orders { get; set; } = new List<OrderOfService>();
}
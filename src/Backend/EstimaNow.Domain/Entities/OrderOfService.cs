using EstimaNow.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstimaNow.Domain.Entities;

public class OrderOfService
{
    public long Id { get; set; }

    [StringLength(200)]
    [Display(Name = "Descrição")]
    public string Description { get; set; } = string.Empty;

    [StringLength(200)]
    [Display(Name = "Observações")]
    public string? Observations { get; set; }

    [Required(ErrorMessage = "The value of the order of service is required.")]
    [Display(Name = "Valor")]
    [Range(0, 999999999.99, ErrorMessage = "The value must be between 0 and 999999999.99.")]
    [Column(TypeName = "decimal(10, 2)")]
    public decimal Value { get; set; }

    [Display(Name = "Data de Criação")]
    [DataType(DataType.Date)]
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    [Display(Name = "Data de Conclusão")]
    [DataType(DataType.Date)]
    public DateTime? FinishedIn { get; set; }

    public StatusOrder Status { get; set; } = StatusOrder.Pending;

    public Domain.Entities.CategoryOfService? CategoryOfService { get; set; }
    public long? CategoryOfServiceId { get; set; }


    public Domain.Entities.Client? Client { get; set; }
    public long ClientId { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace Manufacture.Core.Entities;

public class Product
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public decimal? Amount { get; set; }
}

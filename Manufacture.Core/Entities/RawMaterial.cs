namespace Manufacture.Core.Entities;

public class RawMaterial : EntityBase
{
    public string? Name { get; set; }
    public decimal? Quantity { get; set; }
    public decimal? Price { get; set; } // цена за кило
    
    public virtual ICollection<ProductToOrder> Product { get; set; } = new HashSet<ProductToOrder>();
}
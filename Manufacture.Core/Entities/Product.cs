
namespace Manufacture.Core.Entities;

public class Product : EntityBase // Продукт существующий
{ 
    
    public decimal? Amount { get; set; }
    public decimal? Price { get; set; }
    
    public int? ProductToOrderId { get; set; } // Связь с ProductToOrder(FK)
    public virtual ProductToOrder ProductToOrder { get; set; }
}
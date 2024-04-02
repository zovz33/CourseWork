    namespace Manufacture.Core.Entities;

    public class ProductToOrder : EntityBase // Продукт,который можно заказать
    { 
        public string? Name { get; set; } 
        public string? Description { get; set; }
        public string? ImageUrl { get; set; } 

        public virtual Product Product { get; set; } // Связь с Product
        // Связь с заказом, к которому относится данный продукт
        public virtual Order Order { get; set; }

        public virtual ICollection<RawMaterial> Material { get; set; } = new HashSet<RawMaterial>();
    }
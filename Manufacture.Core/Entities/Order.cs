namespace Manufacture.Core.Entities;

public class Order : EntityBase
{ 
    public decimal? Quantity { get; set; }  // Количество заказываемых единиц
    public OrderStatus? Status { get; set; }  
    public DateTime OrderDate { get; set; } // Дата заказа
    public DateTime? CompletionDate { get; set; } // Дата завершения производства
     
    public int ProductToOrderId { get; set; } // Связь с ProductToOrder(FK)
    public virtual ProductToOrder ProductToOrder { get; set; }
 
}

public enum OrderStatus
{
    Created = 1,    // Создан
    InProgress = 2, // В процессе
    Pending = 3,    // В ожидании
    Rejected = 4,    // Отказано
}
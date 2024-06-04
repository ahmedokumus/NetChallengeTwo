using Entities.Abstract;

namespace Entities.Concrete;

public class Order : IEntity
{
    public int OrderId { get; set; }
    public int CarrierId { get; set; }
    public int OrderDesi { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal OrderCarrierCost { get; set; }

    // Navigation Properties
    public Carrier Carrier { get; set; }
}
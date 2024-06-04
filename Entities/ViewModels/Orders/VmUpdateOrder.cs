namespace Entities.ViewModels.Orders;

public class VmUpdateOrder
{
    public int OrderId { get; set; }
    public int CarrierId { get; set; }
    public int OrderDesi { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal OrderCarrierCost { get; set; }
}
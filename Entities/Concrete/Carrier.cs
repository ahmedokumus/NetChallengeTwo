using Entities.Abstract;

namespace Entities.Concrete;

public class Carrier : IEntity
{
    public int CarrierId { get; set; }
    public string CarrierName { get; set; }
    public bool CarrierIsActive { get; set; }
    public int CarrierPlusDesiCost { get; set; }
    public int CarrierConfigurationId { get; set; }

    // Navigation Properties
    public CarrierConfiguration CarrierConfiguration { get; set; }
    public ICollection<Order> Orders { get; set; }
}
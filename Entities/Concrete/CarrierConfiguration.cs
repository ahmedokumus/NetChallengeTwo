using Entities.Abstract;

namespace Entities.Concrete;

public class CarrierConfiguration : IEntity
{
    public int CarrierConfigurationId { get; set; }
    public int CarrierId { get; set; }
    public int CarrierMaxDesi { get; set; }
    public int CarrierMinDesi { get; set; }
    public decimal CarrierCost { get; set; }

    // Navigation Properties
    public IEnumerable<Carrier>? Carrier { get; set; }
}
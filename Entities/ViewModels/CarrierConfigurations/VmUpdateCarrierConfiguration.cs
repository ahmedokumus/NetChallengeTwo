namespace Entities.ViewModels.CarrierConfigurations;

public class VmUpdateCarrierConfiguration
{
    public int CarrierConfigurationId { get; set; }
    public int CarrierId { get; set; }
    public int CarrierMaxDesi { get; set; }
    public int CarrierMinDesi { get; set; }
    public decimal CarrierCost { get; set; }
}
namespace Entities.ViewModels.Carriers;

public class VmUpdateCarrier
{
    public int CarrierId { get; set; }
    public string CarrierName { get; set; }
    public bool CarrierIsActive { get; set; }
    public int CarrierPlusDesiCost { get; set; }
    public int CarrierConfigurationId { get; set; }
}
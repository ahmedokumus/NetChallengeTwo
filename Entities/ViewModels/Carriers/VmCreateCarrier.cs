using Entities.Abstract;

namespace Entities.ViewModels.Carriers;

public class VmCreateCarrier : IEntity
{
    public string CarrierName { get; set; }
    public bool CarrierIsActive { get; set; }
    public int CarrierPlusDesiCost { get; set; }
    public int CarrierConfigurationId { get; set; }
}
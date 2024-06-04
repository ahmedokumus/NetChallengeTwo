using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfCarrierConfigurationDal : EfEntityRepositoryBase<CarrierConfiguration, EfContext>, ICarrierConfigurationDal
{
    
}
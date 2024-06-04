using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfCarrierDal : EfEntityRepositoryBase<Carrier, EfContext>, ICarrierDal
{

}
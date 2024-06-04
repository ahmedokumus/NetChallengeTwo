using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfOrderDal : EfEntityRepositoryBase<Order, EfContext>, IOrderDal
{
    
}
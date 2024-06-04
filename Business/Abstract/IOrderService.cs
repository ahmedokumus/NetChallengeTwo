using Business.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface IOrderService : IServiceBase<Order>
{
    IDataResult<List<Order>> GetAll();
    IDataResult<Order> GetById(int orderId);
}
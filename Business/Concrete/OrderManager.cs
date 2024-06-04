
using Business.Abstract;
using Business.Utilities.Constants;
using Business.Utilities.Results.Abstract;
using Business.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete;

public class OrderManager : IOrderService
{
    private readonly IOrderDal _orderDal;
    private readonly ICarrierConfigurationDal _carrierConfigurationDal;
    private readonly ICarrierDal _carrierDal;

    public OrderManager(IOrderDal orderDal, ICarrierConfigurationDal carrierConfigurationDal, ICarrierDal carrierDal)
    {
        _orderDal = orderDal;
        _carrierConfigurationDal = carrierConfigurationDal;
        _carrierDal = carrierDal;
    }


    public IResult Add(Order entity)
    {
        var carrier = BestCarrier(entity.OrderDesi);
        if (carrier.Item2)
        {
            entity.OrderCarrierCost = carrier.Item1.CarrierCost;
        }
        else
        {
            var carrierCost = carrier.Item1.CarrierCost;
            var maxDesi = carrier.Item1.CarrierMaxDesi;

            entity.OrderCarrierCost = carrierCost + (4 * (entity.OrderDesi - maxDesi));
        }

        entity.CarrierId = _carrierDal.Get(x => x.CarrierConfigurationId == carrier.Item1.CarrierConfigurationId)!
            .CarrierId;
        entity.OrderDate = DateTime.Now;
        _orderDal.Add(entity);
        return new SuccessResult(Messages.OrderAdded);
    }

    public IResult Update(Order entity)
    {
        throw new NotImplementedException();
    }

    public IResult Delete(Order entity)
    {
        _orderDal.Delete(entity);
        return new SuccessResult(Messages.OrderDeleted(entity.OrderId));
    }

    public IDataResult<List<Order>> GetAll()
    {
        var count = _orderDal.GetAll().Count;
        _orderDal.GetAll();
        return new SuccessDataResult<List<Order>>(Messages.OrdersListed(count));
    }

    public IDataResult<Order> GetById(int orderId)
    {
        _orderDal.Get(x => x.OrderId == orderId);
        return new SuccessDataResult<Order>(Messages.OrderListed(orderId));
    }

    public (CarrierConfiguration, bool) BestCarrier(int orderDesi)
    {
        // Sipariş desisinin MinDesi-MaxDesi aralığına girip girmediğini kontrol et
        var bestCarrier = _carrierConfigurationDal.GetAll().AsQueryable()
            .Where(cc => cc.CarrierMinDesi <= orderDesi && cc.CarrierMaxDesi >= orderDesi)
            .OrderBy(cc => cc.CarrierCost)
            .Include(cc => cc.Carrier)
            .FirstOrDefault();

        // Eğer desi değeri herhangi bir aralığa girmiyorsa, en yakın olanı bul
        if (bestCarrier == null)
        {
            bestCarrier = _carrierConfigurationDal.GetAll().AsQueryable()
                .Include(cc => cc.Carrier)
                .OrderBy(cc => Math.Min(Math.Abs(cc.CarrierMinDesi - orderDesi), Math.Abs(cc.CarrierMaxDesi - orderDesi)))
                .FirstOrDefault();
            return (bestCarrier!, false);
        }

        bestCarrier = _carrierConfigurationDal.GetAll().Where(x => x.CarrierMinDesi <= orderDesi && x.CarrierMaxDesi >= orderDesi).MinBy(x => x.CarrierCost);
        return (bestCarrier!, true);

    }
}
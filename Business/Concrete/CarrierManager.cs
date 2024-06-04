using Business.Abstract;
using Business.Utilities.Results.Concrete;
using Business.Utilities.Constants;
using Business.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.ViewModels.Carriers;

namespace Business.Concrete;

public class CarrierManager : ICarrierService
{
    private readonly ICarrierDal _carrierDal;

    public CarrierManager(ICarrierDal carrierDal)
    {
        _carrierDal = carrierDal;
    }


    public IResult Add(Carrier carrier)
    {
        _carrierDal.Add(carrier);
        return new SuccessResult(Messages.CarrierAdded);
    }

    public IResult Update(Carrier entity)
    {
        _carrierDal.Update(entity);
        return new SuccessResult(Messages.CarrierUpdated(entity.CarrierId));
    }

    public IResult Delete(Carrier entity)
    {
        _carrierDal.Delete(entity);
        return new SuccessResult(Messages.CarrierDeleted(entity.CarrierId));
    }

    public IDataResult<List<Carrier>> GetAll()
    {
        var count = _carrierDal.GetAll().ToList().Count;
        return new SuccessDataResult<List<Carrier>>(_carrierDal.GetAll(), Messages.CarriersListed(count));
    }

    public IDataResult<Carrier> GetById(int carrierId)
    {
        return new SuccessDataResult<Carrier>(_carrierDal.Get(x => x.CarrierId == carrierId)!,
            Messages.CarrierListed(carrierId));
    }
}
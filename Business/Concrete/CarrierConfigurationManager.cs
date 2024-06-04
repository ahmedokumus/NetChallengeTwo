using Business.Abstract;
using Business.Utilities.Constants;
using Business.Utilities.Results.Abstract;
using Business.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete;

public class CarrierConfigurationManager : ICarrierConfigurationService
{
    private readonly ICarrierConfigurationDal _carrierConfigurationDal;

    public CarrierConfigurationManager(ICarrierConfigurationDal carrierConfigurationDal)
    {
        _carrierConfigurationDal = carrierConfigurationDal;
    }


    public IResult Add(CarrierConfiguration entity)
    {
        _carrierConfigurationDal.Add(entity);
        return new SuccessResult(Messages.CarrierConfAdded);
    }

    public IResult Update(CarrierConfiguration entity)
    {
        _carrierConfigurationDal.Update(entity);
        return new SuccessResult(Messages.CarrierConfUpdated(entity.CarrierConfigurationId));
    }

    public IResult Delete(CarrierConfiguration entity)
    {
        _carrierConfigurationDal.Delete(entity);
        return new SuccessResult(Messages.CarrierConfDeleted(entity.CarrierConfigurationId));
    }

    public IDataResult<List<CarrierConfiguration>> GetAll()
    {
        var count = _carrierConfigurationDal.GetAll().ToList().Count;
        return new SuccessDataResult<List<CarrierConfiguration>>(_carrierConfigurationDal.GetAll(), Messages.CarrierConfsListed(count));
    }

    public IDataResult<CarrierConfiguration> GetById(int carrierConfigurationId)
    {
        return new SuccessDataResult<CarrierConfiguration>(_carrierConfigurationDal.Get(x => x.CarrierConfigurationId == carrierConfigurationId)!,
            Messages.CarrierConfListed(carrierConfigurationId));
    }
}
using Business.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface ICarrierConfigurationService : IServiceBase<CarrierConfiguration>
{
    IDataResult<List<CarrierConfiguration>> GetAll();
    IDataResult<CarrierConfiguration> GetById(int carrierConfigurationId);
}
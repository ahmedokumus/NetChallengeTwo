using Business.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface ICarrierService : IServiceBase<Carrier>
{
    IDataResult<List<Carrier>> GetAll();
    IDataResult<Carrier> GetById(int carrierId);
}
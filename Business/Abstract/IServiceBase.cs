using Business.Utilities.Results.Abstract;

namespace Business.Abstract;

public interface IServiceBase<in T>
{
    IResult Add(T entity);
    IResult Update(T entity);
    IResult Delete(T entity);
}
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Utilities.DependencyResolvers;

public static class ServiceRegistration
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICarrierDal, EfCarrierDal>();
        services.AddScoped<ICarrierService, CarrierManager>();

        services.AddScoped<ICarrierConfigurationDal, EfCarrierConfigurationDal>();
        services.AddScoped<ICarrierConfigurationService, CarrierConfigurationManager>();

        services.AddScoped<IOrderDal, EfOrderDal>();
        services.AddScoped<IOrderService, OrderManager>();
    }
}
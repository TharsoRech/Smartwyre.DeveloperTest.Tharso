using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smartwyre.DeveloperTest.Configuration;
using Smartwyre.DeveloperTest.Context;
using Smartwyre.DeveloperTest.Context.Interface.NerdStore.Enterprise.Core.Infrastructure.Context.Interface;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMyServices(this IServiceCollection services)
    {
        services.AddTransient<IRebateService, RebateService>();
        services.AddTransient<IProductDataStore, ProductDataStore>();
        services.AddTransient<IRebateDataStore, RebateDataStore>();
        services.AddTransient<IDapperContext, DapperContext>();
        return services;
    }
}
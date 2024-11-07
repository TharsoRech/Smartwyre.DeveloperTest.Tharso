using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smartwyre.DeveloperTest.Configuration;
using Smartwyre.DeveloperTest.Context;
using Smartwyre.DeveloperTest.Services;
using System;
using System.IO;
using System.Text.Json.Serialization;

namespace Smartwyre.DeveloperTest.Runner;

class Program
{
    static void Main(string[] args)
    {
        // Build configuration from App.config
        var configuration = new ConfigurationBuilder()
         .SetBasePath(Directory.GetCurrentDirectory())
         .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
         .Build();


        // Setup Dependency Injection
        var serviceProvider = new ServiceCollection()
            .AddMyServices()
            .BuildServiceProvider();

        AppSettings.Instance.Load(configuration);

        var rebateService = serviceProvider.GetService<IRebateService>();
        var result = rebateService.Calculate(new Types.CalculateRebateRequest
        {
            RebateIdentifier = "803dca12-59c6-4636-bca0-93dc30c7752a",
            ProductIdentifier = "b948bc91-0dac-487a-8bb5-0a68eeabf127",
            Volume = 1,
        });

        Console.WriteLine($"Sucess:{result.Result.Success}");  
    }

    //for this application if the scope was create a webApi I would create
    // the same infrasctructure of then than another project that I have , didn't do that
    // because I don't have a lot of time , this is the project that I would look
    // to do the same estructure https://github.com/TharsoRech/NerdStore.Enterprise.Core.WebApi
}

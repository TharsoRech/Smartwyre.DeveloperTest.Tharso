using Smartwyre.DeveloperTest.Context.Interface.NerdStore.Enterprise.Core.Infrastructure.Context.Interface;
using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Types;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Data;

public class ProductDataStore: IProductDataStore
{
    IDapperContext _dapperContext;


    public static string getProductCommand = @"SELECT * from Products
                                                where Identifier = @productIdentifier";

    public ProductDataStore(IDapperContext dapperContext)
    {
       _dapperContext = dapperContext;
    }
    public async Task<Product> GetProduct(string productIdentifier)
    {
        return await _dapperContext.QueryFirstOrDefaultAsync<Product>(getProductCommand, new { productIdentifier });
    }
}

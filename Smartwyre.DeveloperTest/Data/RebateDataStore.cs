using Smartwyre.DeveloperTest.Context.Interface.NerdStore.Enterprise.Core.Infrastructure.Context.Interface;
using Smartwyre.DeveloperTest.Types;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Data;

public class RebateDataStore:IRebateDataStore
{
    IDapperContext _dapperContext;

    public static string getRebateCommand = @"SELECT * from [Rebates]
                                                where Identifier = @rebateIdentifier";

    public static string storeCalculationResultCommand = @"UPDATE Rebates
SET Incentive = @incentive,
    Amount = @amount,
    Percentage = @percentage
WHERE Identifier = @identifier;";
    public RebateDataStore(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }
    public async Task<Rebate> GetRebate(string rebateIdentifier)
    {
        return await _dapperContext.QueryFirstOrDefaultAsync<Rebate>(getRebateCommand, new { rebateIdentifier });
    }

    public async Task StoreCalculationResult(Rebate account, decimal rebateAmount)
    {
        await _dapperContext.ExecuteAsync(storeCalculationResultCommand, 
            new { identifier = account.Identifier,
                incentive = (int)account.Incentive,
                amount = rebateAmount,
                percentage = account.Percentage,});
    }
}

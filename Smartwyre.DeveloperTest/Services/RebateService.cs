using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Types;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
{
    private readonly IRebateDataStore _rebateDataStore;
    private readonly IProductDataStore _productDataStore;

    public RebateService(IRebateDataStore rebateDataStore, IProductDataStore productDataStore)
    {
        _rebateDataStore = rebateDataStore;
        _productDataStore = productDataStore;
    }

    public async Task<CalculateRebateResult> Calculate(CalculateRebateRequest request)
    {
        try
        {
            var rebate = await _rebateDataStore.GetRebate(request.RebateIdentifier);
            var product = await _productDataStore.GetProduct(request.ProductIdentifier);

            if (rebate is null || product is null)
                return new CalculateRebateResult { Success = false };

            var rebateAmount = CalculateRebate(rebate, product, request, out bool isValid);

            if (isValid)
                await _rebateDataStore.StoreCalculationResult(rebate, rebateAmount);

            return new CalculateRebateResult { Success = isValid };
        }
        catch (System.Exception ex)
        {
            //some log here
            return new CalculateRebateResult { Success = false };
        }

    }

    private decimal CalculateRebate(Rebate rebate, Product product, CalculateRebateRequest request, out bool isValid)
    {
        switch (rebate.Incentive)
        {
            case IncentiveType.FixedCashAmount:
                isValid = product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount);
                return isValid ? rebate.Amount : 0m;

            case IncentiveType.FixedRateRebate:
                isValid = product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedRateRebate);
                return isValid ? CalculateFixedRateRebate(rebate, product, request) : 0m;

            case IncentiveType.AmountPerUom:
                isValid = product.SupportedIncentives.HasFlag(SupportedIncentiveType.AmountPerUom);
                return isValid ? CalculateAmountPerUom(rebate, product, request) : 0m;

            default:
                isValid = false;
                return 0m;
        }

    }

    private decimal CalculateFixedRateRebate(Rebate rebate, Product product, CalculateRebateRequest request)
    {
        return (rebate.Percentage == 0 || product.Price == 0 || request.Volume == 0) ? 0m : product.Price * rebate.Percentage * request.Volume;
    }

    private decimal CalculateAmountPerUom(Rebate rebate, Product product, CalculateRebateRequest request)
    {
        return (rebate.Amount == 0 || request.Volume == 0) ? 0m : rebate.Amount * request.Volume;
    }
}
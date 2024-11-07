using Smartwyre.DeveloperTest.Types;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Data
{
    public interface IRebateDataStore
    {
        Task<Rebate> GetRebate(string rebateIdentifier);
        Task StoreCalculationResult(Rebate account, decimal rebateAmount);
    }
}

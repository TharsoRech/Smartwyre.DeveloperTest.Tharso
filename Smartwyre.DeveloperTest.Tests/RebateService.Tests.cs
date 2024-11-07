using Dapper;
using Moq;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests
{
    public class RebateServiceTests
    {
        [Fact]
        public async Task Calculate_WithValidRequest_ReturnsResultAsync()
        {
            // Arrange

            var productIdentifier = "product1";
            var rebateIdentifier = "rebate1";

            var mockedProduct = new Product
            {
                Identifier = productIdentifier,
                Price = 100,
                Uom = string.Empty,
                SupportedIncentives = SupportedIncentiveType.FixedCashAmount
            };

            var mockedRebates = new Rebate
            {
                Identifier = rebateIdentifier,
                Incentive = IncentiveType.FixedCashAmount,
                Amount = 10,
                Percentage = 5
            };

            var _rebateDataStore = new Mock<IRebateDataStore>();
            var _productDataStore = new Mock<IProductDataStore>();

            _productDataStore.Setup(d => d.GetProduct(It.IsAny<string>()))
                             .ReturnsAsync(mockedProduct);

            _rebateDataStore.Setup(d => d.GetRebate(It.IsAny<string>()))
                .ReturnsAsync(mockedRebates);

            var rebateService = new RebateService(_rebateDataStore.Object,_productDataStore.Object);

            var request = new CalculateRebateRequest
            {
                RebateIdentifier = rebateIdentifier,
                ProductIdentifier = productIdentifier
            };

            // Act
            var result = await rebateService.Calculate(request);

            // Assert
            Assert.True(result.Success);
        }

        [Fact]
        public async Task Calculate_WithInvalidRequest_Different_Support_Type()
        {
            // Arrange
            var productIdentifier = "product1";
            var rebateIdentifier = "rebate1";

            var mockedProduct = new Product
            {
                Identifier = productIdentifier,
                Price = 100,
                Uom = string.Empty,
                SupportedIncentives = SupportedIncentiveType.FixedCashAmount
            };

            var mockedRebates = new Rebate
            {
                Identifier = rebateIdentifier,
                Incentive = IncentiveType.AmountPerUom,
                Amount = 10,
                Percentage = 5
            };

            var _rebateDataStore = new Mock<IRebateDataStore>();
            var _productDataStore = new Mock<IProductDataStore>();

            _productDataStore.Setup(d => d.GetProduct(It.IsAny<string>()))
                             .ReturnsAsync(mockedProduct);

            _rebateDataStore.Setup(d => d.GetRebate(It.IsAny<string>()))
                .ReturnsAsync(mockedRebates);

            var request = new CalculateRebateRequest
            {
                RebateIdentifier = rebateIdentifier,
                ProductIdentifier = productIdentifier
            };

            // Act
            var rebateService = new RebateService(_rebateDataStore.Object, _productDataStore.Object);
            var result = await rebateService.Calculate(request);

            // Assert
            Assert.False(result.Success);
        }

        //I would more test here no but I don't have a lot of time to continue the testing
        //I would do more test about the calculation and sending some invalids informations
        //Also I would create a new class of test to test the DataStores 
    }
}
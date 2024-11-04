//using Moq;
using System;
using Xunit;

namespace BatteryTemperature.Tests
{
    public class TypewiseAlertTests
    {
        private readonly TypewiseAlert _typewiseAlert;

        public TypewiseAlertTests()
        {
            _typewiseAlert = new TypewiseAlert();
        }

        [Theory]
        [InlineData(CoolingType.PassiveCooling, 0, BreachType.TooLow)]
        [InlineData(CoolingType.PassiveCooling, 34, BreachType.Normal)]
        [InlineData(CoolingType.PassiveCooling, 35, BreachType.TooHigh)]
        [InlineData(CoolingType.PassiveCooling, 36, BreachType.TooHigh)]
        [InlineData(CoolingType.MediumActiveCooling, 0, BreachType.TooLow)]
        [InlineData(CoolingType.MediumActiveCooling, 39, BreachType.Normal)]
        [InlineData(CoolingType.MediumActiveCooling, 40, BreachType.TooHigh)]
        [InlineData(CoolingType.MediumActiveCooling, 41, BreachType.TooHigh)]
        [InlineData(CoolingType.HighActiveCooling, 0, BreachType.TooLow)]
        [InlineData(CoolingType.HighActiveCooling, 44, BreachType.Normal)]
        [InlineData(CoolingType.HighActiveCooling, 45, BreachType.TooHigh)]
        [InlineData(CoolingType.HighActiveCooling, 46, BreachType.TooHigh)]
        public void ClassifyTemperatureBreach_ValidInputs_ReturnsExpectedBreachType(CoolingType coolingType, double temperature, BreachType expected)
        {
            var result = _typewiseAlert.ClassifyTemperatureBreach(coolingType, temperature);
            Assert.Equal(expected, result);
        }
    }
}

using System;
using Xunit;
using TaxCalculatorUI;

namespace UnitTests
{
    public class UtilitiesTests
    {
        [Fact]
        public void RoundUpTests()
        {
            Assert.Equal(5.93, Utilities.RoundUp(5.92345, 2)); 
        }
        
        [Fact]
        public void RemoveDollarSymbolTests()
        {
            Assert.Equal("50", Utilities.RemoveDollarSymbol("$50"));
            Assert.Equal("50", Utilities.RemoveDollarSymbol("50"));
            Assert.Equal("50.55", Utilities.RemoveDollarSymbol("50.55"));
            Assert.Equal("", Utilities.RemoveDollarSymbol(""));
        }
    }

    public class CalculationsTests
    {
        [Fact]
        public void CalculateSuperannuationTests()
        {
            Assert.Equal(5639.27, Calculations.CalculateSuperannuation(65000));
        }
        
        [Fact]
        public void CalculateTaxableIncomeTests()
        {

        }
        
        [Fact]
        public void CalculateMedicareLevyTests()
        {

        }
        
        [Fact]
        public void CalculateBudgetRepairLevyTests()
        {

        }
        
        [Fact]
        public void CalculateIncomeTaxTests()
        {

        }
    }
}
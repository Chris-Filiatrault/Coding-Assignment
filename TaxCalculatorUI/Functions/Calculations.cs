using System;

namespace TaxCalculatorUI
{
    /// <summary>
    /// This class handles the calculations for superannuation, taxable income, medicare levy, budget repair levy and income tax
    /// </summary>
    public class Calculations
    {
        
        public static double CalculateSuperannuation(double totalPackage)
        {
            return Utilities.RoundUp((totalPackage - totalPackage / 1.095), 2);
        }
        
        public static double CalculateTaxableIncome(double totalPackage, double superannuation)
        {
            return Math.Round((totalPackage - superannuation), 2);
        }
        
        public static double CalculateMedicareLevy(double deductionTaxableIncome, int tier1 = 21335, int tier2 = 26668)
        {
            if (deductionTaxableIncome <= tier1)
            {
                return 0;
            }
            else if (deductionTaxableIncome >= (tier1 + 1) & deductionTaxableIncome <= tier2)
            {
                return Math.Ceiling((deductionTaxableIncome - tier1) * 0.1);
            }
            else
            {
                return Math.Ceiling(deductionTaxableIncome * 0.02);
            }
        }
        
        public static double CalculateBudgetRepairLevy(double deductionTaxableIncome, int tier1 = 180000)
        {
            if (deductionTaxableIncome <= tier1)
            {
                return 0;
            }
            else
            {
                return Math.Ceiling((deductionTaxableIncome - tier1) * 0.02);
            }
        }
        
        public static double CalculateIncomeTax(
            double deductionTaxableIncome, 
            int tier1 = 18200, 
            int tier2 = 37000, 
            int tier3 = 87000,
            int tier4 = 180000
        )
        {
            if (deductionTaxableIncome <= tier1)
            {
                return 0;
            }
            else if (deductionTaxableIncome >= (tier1 + 1) & deductionTaxableIncome <= tier2)
            {
                return Math.Ceiling((deductionTaxableIncome - tier1) * 0.19);
            }
            else if (deductionTaxableIncome >= (tier2 + 1) & deductionTaxableIncome <= tier3)
            {
                return 3572 + Math.Ceiling((deductionTaxableIncome - tier2) * 0.325);
            }
            else if (deductionTaxableIncome >= tier3 & deductionTaxableIncome <= tier4)
            {
                return 19822 + Math.Ceiling((deductionTaxableIncome - tier3) * 0.37);
            }
            else
            {
                return 54000 + (deductionTaxableIncome - tier4) * 0.47;
            }
        }
    }
}
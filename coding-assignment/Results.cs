using System;
using System.Collections.Generic;


namespace coding_assignment
{
    /// <summary>
    /// This class stores the results of the calculations, to be passed into the appropriate interface.
    /// </summary>
    public class Results
    {
        static public double totalPackage = UserInput.GetTotalPackage();
        static public int payFrequency = UserInput.GetPayFrequency();
        
        static public double superannuation = Calculations.CalculateSuperannuation(totalPackage);
        static public double taxableIncome = Calculations.CalculateTaxableIncome(totalPackage, superannuation);
        static public double deductionTaxableIncome = Math.Floor(taxableIncome);
        static public double medicareLevy = Calculations.CalculateMedicareLevy(deductionTaxableIncome);
        static public double budgetRepairLevy = Calculations.CalculateBudgetRepairLevy(deductionTaxableIncome);
        static public double incomeTax = Calculations.CalculateIncomeTax(deductionTaxableIncome);
        static public double deductions = medicareLevy + budgetRepairLevy + incomeTax;
        static public double netIncome = totalPackage - superannuation - deductions;
        static public double payPacket = Utilities.RoundUp(netIncome / payFrequency, 2);
    }
}
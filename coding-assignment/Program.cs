using System;
using System.Linq;
using System.Globalization;
using System.Xml;

namespace coding_assignment
{
    class Program
    {

        // Get total package
        public static double GetTotalPackage()
        {
            Console.WriteLine("Enter your salary package amount.");
            try
            {
                // attempt to get user input (as a double)
                double totalPackage = Convert.ToDouble(Console.ReadLine());

                // return if non-negative
                if (totalPackage >= 0)
                {
                    return totalPackage;
                }
                // otherwise, prompt again
                else
                {
                    Console.WriteLine("Cannot be a negative number.");
                    return GetTotalPackage();
                }
            }
            // error handling
            catch (Exception error)
            {
                // user-friendly error message
                Console.WriteLine("Please enter a number. Letters and other symbols are invalid.");
                
                // error message for IT department if needed
                Console.WriteLine("If the problem persists, provide the following error message to your IT department:\n\n");
                Console.WriteLine(error);
                
                // prompt again
                return GetTotalPackage();
            }
        }

        // Get pay frequency
        public static int GetPayFrequency()
        {
            // user input
            Console.WriteLine("Enter your pay frequency (W for weekly, F for fortnightly, M for monthly): ");
            string payFrequency = Console.ReadLine();
            
            string[] validPayFrequencies = {"w", "W", "f", "F", "m", "M"};
            if (validPayFrequencies.Contains(payFrequency))
            {   
                // if a valid option, return relevant integer value
                string payFrequencyUpper = payFrequency.ToUpper();
                if (payFrequencyUpper == "W")
                {
                    return 52;
                }
                else if (payFrequencyUpper == "F")
                {
                    return 26;
                }
                else
                {
                    return 12;
                }
            }
            else
            {
                // otherwise, prompt again
                return GetPayFrequency();
            }
        }
        
        // Round Up to n decimals (sourced from stackoverflow.com as - does exactly what I needed)
        public static double RoundUp(double input, int places)
        {
            double multiplier = Math.Pow(10, Convert.ToDouble(places));
            return Math.Ceiling(input * multiplier) / multiplier;
        }
        
        // Calculate superannuation
        public static double CalculateSuperannuation(double totalPackage)
        {
            return RoundUp((totalPackage - totalPackage / 1.095), 2);
        }
        
        // Calculate taxable income
        public static double CalculateTaxableIncome(double totalPackage, double superannuation)
        {
            return Math.Round((totalPackage - superannuation), 2);
        }

        // Calculate medicare levy
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
        
        // Calculate budget repair levy
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
        
        // Calculate income tax
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
        
        // Salary Details (final output)
        public static void SalaryDetails()
        {   
            // user input
            double totalPackage = GetTotalPackage();
            int payFrequency = GetPayFrequency();
            
            Console.WriteLine("\nCalculating salary details...\n");

            // calculations
            double superannuation = CalculateSuperannuation(totalPackage);
            double taxableIncome = CalculateTaxableIncome(totalPackage, superannuation);
            
            double deductionTaxableIncome = Math.Floor(taxableIncome);
            double medicareLevy = CalculateMedicareLevy(deductionTaxableIncome);
            double budgetRepairLevy = CalculateBudgetRepairLevy(deductionTaxableIncome);
            double incomeTax = CalculateIncomeTax(deductionTaxableIncome);
            double deductions = medicareLevy + budgetRepairLevy + incomeTax;
            
            double netIncome = totalPackage - superannuation - deductions;
            double payPacket = RoundUp(netIncome / payFrequency, 2);
            
            // output
            Console.WriteLine($"Gross package: {totalPackage.ToString("C", CultureInfo.CurrentCulture)}");
            Console.WriteLine($"Superannuation: {superannuation.ToString("C", CultureInfo.CurrentCulture)}\n");
            Console.WriteLine($"Taxable income: {taxableIncome.ToString("C", CultureInfo.CurrentCulture)}\n");
            Console.WriteLine("Deductions:");
            Console.WriteLine($"Medicare levy: {medicareLevy.ToString("C", CultureInfo.CurrentCulture)}");
            Console.WriteLine($"Budget repair levy: {budgetRepairLevy.ToString("C", CultureInfo.CurrentCulture)}");
            Console.WriteLine($"Income tax: {incomeTax.ToString("C", CultureInfo.CurrentCulture)}");
            Console.WriteLine($"Net income: {netIncome.ToString("C", CultureInfo.CurrentCulture)}");
            Console.WriteLine($"Pay Packet: {payPacket.ToString("C", CultureInfo.CurrentCulture)}");
            
            Console.WriteLine("\nPress any key to end...");
            Console.ReadKey();
        }
        
        
        static void Main(string[] args)
        {
            SalaryDetails();
        }
    }
}

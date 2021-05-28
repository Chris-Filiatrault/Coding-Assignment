using System;
using System.Globalization;

namespace coding_assignment
{
    /// <summary>
    /// This class takes the values from the Results class and writes them to the console.
    /// </summary>
    public class ConsoleAppSpecific
    {
        public static void Output()
        {
            Console.WriteLine($"Gross package: {Results.totalPackage.ToString("C", CultureInfo.CurrentCulture)}");
            Console.WriteLine($"Superannuation: {Results.superannuation.ToString("C", CultureInfo.CurrentCulture)}\n");
            Console.WriteLine($"Taxable income: {Results.taxableIncome.ToString("C", CultureInfo.CurrentCulture)}\n");
            Console.WriteLine("Deductions:");
            Console.WriteLine($"Medicare levy: {Results.medicareLevy.ToString("C", CultureInfo.CurrentCulture)}");
            Console.WriteLine($"Budget repair levy: {Results.budgetRepairLevy.ToString("C", CultureInfo.CurrentCulture)}");
            Console.WriteLine($"Income tax: {Results.incomeTax.ToString("C", CultureInfo.CurrentCulture)}");
            Console.WriteLine($"Net income: {Results.netIncome.ToString("C", CultureInfo.CurrentCulture)}");
            Console.WriteLine($"Pay Packet: {Results.payPacket.ToString("C", CultureInfo.CurrentCulture)}");
            Console.WriteLine("\nPress any key to end...");
            Console.ReadKey();
        }
    }
}
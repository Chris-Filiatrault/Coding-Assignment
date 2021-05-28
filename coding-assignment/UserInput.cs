using System;
using System.Linq;

namespace coding_assignment
{
    /// <summary>
    /// This class takes in user input for the total package amount and pay frequency. 
    /// </summary>
    public class UserInput
    {
        public static double GetTotalPackage()
        {
            double totalPackage = 0;
            bool isValid = false;

            while (!isValid)
            {
                Console.WriteLine("Enter your salary package amount: ");
                string userInput = Console.ReadLine();

                userInput = Utilities.RemoveDollarSymbol(userInput);
                
                if (!double.TryParse(userInput, out totalPackage))
                {
                    Console.WriteLine("Please enter a valid number, excluding characters and symbols.");
                }
                else if (totalPackage < 0)
                {
                    Console.WriteLine("Cannot be a negative number.");
                }
                else
                {
                    isValid = true;
                }
            }
            return totalPackage;
        }

        public static int GetPayFrequency()
        {
            int payFrequency = 12; // default to monthly. Can't use 0 due to dividing by payFrequency in Calculations.cs
            bool isValid = false;
            string[] validPayFrequencies = {"w", "W", "f", "F", "m", "M"};

            while (!isValid)
            {
                Console.WriteLine("Enter your pay frequency (W for weekly, F for fortnightly, M for monthly): ");
                string payFrequencyStr = Console.ReadLine();

                if (validPayFrequencies.Contains(payFrequencyStr))
                {
                    string payFrequencyUpper = payFrequencyStr.ToUpper();
                    if (payFrequencyUpper == "W")
                    {
                        payFrequency = 52;
                        isValid = true;
                    }
                    else if (payFrequencyUpper == "F")
                    {
                        payFrequency = 26;
                        isValid = true;
                    }
                    else
                    {
                        payFrequency = 12;
                        isValid = true;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid pay frequency.");
                }
            }
            return payFrequency;
        }
        
    }
}
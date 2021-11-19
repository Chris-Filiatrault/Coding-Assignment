using System;
using System.Linq;
using System.Globalization;

namespace TaxCalculatorUI
{
    /// <summary>
    /// This class contains miscellaneous methods not relating to a specific class.
    /// </summary>
    public class Utilities
    {
        public static double RoundUp(double input, int places)
        {
            double multiplier = Math.Pow(10, Convert.ToDouble(places));
            return Math.Ceiling(input * multiplier) / multiplier;
        }        
        
        public static string RemoveDollarSymbol(string input)
        {
            if (input != "")
            {
                return input.StartsWith('$') ? input.TrimStart('$') : input;    
            }
            else
            {
                return input;
            }
        }

        public static int PayFrequencyCharToInt(char userInput)
        {
            int payFrequency = 12;
            bool isValid = false;
            char[] validPayFrequencies = { 'w', 'W', 'f', 'F', 'm', 'M' };
            while (!isValid)
            {
                if (validPayFrequencies.Contains(userInput))
                {
                    char payFrequencyUpper = Char.ToUpper(userInput);
                    if (payFrequencyUpper == 'W')
                    {
                        payFrequency = 52;
                        isValid = true;
                    }
                    else if (payFrequencyUpper == 'F')
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
                    // TODO - error handling
                }
            }
            return payFrequency;
        }

        public static string ConvertToCurrency(double amount)
        {
            return amount.ToString("C", CultureInfo.CurrentCulture);
        }

    }
}
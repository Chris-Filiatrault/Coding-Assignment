using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxCalculatorUI.Models;



namespace TaxCalculatorUI.Pages
{
    public class IndexModel : PageModel
    {
        // Can use properties of this object when submitting the form to collect data
        [BindProperty]
        public Values ValuesObject { get; set; }

        public void OnGet()
        {
        }

        // Capture input from the form
        public IActionResult OnPost()
        {
            // if there's an issue with the values returned (required fields not filled out etc)
            // requires logic for validation
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {

                // Perform calculations
                double TotalPackage = ValuesObject.TotalPackage;
                int PayFrequency = Utilities.PayFrequencyCharToInt(ValuesObject.PayFrequency);
                double Superannuation = Calculations.CalculateSuperannuation(TotalPackage);
                double TaxableIncome = Calculations.CalculateTaxableIncome(TotalPackage, Superannuation);
                double DeductionTaxableIncome = Math.Floor(TaxableIncome);
                double MedicareLevy = Calculations.CalculateMedicareLevy(DeductionTaxableIncome);
                double BudgetRepairLevy = Calculations.CalculateBudgetRepairLevy(DeductionTaxableIncome);
                double IncomeTax = Calculations.CalculateIncomeTax(DeductionTaxableIncome);
                double Deductions = MedicareLevy + BudgetRepairLevy + IncomeTax;
                double NetIncome = TotalPackage - Superannuation - Deductions;
                double PayPacket = Utilities.RoundUp(NetIncome / PayFrequency, 2);

                // Create anonymous object to pass values to Results view model
                var results = new
                {
                    TotalPackage = TotalPackage,
                    PayFrequency = PayFrequency,
                    Superannuation = Superannuation,
                    TaxableIncome = TaxableIncome,
                    DeductionTaxableIncome = DeductionTaxableIncome,
                    MedicareLevy = MedicareLevy,
                    BudgetRepairLevy = BudgetRepairLevy,
                    IncomeTax = IncomeTax,
                    Deductions = Deductions,
                    NetIncome = NetIncome,
                    PayPacket = PayPacket
                };

                // Redirect to results page and pass in values in anonymous object 
                return RedirectToPage("/Results", results);
            }
        }
    }
}

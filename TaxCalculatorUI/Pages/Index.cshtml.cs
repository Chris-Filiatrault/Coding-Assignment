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
                ValuesObject.Superannuation = Calculations.CalculateSuperannuation(ValuesObject.TotalPackage);
                ValuesObject.TaxableIncome = Calculations.CalculateTaxableIncome(ValuesObject.TotalPackage, ValuesObject.Superannuation);
                ValuesObject.DeductionTaxableIncome = Math.Floor(ValuesObject.TaxableIncome);
                ValuesObject.MedicareLevy = Calculations.CalculateMedicareLevy(ValuesObject.DeductionTaxableIncome);
                ValuesObject.BudgetRepairLevy = Calculations.CalculateBudgetRepairLevy(ValuesObject.DeductionTaxableIncome);
                ValuesObject.IncomeTax = Calculations.CalculateIncomeTax(ValuesObject.DeductionTaxableIncome);
                ValuesObject.Deductions = ValuesObject.MedicareLevy + ValuesObject.BudgetRepairLevy + ValuesObject.IncomeTax;
                ValuesObject.NetIncome = ValuesObject.TotalPackage - ValuesObject.Superannuation - ValuesObject.Deductions;
                ValuesObject.PayPacket = Utilities.RoundUp(ValuesObject.NetIncome / ValuesObject.PayFrequency, 2);

                // Redirect to results page and pass in values in anonymous object 
                return RedirectToPage("/Results", ValuesObject);
            }
        }
    }
}

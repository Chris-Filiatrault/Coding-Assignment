using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;


namespace TaxCalculatorUI.Pages
{
    public class ResultsModel : PageModel
    {


        [BindProperty(SupportsGet = true)]
        public double TotalPackage { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PayFrequency { get; set; }

        [BindProperty(SupportsGet = true)]
        public double Superannuation { get; set; }

        [BindProperty(SupportsGet = true)]
        public double TaxableIncome { get; set; }

        [BindProperty(SupportsGet = true)]
        public double DeductionTaxableIncome { get; set; }

        [BindProperty(SupportsGet = true)]
        public double MedicareLevy { get; set; }

        [BindProperty(SupportsGet = true)]
        public double BudgetRepairLevy { get; set; }

        [BindProperty(SupportsGet = true)]
        public double IncomeTax { get; set; }

        [BindProperty(SupportsGet = true)]
        public double Deductions { get; set; }

        [BindProperty(SupportsGet = true)]
        public double NetIncome { get; set; }

        [BindProperty(SupportsGet = true)]
        public double PayPacket { get; set; }

        public void OnGet()
        {
            //var results = new
            //{
            //    Superannuation = Calculations.CalculateSuperannuation(TotalPackage),
            //    TaxableIncome = Calculations.CalculateTaxableIncome(TotalPackage, Superannuation),
            //    DeductionTaxableIncome = Math.Floor(TaxableIncome),
            //    MedicareLevy = Calculations.CalculateMedicareLevy(DeductionTaxableIncome),
            //    BudgetRepairLevy = Calculations.CalculateBudgetRepairLevy(DeductionTaxableIncome),
            //    IncomeTax = Calculations.CalculateIncomeTax(DeductionTaxableIncome),
            //    Deductions = MedicareLevy + BudgetRepairLevy + IncomeTax,
            //    NetIncome = TotalPackage - Superannuation - Deductions,
            //    PayPacket = Utilities.RoundUp(NetIncome / PayFrequency, 2)
            //};
        }
    }
}

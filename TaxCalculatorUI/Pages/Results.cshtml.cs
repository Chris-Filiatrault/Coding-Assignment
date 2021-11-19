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
        public string TotalPackage { get; set; }

        [BindProperty(SupportsGet = true)]
        public string PayFrequency { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Superannuation { get; set; }

        [BindProperty(SupportsGet = true)]
        public string TaxableIncome { get; set; }

        [BindProperty(SupportsGet = true)]
        public string DeductionTaxableIncome { get; set; }

        [BindProperty(SupportsGet = true)]
        public string MedicareLevy { get; set; }

        [BindProperty(SupportsGet = true)]
        public string BudgetRepairLevy { get; set; }

        [BindProperty(SupportsGet = true)]
        public string IncomeTax { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Deductions { get; set; }

        [BindProperty(SupportsGet = true)]
        public string NetIncome { get; set; }

        [BindProperty(SupportsGet = true)]
        public string PayPacket { get; set; }

        public void OnGet()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxCalculatorUI.Models
{
    public class Results
    {
        public string TotalPackage { get; set; }
        public string PayFrequency { get; set; }
        public string Superannuation { get; set; }
        public string TaxableIncome { get; set; }
        public string DeductionTaxableIncome { get; set; }
        public string MedicareLevy { get; set; }
        public string BudgetRepairLevy { get; set; }
        public string IncomeTax { get; set; }
        public string Deductions { get; set; }
        public string NetIncome { get; set; }
        public string PayPacket { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace TaxCalculatorUI.Models
{
    public class Values
    {
        [Required]
        public double TotalPackage { get; set; }

        [Required]
        public char PayFrequency { get; set; }

        public double Superannuation { get; set; }
        public double TaxableIncome { get; set; }
        public double DeductionTaxableIncome { get; set; }
        public double MedicareLevy { get; set; }
        public double BudgetRepairLevy { get; set; }
        public double IncomeTax { get; set; }
        public double Deductions { get; set; }
        public double NetIncome { get; set; }
        public double PayPacket { get; set; }
    }
}

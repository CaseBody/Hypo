using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypo.Classes
{
    public class CalculationResult
    {
        public double MaxDebt { get; set; }
        public double MonthlyRent { get; set; }
        public double MonthlyPayment { get; set; }
        public string ErrorMessage { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FutureValueModel.Models
{
    public class FutureValueModel
    {
        [Required(ErrorMessage ="please enter value")]
        public decimal MonthlyInvestment { get; set; }
        [Required]
        public decimal YearlyInterestRare { get; set; }
        [Range(0,99)]
        public int Years { get; set; }
        public decimal CaculateFurtureValue ()
        {
            int months = Years * 12;
            decimal MonthlyInterestRate = YearlyInterestRare / 12 / 100;
            decimal furtureValue = 0;
            for (int i = 0; i <  months; i++)
            {
                furtureValue = (furtureValue + MonthlyInvestment) * (1 + MonthlyInterestRate); 
            }

            return furtureValue;
        }
    }
}

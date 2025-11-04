using System;

namespace AgeCalc.Models
{
    public class AgeCalculatorModel
    {
        public DateTime? BirthDate { get; set; }
        public int? Years { get; set; }
        public int? Months { get; set; }
        public int? Days { get; set; }
    }
}

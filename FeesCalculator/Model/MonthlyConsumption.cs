using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeesCalculator.Model
{
    public class MonthlyConsumption
    {
        public int Id { get; set; }
	    public string NameofMonth { get; set; }
        public int NumberofPeople { get; set; }
        public decimal CwCurrentValue { get; set;}
        public decimal CwChange { get; set; }
        public decimal CwPerPerson { get; set; }
        public decimal ZwCurrentValue { get; set; }
        public decimal ZwChange { get; set; }
        public decimal ZwPerPerson { get; set; }
        public decimal COCurrentValue { get; set; }
        public decimal COChange { get; set; }
        public decimal COPerPerson { get; set; }
        public decimal ElecCurrentValue { get; set; }
        public decimal ElecChange { get; set; }
        public decimal ElecPerPerson { get; set; }
        public decimal OtherCurrentValue { get; set; }
        public decimal OtherPerPerson { get; set; }
        public decimal SumPerPerson { get; set; }
    }
}

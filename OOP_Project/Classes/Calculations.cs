using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.Classes
{
    public class Calculations
    {
        private DateTime Now = DateTime.UtcNow;
        private int AgeInMonths;
        private int Age;
        private TableReader TaxReader = new TableReader();

        private DateTime ConvertBirthDate(string birthDate)
        {
            return Convert.ToDateTime(birthDate);
        }

        public int CalculateAge(string birthDate)
        {
            var past = ConvertBirthDate(birthDate);
            AgeInMonths = 12 * (Now.Year - past.Year) + (Now.Month - past.Month);
            Age = AgeInMonths / 12;
            return Age;
        }

        public decimal CalculateInterest(int principalAmount, decimal monthlyInterestRate )
        {
            return principalAmount * monthlyInterestRate / 100;
        }

        public decimal CalculateAccruedAmount(int principalAmount,decimal monthlyInterestRate)
        {
            return principalAmount + (CalculateInterest(principalAmount, monthlyInterestRate) * AgeInMonths);
        }

        public double GetPayroll(int salary)
        {
            return salary * double.Parse(TaxReader.ReadCell(5, 5));
        }

    }


}

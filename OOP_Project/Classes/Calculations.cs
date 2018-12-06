using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace OOP_Project.Classes
{
    public class Calculations:Excel
    {
        private DateTime Now = DateTime.UtcNow;
        private int AgeInMonths;
        private int Age;

        public Calculations(string path, int sheet) : base(path, sheet)
        {
        }
        public int CalculateAge(string birthDate)
        {
            var past = ConvertBirthDate(birthDate);
            AgeInMonths = 12 * (Now.Year - past.Year) + (Now.Month - past.Month);
            Age = AgeInMonths / 12;
            return Age;
        }
        public DateTime ConvertBirthDate(string birthDate)
        {
            return Convert.ToDateTime(birthDate);
        }

        public decimal CalculateInterest(int principalAmount, decimal monthlyInterestRate )
        {
            return principalAmount * monthlyInterestRate / 100;
        }

        public decimal CalculateAccruedAmount(int principalAmount,decimal monthlyInterestRate)
        {
            return principalAmount + (CalculateInterest(principalAmount, monthlyInterestRate) * AgeInMonths);
        }

        public decimal GetSalary(bool fullTime, decimal rate)
        {
            return 0;
        }

        public decimal GetDataFromApi()
        {
            return 0;
        }

        
    }


}

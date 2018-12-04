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

        //public int CalculateAge(DateTime birthDate)
        //{
        //    if ((DateTime.Today.Day - birthDate.Day) > 0)
        //    {
        //        return DateTime.Today.Year - birthDate.Year - 1;
        //    }
        //    return DateTime.Today.Year - birthDate.Year;
        //}

        public int CalculateAgeUsingMonths(string birthDate)
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
        
    }
}

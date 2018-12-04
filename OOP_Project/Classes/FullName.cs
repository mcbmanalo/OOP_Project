using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.Classes
{
    public class Person
    {
        public string FirstName;
        public string MiddleName;
        public string LastName;
        public string Address;
        public string BirthDate;
        static string GetFullName()
        {

            Console.WriteLine("Please enter your First Name");
            var firstName = Console.ReadLine();

            Console.WriteLine("\nPlease enter your Middle Initial");
            var middleInitial = Console.ReadLine();

            Console.WriteLine("\nPlease enter your Last Name");
            var lastName = Console.ReadLine();

            //return FirstName +" "+ MiddleInitial[0] +". "+ LastName;
            return $"{firstName.ToUpperInvariant()[0]}{firstName.ToLowerInvariant().Remove(0, 1)} {middleInitial.ToUpperInvariant()[0]}. {lastName.ToUpperInvariant()[0]}{lastName.ToLowerInvariant().Remove(0, 1)}";
        }
    }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.Classes
{
    public class Person
    {
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private string _address;
        private string _birthDate;

        public int PersonId
        {
            get => _personId;
            set
            {
                _personId = value;
            }
        }

        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }
        public string MiddleName
        {
            get => _middleName;
            set => _middleName = value;
        }
        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }
        public string Address
        {
            get => _address;
            set => _address = value;
        }
        public string BirthDate
        {
            get => _birthDate;
            set => _birthDate = value;
        }

        public List<Product> OwnedProducts = new List<Product>();
        private int _personId;

        public Person(string firstName, string middleName, string lastName, string address, string birthDate)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Address = address;
            BirthDate = birthDate;
        }

        public string GetFullName()
        {
            return $"{FirstName.ToUpperInvariant()[0]}{FirstName.ToLowerInvariant().Remove(0, 1)} {MiddleName.ToUpperInvariant()[0]}. {LastName.ToUpperInvariant()[0]}{LastName.ToLowerInvariant().Remove(0, 1)}";
        }
    }
}

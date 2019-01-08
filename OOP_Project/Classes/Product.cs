using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace OOP_Project.Classes
{
    public class Product : ObservableObject
    {
        #region Properties

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                RaisePropertyChanged(nameof(Description));
            }
        }
        public float Price
        {
            get => _price;
            set
            {
                _price = value;
                RaisePropertyChanged(nameof(Price));
            }
        }
        public float SRP
        {
            get => _srp;
            set
            {
                _srp = value;
                RaisePropertyChanged(nameof(SRP));
            }
        }
        public int Items
        {
            get => _items;
            set
            {
                _items = value;
                RaisePropertyChanged(nameof(Items));
            }
        }

        public decimal MonthlyInterestRate
        {
            get => _monthlyInterestRate;
            set
            {
                _monthlyInterestRate = value;
                RaisePropertyChanged(nameof(MonthlyInterestRate));
            }
        }


        #endregion

        #region Fields

        private string _name;
        private string _description;
        private int _items;
        private float _srp;
        private float _price;
        private decimal _monthlyInterestRate;

        #endregion

        #region Constructor

        public Product(string name, float price, decimal monthlyInterestRate, int items, string description)
        {
            Name = name;
            Price = price;
            MonthlyInterestRate = monthlyInterestRate;
            Items = items;
            Description = description;
        }

        #endregion

        #region Methods

        public string GetDescription()
        {
            return Description;
        }

        public void DeductItems(int items)
        {
            Items = Items - items;
        }

        #endregion

    }
}

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

        #endregion

        #region Fields

        private string _name;
        private string _description;
        private int _items;
        private float _srp;
        private float _price;

        #endregion

        #region Constructor

        public Product(string name, float price, float srp, int items)
        {
            Name = name;
            Price = price;
            SRP = srp;
            Items = items;
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

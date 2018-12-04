using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.Classes
{
    public class Product
    {
        private string Name;
        private string Description;
        private float Price;
        private float SRP;
        private int Items;

        public Product(string name, float price, float srp, int items)
        {
            Name = name;
            Price = price;
            SRP = srp;
            Items = items;
        }

        public string GetDescription()
        {
            return Description;
        }

        public void DeductItems(int items)
        {
            Items = Items - items;
        }
    }
}

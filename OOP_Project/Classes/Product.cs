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

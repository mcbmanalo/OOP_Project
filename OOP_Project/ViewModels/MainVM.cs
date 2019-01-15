using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System.IO;
using OOP_Project.Classes;
using ExcelDataReader;

namespace OOP_Project.ViewModels
{
    public class MainVM : ObservableObject
    {
        public List<Product> JewelryItemsList { get; } = new List<Product>();
        public List<Person> CustomerList { get; } = new List<Person>();
        public List<Person> EmployeeList { get; } = new List<Person>();
        public List<string> TestExcelReader { get; } = new List<string>();
        public ICommand TestCommand => new RelayCommand(Try);
        public Excel ReadExcel = new Excel();
        public Calculations Calculate = new Calculations();
        private string _test;

        public MainVM()
        {
            GetInventoryList();
        }

        private void GetInventoryList()
        {
            //Test = ReadExcel.ReadCell(5, 1);
            ReadExcel.Path = @"C:\Users\MCBManalo\Source\Repos\OOP_Project\OOP_Project\References\Jewelry Inventory.xlsx";
            var rowCounter = 2;
            while (ReadExcel.ReadCell(rowCounter, 1) != null && ReadExcel.ReadCell(rowCounter, 1) != "")
            {
                string name = "";
                float price = 0;
                decimal monthlyInterestRate = 0;
                int items = 0;
                string description = "";

                for (int column = 1; column < 6; column++)
                {
                    switch (column)
                    {
                        case 1:
                            name = Convert.ToString(ReadExcel.ReadCell(rowCounter, column));
                            break;
                        case 2:
                            price = float.Parse(ReadExcel.ReadCell(rowCounter, column));
                            break;
                        case 3:
                            monthlyInterestRate = decimal.Parse(ReadExcel.ReadCell(rowCounter, column));
                            break;
                        case 4:
                            items = int.Parse(ReadExcel.ReadCell(rowCounter, column));
                            break;
                        case 5:
                            description = Convert.ToString(ReadExcel.ReadCell(rowCounter, column));
                            JewelryItemsList.Add(new Product(name, price, monthlyInterestRate, items, description));
                            break;
                    }
                }

                rowCounter++;
            }

            ReadExcel.Row = rowCounter;
            ReadExcel.Column = 5;
            RaisePropertyChanged(nameof(JewelryItemsList));
        }

        public string Test
        {
            get => _test;
            set
            {
                _test = value;
                RaisePropertyChanged(nameof(Test));
            }
        }

        public void Try()
        {
           Test = Convert.ToString(Calculate.GetPayroll(25000,5,5));
        }

    }
}

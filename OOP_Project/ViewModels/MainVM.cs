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
        public List<Product> JewelryItemsList = new List<Product>();
        public List<Person> CustomerList = new List<Person>();
        public List<Person> EmployeeList = new List<Person>();
        public List<string> TestExcelReader { get; } = new List<string>();
        public ICommand TestCommand => new RelayCommand(Try);
        public Excel ReadExcel = new Excel();
        public Calculations Calculate = new Calculations();
        private string _test;

        public MainVM()
        {
            for (int row = 0; row < 5; row++)
            {
                string name = "";
                int price = 0;
                decimal monthlyInterestRate = 0;
                int items = 0;
                string description = "";

                for (int column = 0; column < 4; column++)
                {
                    
                }
            }
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
           Test = Convert.ToString(Calculate.GetPayroll(25000,1,1));
        }

    }
}

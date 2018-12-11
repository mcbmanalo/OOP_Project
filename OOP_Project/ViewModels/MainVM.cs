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
        public TableReader ReadExcel = new TableReader();
        public Calculations Calculate = new Calculations();
        private string _test;

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
           Test = Convert.ToString(Calculate.GetPayroll(25000));
        }

    }
}

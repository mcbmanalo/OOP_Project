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
using ExcelDataReader;
using OOP_Project.Classes;

namespace OOP_Project.ViewModels
{
    public class MainVM : ObservableObject
    {
        public List<Product> JewelryItemsList = new List<Product>();
        public List<Person> CustomerList = new List<Person>();
        public List<Person> EmployeeList = new List<Person>();
        public List<string> TestExcelReader { get; } = new List<string>();
        public ICommand TestCommand => new RelayCommand(OpenExcel);
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

        public void OpenExcel()
        {
            using (var stream = File.Open(Test, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    do
                    {
                        while (reader.Read())
                        {
                            TestExcelReader.Add(reader.GetString(1));   
                        }
                    } while (reader.NextResult());
                }
            }
        }
    }
}

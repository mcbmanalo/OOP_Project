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


namespace OOP_Project.ViewModels
{
    public class MainVM : ObservableObject
    {
        private string _tryThis;
        public string TryThis
        {
            get { return _tryThis; }
            set
            {
                _tryThis = value;
                RaisePropertyChanged(nameof(TryThis));
            }
        }

        public ICommand TryCommand => new RelayCommand(ShowText);

        private void ShowText()
        {
            TryThis = "Test";
        }

    }

    
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace OOP_Project.ViewModels
{
    public class MainVM : INotifyPropertyChanged
    {
        private string _test;
        
        public string Test
        {
            get => _test;
            set
            {
                _test = value;
                OnPropertyChanged(Test);
            }
        }

        public ICommand ClickCommand => new RelayCommand(Write);

        public void Write()
        {
            Test = "Hello this is a test";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}

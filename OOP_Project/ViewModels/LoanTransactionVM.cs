using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace OOP_Project.ViewModels
{
    public class LoanTransactionVM : ObservableObject
    {

        #region Fields

        private string _customerName;
        private string _customerAddress;
        private long _contactNumber;
        private string _selectedJewelryType;
        private string _selectedJewelryQuality;
        private double _jewelryWeight;
        private double _discount;
        private string _otherDetails;
        private double _actualValueJ;
        private double _amountLoaned;

        #endregion

        public string CustomerName
        {
            get => _customerName;
            set
            {
                _customerName = value;
                RaisePropertyChanged(nameof(CustomerName));
            }
        }

        public string CustomerAddress
        {
            get => _customerAddress;
            set
            {
                _customerAddress = value;
                RaisePropertyChanged(nameof(CustomerAddress));
            }
        }

        public long ContactNumber
        {
            get => _contactNumber;
            set
            {
                _contactNumber = value;
                RaisePropertyChanged(nameof(ContactNumber));
            }
        }

        public string SelectedJewelryType
        {
            get => _selectedJewelryType;
            set
            {
                _selectedJewelryType = value;
                RaisePropertyChanged(nameof(SelectedJewelryType));
            }
        }

        public string SelectedJewelryQuality
        {
            get => _selectedJewelryQuality;
            set
            {
                _selectedJewelryQuality = value;
                RaisePropertyChanged(nameof(SelectedJewelryQuality));
            }
        }

        public double JewelryWeight
        {
            get => _jewelryWeight;
            set
            {
                _jewelryWeight = value;
                RaisePropertyChanged(nameof(JewelryWeight));
            }
        }

        public double Discount
        {
            get => _discount;
            set
            {
                _discount = value;
                RaisePropertyChanged(nameof(Discount));
            }
        }

        public string OtherDetails
        {
            get => _otherDetails;
            set
            {
                _otherDetails = value;
                RaisePropertyChanged(nameof(OtherDetails));
            }
        }

        public double ActualValueJ
        {
            get => _actualValueJ;
            set
            {
                _actualValueJ = value;
                RaisePropertyChanged(nameof(ActualValueJ));
            }
        }

        public double AmountLoaned
        {
            get => _amountLoaned;
            set
            {
                _amountLoaned = value;
                RaisePropertyChanged(nameof(AmountLoaned));
            }
        }

        public string[] JewelryTypeOptions => Enum.GetNames(typeof(JewelryType));
        //public string[] JewelryQualityOptions => Enum.GetNames(typeof(JewelryQuality));
        private string[] jewelryQualityOptions = new string[3] { "10k", "18k", "21k" };
        //public string[] JewelryQualityOptions => typeof(JewelryQuality).GetProperties("Name");

        public ICommand TransactCommand => new RelayCommand(TransactProc);

        public string[] JewelryQualityOptions
        {
            get => jewelryQualityOptions;
            set
            {
                jewelryQualityOptions = value;
                RaisePropertyChanged(nameof(JewelryQualityOptions));
            }
        }

        private void TransactProc()
        {

        }

        public enum JewelryType
        {
            Rings,
            Necklaces,
            Bracelets,
            Earrings
        }

        private enum JewelryQuality
        {
            [Display(Name = "10k")]
            Ten,
            [Display(Name = "18k")]
            Eighteen,
            [Display(Name = "21k")]
            TwentyOne
        }

    }
}

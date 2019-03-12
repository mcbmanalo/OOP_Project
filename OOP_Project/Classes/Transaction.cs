using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace OOP_Project.Classes
{
    public class Transaction : ObservableObject
    {
        private string _name;
        private string _address;
        private long _contactNumber;
        private string _jewelryType;
        private int _jewelryQuality;
        private double _jewelryWeight;
        private double _discount;
        private string _otherDetails;
        private double _actualValue;
        private double _amountLoaned;
        private DateTime _dateOfTransaction;
        private int _transactionId;

        public Transaction(string name, string address, long contactNumber, string jewelryType, int jewelryQuality, double jewelryWeight, double discount, string otherDetails, double actualValue, double amountLoaned, DateTime dateOfTransaction, int transactionId)
        {
            Name = name;
            Address = address;
            ContactNumber = contactNumber;
            JewelryType = jewelryType;
            JewelryQuality = jewelryQuality;
            JewelryWeight = jewelryWeight;
            Discount = discount;
            OtherDetails = otherDetails;
            ActualValue = actualValue;
            AmountLoaned = amountLoaned;
            DateOfTransaction = dateOfTransaction;
            TransactionId = transactionId;
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                RaisePropertyChanged(nameof(Address));
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

        public string JewelryType
        {
            get => _jewelryType;
            set
            {
                _jewelryType = value;
                RaisePropertyChanged(nameof(JewelryType));
            }
        }

        public int JewelryQuality
        {
            get => _jewelryQuality;
            set
            {
                _jewelryQuality = value;
                RaisePropertyChanged(nameof(JewelryQuality));
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

        public double ActualValue
        {
            get => _actualValue;
            set
            {
                _actualValue = value;
                RaisePropertyChanged(nameof(ActualValue));
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

        public DateTime DateOfTransaction
        {
            get => _dateOfTransaction;
            set
            {
                _dateOfTransaction = value;
                RaisePropertyChanged(nameof(DateOfTransaction));
            }
        }

        public int TransactionId
        {
            get => _transactionId;
            set
            {
                _transactionId = value;
                RaisePropertyChanged(nameof(TransactionId));
            }
        }
    }
}

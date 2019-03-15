using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace OOP_Project.ViewModels
{
    public class PaymentTransactionVM : ObservableObject
    {

        #region Fields

        private string _customerName;
        private string _customerAddress;
        private long _contactNumber;
        private int _transactionId;
        private double _amountLoaned;
        private double _accumulatedAmount;
        private double _amountPaid;
        private double _balance;
        private DateTime _dateOfTransaction;

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
        public int TransactionId
        {
            get => _transactionId;
            set
            {
                _transactionId = value;
                RaisePropertyChanged(nameof(TransactionId));
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
        public double AccumulatedAmount
        {
            get => _accumulatedAmount;
            set
            {
                _accumulatedAmount = value;
                RaisePropertyChanged(nameof(AccumulatedAmount));
            }
        }
        public double AmountPaid
        {
            get => _amountPaid;
            set
            {
                _amountPaid = value;
                RaisePropertyChanged(nameof(AmountPaid));
            }
        }
        public double Balance
        {
            get => _balance;
            set
            {
                _balance = value;
                RaisePropertyChanged(nameof(Balance));
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

    }
}

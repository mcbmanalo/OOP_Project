﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.EntityFrameworkCore;
using OOP_Project.Classes;

namespace OOP_Project.ViewModels
{
    public class PaymentTransactionVM : ObservableObject
    {

        #region Fields

        private int _transactionId;
        private double _amountPaid;
        private string _customerName;
        private string _customerAddress;
        private long _contactNumber;
        private double _amountLoaned;
        private double _accumulatedAmount;

        #endregion

        #region Properties

        public int TransactionId
        {
            get => _transactionId;
            set
            {
                _transactionId = value;
                RaisePropertyChanged(nameof(TransactionId));
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

        public Transaction Transaction { get; set; }

        #endregion

        public ICommand PayLoanCommand => new RelayCommand(PayLoanProc);

        private void PayLoanProc()
        {
            if (Transaction == null)
            {
                TakeTransactionProc();
            }

            var paymentTransactionToday = new PaymentTransactions( TransactionId, CustomerName, CustomerAddress, ContactNumber, AmountLoaned, AccumulatedAmount,
                AmountPaid, AccumulatedAmount-AmountPaid, DateTime.Today );

            var uow = new UnitOfWork.UnitOfWork(new OOProjectContext());

            uow.GetRepository<PaymentTransactions>().Add(paymentTransactionToday);

            if (Transaction.PaymentTransactionsList == null)
            {
                Transaction.PaymentTransactionsList = new List<PaymentTransactions>();
            }

            Transaction.PaymentTransactionsList.Add(paymentTransactionToday);

            uow.GetRepository<Transaction>().Update(Transaction);

            uow.CompleteWork();

        }

        public ICommand TakeTransactionCommand => new RelayCommand(TakeTransactionProc);

        private void TakeTransactionProc()
        {
            var uow = new UnitOfWork.UnitOfWork(new OOProjectContext());
            Transaction.PaymentTransactionsList = uow.GetRepository<PaymentTransactions>().All()
                .Where(c => c.TransactionId == TransactionId)
                .Include(navigationPropertyPath: c => c.Transaction)
                .ToList();

            uow.CompleteWork();
            InputValues();
        }

        private void InputValues()
        {
            CustomerName = Transaction.Name;
            CustomerAddress = Transaction.Address;
            ContactNumber = Transaction.ContactNumber;
            AmountLoaned = Transaction.AmountLoaned;
            AccumulatedAmount = CalculateAccumulatedAmount();
        }

        private double CalculateAccumulatedAmount()
        {
            if (Transaction.PaymentTransactionsList == null)
            {
                var past = Transaction.DateOfTransaction;
                var now = DateTime.Today;

                var age = 365 * (now.Year - past.Year) + 30 * (now.Month - past.Month) + (now.Day - past.Day);

                return Transaction.AmountLoaned + GetInterest(age);
            }

            else
            {
                var past = DateTime.Parse("January 0, 0000");
                var now = DateTime.Today;
                PaymentTransactions paymentTransaction = null;

                foreach (var paymentTransactions in Transaction.PaymentTransactionsList)
                {
                    if (paymentTransactions.DateOfTransaction >= past)
                    {
                        past = paymentTransactions.DateOfTransaction;
                        paymentTransaction = paymentTransactions;
                    }
                }

                double age = 365 * (now.Year - past.Year) + 30 * (now.Month - past.Month) + (now.Day - past.Day);

                return paymentTransaction.Balance + GetInterest(age);
            }
        }

        private double GetInterest(double age)
        {
            return Transaction.AmountLoaned * Transaction.InterestRate * (age / 30);
        }
    }
}

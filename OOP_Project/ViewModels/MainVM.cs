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
//using OOP_Project.Views;
using OOP_Project.Windows;

namespace OOP_Project.ViewModels
{
    public class MainVM : ObservableObject
    {
        public ObservableCollection<Transaction> TransactionsList
        {
            get => _transactionsList;
            set
            {
                _transactionsList = value;
                RaisePropertyChanged(nameof(TransactionsList));
            }
        }

        public List<Product> JewelryItemsList { get; } = new List<Product>();
        public List<Person> CustomerList { get; } = new List<Person>();
        public List<Person> EmployeeList { get; } = new List<Person>();
        public Calculations Calculate = new Calculations();
        private DateTime DateTime { get; set; }
        public LoanTransactionWindow _loanTransactionWindow;
        public PaymentTransactionWindow _paymentTransactionWindow;
        private CheckPaymentsWindow _checkPaymentsWindow;
        private ObservableCollection<Transaction> _transactionsList = new ObservableCollection<Transaction>();
        private Transaction _selectedTransaction;
        private ObservableCollection<PaymentTransactions> _paymentTransactions = new ObservableCollection<PaymentTransactions>();

        public MainVM()
        {
            RefreshTransactionListProc();
        }

        public ObservableCollection<PaymentTransactions> PaymentTransactions
        {
            get => _paymentTransactions;
            set
            {
                _paymentTransactions = value;
                RaisePropertyChanged(nameof(PaymentTransactions));
            }
        }

        public Transaction SelectedTransaction
        {
            get => _selectedTransaction;
            set
            {
                _selectedTransaction = value;
                RaisePropertyChanged(nameof(SelectedTransaction));
            }
        }

        public ICommand RefreshTransactionListCommand => new RelayCommand(RefreshTransactionListProc);

        private void RefreshTransactionListProc()
        {
            var uow = new UnitOfWork.UnitOfWork(new OOProjectContext());

            var transactionslist = uow.GetRepository<Transaction>().All();
            TransactionsList = new ObservableCollection<Transaction>();
            foreach (var transaction in transactionslist)
            {
                TransactionsList.Add(transaction);
            }

            uow.CompleteWork();
        }

        public ICommand LoanCommand => new RelayCommand(LoanProc);

        private void LoanProc()
        {
            _loanTransactionWindow = new LoanTransactionWindow();
            _loanTransactionWindow.Owner = Application.Current.MainWindow;
            _loanTransactionWindow.DataContext = new LoanTransactionVM(this);
            _loanTransactionWindow.ShowDialog();
        }

        public ICommand PaymentCommand => new RelayCommand(PaymentProc);

        private void PaymentProc()
        {
            _paymentTransactionWindow = new PaymentTransactionWindow();
            _paymentTransactionWindow.Owner = Application.Current.MainWindow;
            _paymentTransactionWindow.DataContext = new PaymentTransactionVM(this);
            _paymentTransactionWindow.ShowDialog();
        }

        public ICommand CheckPaymentsCommand => new RelayCommand(CheckPaymentsProc);

        private void CheckPaymentsProc()
        {
            GetAllPaymentTransactions();
            _checkPaymentsWindow = new CheckPaymentsWindow();
            _checkPaymentsWindow.Owner = Application.Current.MainWindow;
            _checkPaymentsWindow.ShowDialog();
        }

        private void GetAllPaymentTransactions()
        {
            PaymentTransactions = new ObservableCollection<PaymentTransactions>();
            var uow = new UnitOfWork.UnitOfWork(new OOProjectContext());

            var paymentTransactions = new ObservableCollection<PaymentTransactions>();

            foreach (var transaction in TransactionsList)
            {

                var paymentTransactionsOfTransaction = uow.GetRepository<PaymentTransactions>().All()
                    .Where(c => c.TransactionId == transaction.TransactionId)
                    .ToList()
                    .OrderBy(c => c.DateOfTransaction);

                foreach (var paymentsOfTransactions in paymentTransactionsOfTransaction)
                {
                    paymentTransactions.Add(paymentsOfTransactions);
                }

            }

            PaymentTransactions = paymentTransactions;

            uow.CompleteWork();
        }



    }
}

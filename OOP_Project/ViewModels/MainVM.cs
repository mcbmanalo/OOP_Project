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
        public List<string> TestExcelReader { get; } = new List<string>();
        public Excel ReadExcel = new Excel();
        public Calculations Calculate = new Calculations();
        private LoanTransactionWindow _loanTransactionWindow;
        private PaymentTransactionWindow _paymentTransactionWindow;
        private ObservableCollection<Transaction> _transactionsList = new ObservableCollection<Transaction>();

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
            _loanTransactionWindow.ShowDialog();
        }

        public ICommand PaymentCommand => new RelayCommand(PaymentProc);

        private void PaymentProc()
        {
            _paymentTransactionWindow = new PaymentTransactionWindow();
            _paymentTransactionWindow.Owner = Application.Current.MainWindow;
            _paymentTransactionWindow.ShowDialog();
        }

        public MainVM()
        {
            RefreshTransactionListProc();
        }

    }
}

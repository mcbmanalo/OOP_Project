using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace OOP_Project.Classes
{
    public class PaymentTransactions : ObservableObject
    {
        public int PaymentTransactionsId { get; set; }
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public long ContactNumber { get; set; }
        public double AmountLoaned { get; set; }
        public double AccumulatedAmount { get; set; }
        public double AmountPaid { get; set; }
        public double Balance { get; set; }
        public DateTime DateOfTransaction { get; set; }

        public PaymentTransactions()
        {
            
        }

        public PaymentTransactions(int transactionId, string customerName, string customerAddress, long contactNumber, double amountLoaned, double accumulatedAmount, double amountPaid, double balance, DateTime dateOfTransaction)
        {
            TransactionId = transactionId;
            CustomerName = customerName;
            CustomerAddress = customerAddress;
            ContactNumber = contactNumber;
            AmountLoaned = amountLoaned;
            AccumulatedAmount = accumulatedAmount;
            AmountPaid = amountPaid;
            Balance = balance;
            DateOfTransaction = dateOfTransaction;
        }
    }
}

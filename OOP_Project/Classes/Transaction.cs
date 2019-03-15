using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace OOP_Project.Classes
{
    public class Transaction : ObservableObject
    {

        public int TransactionId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public long ContactNumber { get; set; }
        public string JewelryType { get; set; }
        public string JewelryQuality { get; set; }
        public double JewelryWeight { get; set; }
        public double Discount { get; set; }
        public string OtherDetails { get; set; }
        public double ActualValue { get; set; }
        public double AmountLoaned { get; set; }
        public double Balance { get; set; }
        public DateTime DateOfTransaction { get; set; }
        public ICollection<PaymentTransactions> PaymentTransactionsList { get; set; }

        public Transaction()
        {
            
        }

        public Transaction(string name, string address, long contactNumber, string jewelryType, string jewelryQuality, double jewelryWeight, double discount, string otherDetails, double actualValue, double amountLoaned, DateTime dateOfTransaction)
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
            Balance = AmountLoaned;
        }


    }
}

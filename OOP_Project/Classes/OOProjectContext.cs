using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;


namespace OOP_Project.Classes
{
    public class OOProjectContext: DbContext
    {
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<PaymentTransactions> PaymentTransactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(
                    "Server =.\\SQLExpress; Database = OOProjectDatabase; Trusted_Connection = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>(e =>
            {
                e.ToTable("Transaction");

                e.HasKey(c => c.TransactionId);
                e.Property(c => c.TransactionId)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                e.Property(c => c.Balance);

                e.Property(c => c.ActualValue);

                e.Property(c => c.Address);

                e.Property(c => c.AmountLoaned);

                e.Property(c => c.ContactNumber);

                e.Property(c => c.DateOfTransaction);

                e.Property(c => c.Discount);

                e.Property(c => c.JewelryQuality);

                e.Property(c => c.JewelryType);

                e.Property(c => c.JewelryWeight);

                e.Property(c => c.Name);

                e.Property(c => c.OtherDetails);

            });

            modelBuilder.Entity<PaymentTransactions>(e =>
            {
                e.HasKey(c => c.PaymentTransactionsId);
                e.Property(c => c.PaymentTransactionsId)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                e.Property(c => c.CustomerName);

                e.Property(c => c.CustomerAddress);

                e.Property(c => c.ContactNumber);

                e.Property(c => c.AmountLoaned);

                e.Property(c => c.AccumulatedAmount);

                e.Property(c => c.AmountPaid);

                e.Property(c => c.Balance);

                e.Property(c => c.DateOfTransaction);

                e.HasOne(navigationExpression: c => c.Transaction)
                    .WithMany(navigationExpression: c => c.PaymentTransactionsList)
                    .HasForeignKey(c => c.TransactionId);
            });
        }
       
    }
}

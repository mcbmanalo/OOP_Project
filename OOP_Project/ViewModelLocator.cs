using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Project.ViewModels;

namespace OOP_Project
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            MainVM = new MainVM();
            LoanTransactionVM = new LoanTransactionVM();
        }
        public MainVM MainVM { get; }
        public LoanTransactionVM LoanTransactionVM { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace OOP_Project.Classes
{
    public class Excel : ObservableObject
    {
        //public string Path = @"C:\Users\MCBManalo\Documents\GitHub\OOP_Project\OOP_Project\References\Tax Table.xlsx";
        //public string Path = @"C:\Users\Admin\Source\Repos\OOP_Project\OOP_Project\References\Tax Table.xlsx";
        //public string Path = @"C:\Users\MCBManalo\Source\Repos\OOP_Project\OOP_Project\References\Tax Table.xlsx";

        _Application excel = new _Excel.Application();
        private Workbook WorkBook;
        private Worksheet WorkSheet;
        private int _row;
        private int _column;
        private string _path;

        public string Path
        {
            get => _path;
            set
            {
                _path = value;
                RaisePropertyChanged(nameof(Path));
            }
        }
        

        public int Row
        {
            get => _row;
            set
            {
                _row = value;
                RaisePropertyChanged(nameof(Row));
            }
        }

        public int Column
        {
            get => _column;
            set
            {
                _column = value;
                RaisePropertyChanged(nameof(Column));
            }
        }

        public Excel()
        {
            WorkBook = excel.Workbooks.Open(Path);
            WorkSheet = WorkBook.Worksheets[1];
        }

        public string ReadCell(int row , int column)
        {
            if (row == 0)
                row++;
            if (column == 0)
                column++;
            
            if (WorkSheet.Cells[row, column].Value2 != null)
                return Convert.ToString(WorkSheet.Cells[row, column].Value2);
            else
                return "";
        }

        public void WriteCell(int row, int column, string s)
        {
            row++;
            column++;
            WorkSheet.Cells[row, column].Value2 = s;
        }

        public void Save()
        {
            WorkBook.Save();
        }

        public void SaveAs()
        {
            WorkBook.SaveAs(Path);
        }
        
        //private void GetMaximumRowsAndColumns()
        //{
        //    int row = 1;
        //    int column = 1;
        //}
    }
}

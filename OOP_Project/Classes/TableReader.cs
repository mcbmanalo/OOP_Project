using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace OOP_Project.Classes
{
    public class TableReader
    {
        public string Path = @"C:\Users\MCBManalo\Documents\GitHub\OOP_Project\OOP_Project\References\Tax Table.xlsx";

        _Application excel = new _Excel.Application();
        private Workbook WorkBook;
        private Worksheet WorkSheet;

        public TableReader( int sheet)
        {
            WorkBook = excel.Workbooks.Open(Path);
            WorkSheet = WorkBook.Worksheets[sheet];
        }

        public string ReadCell(int i, int j)
        {
            i++;
            j++;
            if (WorkSheet.Cells[i, j].Value2 != null)
                return Convert.ToString(WorkSheet.Cells[i, j].Value2);
            else
                return "";
        }
    }
}

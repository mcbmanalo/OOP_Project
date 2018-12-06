using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace OOP_Project.Classes
{
    public class Excel
    {
        public string Path = "";

        _Application excel = new _Excel.Application();
        private Workbook WorkBook;
        private Worksheet WorkSheet;

        public Excel(string path, int sheet)
        {
            this.Path = path;
            WorkBook = excel.Workbooks.Open(Path);
            WorkSheet = WorkBook.Worksheets[sheet];
        }

        public string ReadCell(int i, int j)
        {
            i++;
            j++;
            if (WorkSheet.Cells[i, j].Value2 != null)
                return WorkSheet.Cells[i, j].Value2;
            else
                return "";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace OOP_Project.Converters
{
    public class StringAdditionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var count = value.ToString().Length;
            var idString = value.ToString();
            int counter = 7;
            while (count != 8)
            {
                idString = "0" + idString;
                count = idString.Length;
            }

            return idString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

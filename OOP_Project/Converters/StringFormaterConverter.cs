using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace OOP_Project.Converters
{
    public class StringFormaterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isGrams = (parameter as string) == "grams";
            if (isGrams)
            {
                var gramString = value.ToString() + " g";
                return gramString;
            }
            string formatted = "₱ " + value.ToString();
            return formatted;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

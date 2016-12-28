using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using PrimeraValdivia.Models;

namespace PrimeraValdivia.Helpers
{
    public class DateTimeToDateStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DateTime.Parse(value.ToString()).ToString("dd/MM/yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DateTime.Parse(value.ToString());
        }
    }
}
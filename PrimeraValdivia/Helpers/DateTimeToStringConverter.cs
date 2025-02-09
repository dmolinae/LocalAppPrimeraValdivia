﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using PrimeraValdivia.Models;

namespace PrimeraValdivia.Helpers
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DateTime.Parse(value.ToString()).ToString("dd/MM/yyyy HH:mm");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DateTime.Parse(value.ToString());
        }
    }
}
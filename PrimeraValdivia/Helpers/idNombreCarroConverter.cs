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
    public class idNombreCarroConverter : IValueConverter
    {
        Carro CModel = new Carro();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Carro carro = CModel.ObtenerCarro(int.Parse(value.ToString()));
            return carro.nombre;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }
    }
}

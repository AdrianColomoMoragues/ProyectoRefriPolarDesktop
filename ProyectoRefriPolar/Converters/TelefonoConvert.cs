using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ProyectoRefriPolar.Converters
{
    class TelefonoConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string numero = value.ToString();
            int longitud = numero.Length / 4;
            string parte1 = numero.Substring(0, 3);
            string parte2 = numero.Substring(longitud, 2);
            string parte3 = numero.Substring(longitud * 2, 2);
            string parte4 = numero.Substring(longitud * 3, 2);
            return $"+34 {parte1} {parte2} {parte3} {parte4}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

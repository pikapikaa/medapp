using System;
using System.Globalization;
using Xamarin.Forms;

namespace MedExpertClientClone.Converters
{
    public class BoolToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool flag = (bool)value;
            if (flag)
            {
                return "round_check_box_active";
            }
            else
            {
                return "round_check_box_inactive";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}

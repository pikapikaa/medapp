using System;
using System.Globalization;
using MedExpertClientClone.Models;
using Xamarin.Forms;

namespace MedExpertClientClone.Converters
{
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            AuditOperationStatus flag = (AuditOperationStatus)value;
            switch (flag)
            {
                case AuditOperationStatus.Created:
                    return "#00A3FF";
                case AuditOperationStatus.Executed:
                    return "#6E758D";
                case AuditOperationStatus.Running:
                    return "#00C395";
                case AuditOperationStatus.Signed:
                    return "#FFB800";
                case AuditOperationStatus.Signing:
                    return "#F82463";
                default:
                    return "white";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}

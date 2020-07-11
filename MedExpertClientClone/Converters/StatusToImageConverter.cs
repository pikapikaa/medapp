using System;
using System.Globalization;
using MedExpertClientClone.Models;
using Xamarin.Forms;

namespace MedExpertClientClone.Converters
{
    public class StatusToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            AuditOperationStatus flag = (AuditOperationStatus)value;
            switch (flag)
            {
                case AuditOperationStatus.Created:
                    return "audit_new";
                case AuditOperationStatus.Executed:
                    return "audit_finished";
                case AuditOperationStatus.Running:
                    return "audit_running";
                case AuditOperationStatus.Signed:
                    return "audit_signed";
                case AuditOperationStatus.Signing:
                    return "audit_signing";
                default:
                    return "audit_new";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
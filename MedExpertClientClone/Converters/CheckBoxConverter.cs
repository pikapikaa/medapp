using System;
using System.Globalization;
using MedExpertClientClone.Models;
using Xamarin.Forms;

namespace MedExpertClientClone.Converters
{
    public class CheckBoxConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var flag = (AnswerType)value;

            switch (flag)
            {
                case AnswerType.Yes:
                    return "circle_checkbox_yes";
                case AnswerType.No:
                    return "circle_checkbox_no";
                case AnswerType.InApplicable:
                    return "circle_checkbox_inapplicable";
                default:
                    return "circle_checkbox";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.ComponentModel;
using System.Globalization;

namespace MedExpertClientClone.Models
{
    /// <summary>
    /// Модель записи новой операции аудита
    /// </summary>
    public class NewAudit : INotifyPropertyChanged
    {
        public NewAudit()
        {
        }

        private DateTime periodDateIn;
        private DateTime periodDateOut;

        /// <summary>Начало периода операции аудита</summary>
        public DateTime PeriodDateIn
        {
            get { return periodDateIn; }
            set
            {
                periodDateIn = value;
                OnChanged(nameof(PeriodDateIn));
            }
        }

        /// <summary>Окончание периода операции аудита</summary>
        public DateTime PeriodDateOut
        {
            get { return periodDateOut; }
            set
            {
                periodDateOut = value;
                OnChanged(nameof(PeriodDateOut));
            }
        }

        /// <summary>Язык и региональне парамметрв</summary>
        private CultureInfo Culture { get; set; } = new CultureInfo("ru", false);

        /// <summary>
        /// Текстовое представление начала периода операции аудита
        /// </summary>
        public string PeriodDateInText
        {
            get { return $"{PeriodDateIn:dd.MM.yyyy} г."; }
        }

        /// <summary>
        /// Текстовое представление окончания периода операции аудита
        /// </summary>
        public string PeriodDateOutText
        {
            get { return $"{PeriodDateOut:dd.MM.yyyy} г."; }
        }

        protected void OnChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

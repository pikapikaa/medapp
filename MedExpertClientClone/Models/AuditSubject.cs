using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MedExpertClientClone.Models
{
    /// <summary>
    /// Модель предмета проверки
    /// </summary>
    public class AuditSubject : INotifyPropertyChanged
    {
        public string Name { get; set; }
        private bool isChecked;

        public bool IsChecked
        {
            get
            {
                return isChecked;
            }
            set
            {
                if (value != this.isChecked)
                {
                    this.isChecked = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MedExpertClientClone.Models
{
    public class CheckList : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public string Name { get; set; }
        private Employee auditor;

        /// <summary>
        /// Аудитор
        /// </summary>
        public Employee Auditor
        {
            get { return auditor; }
            set
            {
                if (value != auditor)
                {
                    auditor = value;
                    NotifyPropertyChanged();
                }
            }
        }

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
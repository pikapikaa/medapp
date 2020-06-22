using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MedExpertClientClone.Models
{
    public class Employee : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string FullName { get; set; }
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

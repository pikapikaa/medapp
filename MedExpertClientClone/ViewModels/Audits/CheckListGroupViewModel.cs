using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MedExpertClientClone.ViewModels.Audits
{
    public class CheckListGroupViewModel : INotifyPropertyChanged
    {
        private string name = "";

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public CheckListGroupViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MedExpertClientClone.Models;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MedExpertClientClone.ViewModels
{
    public class AuditorListPopupViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Employee> auditors =
           new ObservableCollection<Employee>();

        public AuditorListPopupViewModel()
        {
            var mockData = new DataFactory().GetEmployees();
            Auditors = new ObservableCollection<Employee>(mockData);
        }

        public ObservableCollection<Employee> Auditors
        {
            get { return auditors; }
            set
            {
                auditors = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда для закрытия текущего окна
        /// </summary>
        public ICommand CloseAuditorListPopupViewCommand => new Command(async() =>
        {
            await PopupNavigation.Instance.PopAsync();
        });

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
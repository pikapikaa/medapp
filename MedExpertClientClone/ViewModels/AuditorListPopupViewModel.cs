using System;
using System.Collections.Generic;
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
        private double listAuditorsHeight = 0;

        public AuditorListPopupViewModel()
        {
            var mockData = new DataAuditorsFactory().GetAuditors();
            Auditors = new ObservableCollection<Employee>(mockData);
            ListAuditorsHeight = 55 * Auditors.Count;
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
        /// Высота ListView списка аудиторов
        /// </summary>
        public double ListAuditorsHeight
        {
            get { return listAuditorsHeight; }
            set
            {
                listAuditorsHeight = value;
                OnPropertyChanged(nameof(ListAuditorsHeight));
            }
        }


        /// <summary>
        /// Команда для закрытия текущего окна
        /// </summary>
        public ICommand CloseAuditorListPopupViewCommand => new Command(async () =>
        {
            await PopupNavigation.Instance.PopAsync();
        });

        /// <summary>
        /// Команда переключения флажка выбора аудитора
        /// </summary>
        public ICommand ClickCheckBoxCommand => new Command((sender) =>
        {
            foreach (var i in Auditors)
            {
                if (i.Equals(sender as Employee))
                {
                    i.IsChecked = true;
                }
                else
                {
                    i.IsChecked = false;
                }
            }
        });

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    internal class DataAuditorsFactory
    {
        public List<Employee> GetAuditors()
        {
            return new List<Employee>()
            {
                new Employee(){Id=10, FullName = "Раднаев Нима Петрович"},
                new Employee(){Id=11,FullName = "Будаева Елена Дмитриевна"},
                new Employee(){Id=12, FullName = "Потапова Александра Петровна"},
                new Employee(){Id=13,FullName = "Миронов Вячеслав Леонидович"},
                new Employee(){Id=14, FullName = "Доронин Роман Павлович"}
            };
        }
    }
}
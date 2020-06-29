using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MedExpertClientClone.Models;
using MedExpertClientClone.ViewModels.Base;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MedExpertClientClone.ViewModels
{
    public class AuditTypeListViewModel : INotifyPropertyChanged
    {
        private double auditTypeListHeight = 0;
        public ObservableCollection<AuditType> AuditTypes { get; private set; }

        public INavigation Navigation { get; set; }

        public AuditTypeListViewModel()
        {
            AuditTypes = new ObservableCollection<AuditType>()
            {
                new AuditType(){Name = "Плановая"},
                new AuditType(){ Name = "Внеплановая"}
            };
            AuditTypeListHeight = 35 * AuditTypes.Count;
        }

        public double AuditTypeListHeight
        {
            get { return auditTypeListHeight; }
            set
            {
                auditTypeListHeight = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда закрытия окна
        /// </summary>
        public ICommand ClosePopupCommand => new Command(async () =>
        {
            await PopupNavigation.Instance.PopAsync();
        });

        /// <summary>
        /// Команда выбора типа проверки
        /// </summary>
        public ICommand SelectAuditTypeCommand => new Command(async (obj) =>
        {
            if (obj is AuditType _auditType)
            {
                MessagingCenter.Send(_auditType, MessageKeys.AddAuditType);
                await PopupNavigation.Instance.PopAsync();
            }
        });

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

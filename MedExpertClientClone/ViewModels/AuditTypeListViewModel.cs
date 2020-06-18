using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using MedExpertClientClone.Models;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MedExpertClientClone.ViewModels
{
    public class AuditTypeListViewModel
    {
        public ObservableCollection<AuditType> AuditTypes { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public INavigation Navigation { get; set; }
        public AuditTypeListViewModel()
        {
            AuditTypes = new ObservableCollection<AuditType>()
            {
                new AuditType(){Name = "Плановая"},
                new AuditType(){ Name = "Внеплановая"}
            };
        }

        /// <summary>
        /// Команда 
        /// </summary>
        public ICommand ClosePopupCommand => new Command(async () =>
        {
            await PopupNavigation.Instance.PopAsync();
        });
    }
}

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MedExpertClientClone.Views.Popups;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MedExpertClientClone.ViewModels.Audits
{
    public class AuditTabbedViewModel : INotifyPropertyChanged
    {
        public AuditTabbedViewModel()
        {
        }

        public ICommand SelectToolbar => new Command(async () =>
        {
            await PopupNavigation.Instance.PushAsync(new MenuAuditListPopupView(), false);
        });

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

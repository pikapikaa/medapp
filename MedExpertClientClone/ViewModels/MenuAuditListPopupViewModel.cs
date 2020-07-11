using System;
using System.Windows.Input;
using MedExpertClientClone.Views.Popups;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MedExpertClientClone.ViewModels
{
    public class MenuAuditListPopupViewModel
    {
        public MenuAuditListPopupViewModel()
        {
        }

        public ICommand OpenSortPopupCommand => new Command(async () =>
        {
            await PopupNavigation.Instance.PopAsync();
            await PopupNavigation.Instance.PushAsync(new SortAuditsPopupView());
        });
    }
}

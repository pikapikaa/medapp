using System;
using System.Windows.Input;
using MedExpertClientClone.Views;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MedExpertClientClone.ViewModels
{
    public class MenuPopupViewModel
    {
        public MenuPopupViewModel()
        {
        }
        /// <summary>
        /// Команда для выбора конца периода проверки
        /// </summary>
        public ICommand OpenSortPopupCommand => new Command(async () =>
        {
            await PopupNavigation.Instance.PopAsync();
            await PopupNavigation.Instance.PushAsync(new SortPopupView());
        });
    }
}

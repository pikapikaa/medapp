using System;
using System.Windows.Input;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MedExpertClientClone.ViewModels
{
    public class EmployeeListViewModel
    {
        public INavigation Navigation { get; set; }

        public EmployeeListViewModel()
        {
        }

        /// <summary>
        /// Команда закрытия страницы
        /// </summary>
        public ICommand ClosePageCommand => new Command(async () =>
        {
            await Navigation.PopModalAsync();
        });
    }
}

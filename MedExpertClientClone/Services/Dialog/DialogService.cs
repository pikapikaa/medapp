using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace MedExpertClientClone.Services.Dialog
{
    public class DialogService : IDialogService
    {
        /// <contentfrom cref="IDialogService.DisplayActionSheet"/>
        public Task DisplayActionSheet(string title, string cancel, string destruction, string[]buttons)
        {
            return Application.Current.MainPage.DisplayActionSheet(title, cancel, destruction, buttons);
        }
    }
}

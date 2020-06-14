using System;
using System.ComponentModel;
using System.Windows.Input;
using MedExpertClientClone.Views;
using Xamarin.Forms;

namespace MedExpertClientClone.ViewModels
{
    public class AuditOperationGroupsViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand OpenAddAuditPageCommand { protected set; get; }
        public INavigation Navigation { get; set; }
        public AuditOperationGroupsViewModel()
        {
            OpenAddAuditPageCommand = new Command(OpenAddAuditPage);
        }

        private void OpenAddAuditPage()
        {
            Navigation.PushAsync(new NewAuditView());
        }
    }
}

using System;
using System.ComponentModel;
using System.Windows.Input;
using MedExpertClientClone.Views;
using MedExpertClientClone.Views.Audits;
using Xamarin.Forms;

namespace MedExpertClientClone.ViewModels
{
    public class AuditOperationGroupsViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand OpenAddAuditPageCommand { protected set; get; }
        public ICommand OpenAllAuditsPageCommand { protected set; get; }

        public INavigation Navigation { get; set; }
        public AuditOperationGroupsViewModel()
        {
            OpenAddAuditPageCommand = new Command(OpenAddAuditPage);
            OpenAllAuditsPageCommand = new Command(OpenAllAuditsPage);
        }

        private void OpenAllAuditsPage(object obj)
        {
            Navigation.PushAsync(new AuditTabbedView());
        }

        private void OpenAddAuditPage()
        {
            Navigation.PushAsync(new NewAuditView());
        }
    }
}

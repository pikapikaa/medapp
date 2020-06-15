using System;
using System.ComponentModel;
using System.Windows.Input;
using MedExpertClientClone.Views;
using Xamarin.Forms;

namespace MedExpertClientClone.ViewModels
{
    public class NewAuditViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand OpenAddSubjectAuditCommand { protected set; get; }
        public ICommand OpenAuditBaseListViewCommand { protected set; get; }
        public ICommand OpenAuditTypeViewCommand { protected set; get; }

        public INavigation Navigation { get; set; }
        public NewAuditViewModel()
        {
            OpenAddSubjectAuditCommand = new Command(OpenAddSubjectAudit);
            OpenAuditBaseListViewCommand = new Command(OpenAuditBaseListView);
            OpenAuditTypeViewCommand = new Command(OpenAuditTypeView);
        }

        private void OpenAuditTypeView(object obj)
        {
            Navigation.PushModalAsync(new NavigationPage(new AuditTypeListView()), true);
        }

        private void OpenAuditBaseListView(object obj)
        {
            Navigation.PushModalAsync(new NavigationPage(new AuditBaseListView()), true);
        }

        private void OpenAddSubjectAudit(object obj)
        {
            Navigation.PushModalAsync(new NavigationPage(new AuditSubjectListView()), true);
        }
    }
}

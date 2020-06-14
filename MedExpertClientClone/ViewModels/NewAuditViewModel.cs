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
        public INavigation Navigation { get; set; }
        public NewAuditViewModel()
        {
            OpenAddSubjectAuditCommand = new Command(OpenAddSubjectAudit);
        }

        private void OpenAddSubjectAudit(object obj)
        {
            Navigation.PushModalAsync(new NavigationPage(new AuditSubjectListView()), true);
        }
    }
}

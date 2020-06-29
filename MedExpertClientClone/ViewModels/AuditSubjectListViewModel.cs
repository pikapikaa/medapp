using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Linq;
using MedExpertClientClone.Models;
using MedExpertClientClone.Views;
using Xamarin.Forms;
using MedExpertClientClone.ViewModels.Base;

namespace MedExpertClientClone.ViewModels
{
    public class AuditSubjectListViewModel
    {
        private ObservableCollection<AuditSubject> auditSubjects =
            new ObservableCollection<AuditSubject>();

        public ObservableCollection<AuditSubject> AuditSubjects
        {
            get { return auditSubjects; }
            set
            {
                auditSubjects = value;
                OnPropertyChanged(nameof(AuditSubjects));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SaveAuditSubjectCommand { protected set; get; }
        public ICommand ClickCheckBoxCommand { protected set; get; }

        public INavigation Navigation { get; set; }

        public AuditSubjectListViewModel()
        {
            AuditSubjects = new ObservableCollection<AuditSubject>()
            {
                new AuditSubject(){Name = "Соблюдение условий хранения ЛС и МИ", IsChecked = false},
                new AuditSubject(){ Name = "Соблюдения обращения МИ", IsChecked = false},
                new AuditSubject(){Name = "Соблюдение условий хранения ЛС и МИ2Соблюдение условий хранения ЛС и МИ", IsChecked = false},
                new AuditSubject(){ Name = "Соблюдения обращения МИ2", IsChecked = false},
            };
            ClickCheckBoxCommand = new Command(ClickCheckBox);
        }

        private void ClickCheckBox(object sender)
        {
            foreach (var i in AuditSubjects)
            {
                if (i.Equals(sender as AuditSubject))
                {
                    i.IsChecked = true;
                }
                else
                {
                    i.IsChecked = false;
                }
            }
        }

        public ICommand AddAuditSubjectCommand => new Command(async () =>
        {
            var selectedAuditSubject = AuditSubjects.FirstOrDefault(i => i.IsChecked);

            if (selectedAuditSubject != null)
            {
                MessagingCenter.Send(selectedAuditSubject, MessageKeys.AddAuditSubject);
                await Navigation.PopModalAsync();
            }
        });

        public ICommand ClosePageCommand => new Command(async () =>
        {
            await Navigation.PopModalAsync();
        });

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}

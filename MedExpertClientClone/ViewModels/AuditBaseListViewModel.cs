using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using MedExpertClientClone.Models;
using MedExpertClientClone.ViewModels.Base;
using Xamarin.Forms;

namespace MedExpertClientClone.ViewModels
{
    public class AuditBaseListViewModel
    {
        private ObservableCollection<AuditBase> auditBases = new ObservableCollection<AuditBase>();
        public ObservableCollection<AuditBase> AuditBases
        {
            get { return auditBases; }
            set
            {
                auditBases = value;
                OnPropertyChanged(nameof(AuditBases));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand ClickCheckBoxCommand { protected set; get; }

        public INavigation Navigation { get; set; }

        public AuditBaseListViewModel()
        {
            AuditBases = new ObservableCollection<AuditBase>()
            {
                new AuditBase(){Name = "Соблюдение условий хранения ЛС и МИ", IsChecked = false},
                new AuditBase(){ Name = "Соблюдения обращения МИ", IsChecked = false},
                new AuditBase(){Name = "Соблюдение условий хранения ЛС и МИ2Соблюдение условий хранения ЛС и МИ", IsChecked = false},
                new AuditBase(){ Name = "Соблюдения обращения МИ2", IsChecked = false},
            };
            ClickCheckBoxCommand = new Command(ClickCheckBox);
        }

        private void ClickCheckBox(object sender)
        {
            foreach (var i in AuditBases)
            {
                if (i.Equals(sender as AuditBase))
                {
                    i.IsChecked = true;
                }
                else
                {
                    i.IsChecked = false;
                }
            }
        }

        public ICommand ClosePageCommand => new Command(async () =>
        {
            await Navigation.PopModalAsync();
        });

        public ICommand AddAuditBaseCommand => new Command(async () =>
        {
            var selectedAuditBase = AuditBases.FirstOrDefault(i => i.IsChecked);

            if (selectedAuditBase != null)
            {
                MessagingCenter.Send(selectedAuditBase, MessageKeys.AddAuditBase);
                await Navigation.PopModalAsync();
            }
        });

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}

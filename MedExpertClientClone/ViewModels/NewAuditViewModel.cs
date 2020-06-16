using System;
using System.ComponentModel;
using System.Windows.Input;
using MedExpertClientClone.ViewModels.Base;
using MedExpertClientClone.Views;
using Xamarin.Forms;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;
using MedExpertClientClone.Models;
using System.Runtime.CompilerServices;

namespace MedExpertClientClone.ViewModels
{
    public class NewAuditViewModel : INotifyPropertyChanged
    {
        private bool isChangedStartDate = false;

        private NewAudit Audit { get; set; }

        public DateTime PeriodDateIn
        {
            get { return Audit.PeriodDateIn; }
            set
            {
                if (Audit.PeriodDateIn != value)
                {
                    Audit.PeriodDateIn = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(PeriodDateInText));
                }
            }
        }

        public DateTime PeriodDateOut
        {
            get { return Audit.PeriodDateOut; }
            set
            {
                if (Audit.PeriodDateOut != value)
                {
                    Audit.PeriodDateOut = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(PeriodDateOutText));
                }
            }
        }

        public bool IsChangedStartDate
        {
            get { return isChangedStartDate; }
            set
            {
                if (isChangedStartDate != value)
                {
                    isChangedStartDate = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(PeriodDateInText));
                }
            }
        }

        public string PeriodDateInText
        {
            get
            {
                if (IsChangedStartDate)
                {
                    return $"{PeriodDateIn:dd.MM.yyyy}";
                }
                return "Начало";
            }
        }

        public string PeriodDateOutText
        {
            get { return $"{PeriodDateOut:dd.MM.yyyy}"; }
        }

        public INavigation Navigation { get; set; }

        public NewAuditViewModel()
        {

            Audit = new NewAudit();
            MessagingCenter.Subscribe<CalendarPopupViewModel>(this,
                   MessageKeys.StartDateAudit, sender =>
                   {
                       PeriodDateIn = sender.SelectedDate;
                       IsChangedStartDate = true;
                   });
        }

        /// <summary>
        /// Команда для открытия списка предметов проверок
        /// </summary>
        public ICommand OpenAddSubjectAuditCommand => new Command(() =>
            {
                Navigation.PushModalAsync(new NavigationPage(new AuditSubjectListView()), true);
            });

        /// <summary>
        /// Команда для открытия списка оснований проверок
        /// </summary>
        public ICommand OpenAuditBaseListViewCommand => new Command(() =>
        {
            Navigation.PushModalAsync(new NavigationPage(new AuditBaseListView()), true);
        });

        /// <summary>
        /// Команда для открытия видов проверок
        /// </summary>
        public ICommand OpenAuditTypeViewCommand => new Command(async () =>
            {
                await PopupNavigation.Instance.PushAsync(new AuditTypePopupView());
            });

        /// <summary>
        /// Команда для выбора периода
        /// </summary>
        public ICommand OpenCalendarPopupCommand => new Command(async () =>
        {
            await PopupNavigation.Instance.PushAsync(new CalendarPopupView());
        });

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

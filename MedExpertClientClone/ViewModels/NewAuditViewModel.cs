using System;
using System.ComponentModel;
using System.Windows.Input;
using MedExpertClientClone.ViewModels.Base;
using MedExpertClientClone.Views;
using Xamarin.Forms;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;
using MedExpertClientClone.Models;

namespace MedExpertClientClone.ViewModels
{
    public class NewAuditViewModel : ViewModelBase
    {
        public NewAudit Audit { get; private set; }

        private bool _isChangedStartDate = false;

        public DateTime StartDate
        {
            get { return Audit.PeriodDateIn; }
            set
            {
                if (Audit.PeriodDateIn != value)
                {
                    Audit.PeriodDateIn = value;
                    OnPropertyChanged(nameof(StartDate));
                }
            }
        }

        public DateTime EndDate
        {
            get { return Audit.PeriodDateOut; }
            set
            {
                if (Audit.PeriodDateOut != value)
                {
                    Audit.PeriodDateOut = value;
                    OnPropertyChanged(nameof(EndDate));
                }
            }
        }

        public string PeriodDateInText
        {
            get { return Audit.PeriodDateInText; }
        }

        public string PeriodDateOutText
        {
            get { return Audit.PeriodDateOutText; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsChangedStartDate
        {
            get { return _isChangedStartDate; }
            set
            {
                _isChangedStartDate = value;
                OnPropertyChanged(nameof(IsChangedStartDate));
            }
        }

        public INavigation Navigation { get; set; }

        public NewAuditViewModel()
        {
            Audit = new NewAudit();
            MessagingCenter.Subscribe<CalendarPopupViewModel>(this,
                   MessageKeys.StartDateAudit, sender =>
                   {
                       StartDate = sender.SelectedDate;
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
        public ICommand OpenAuditTypeViewCommand => new Command(
            async () =>
            {
                string[] arr = { "Плановая", "Внеплановая" };
                await DialogService.DisplayActionSheet("Вид проверки", "Отмена", null, arr);
            });

        /// <summary>
        /// Команда для выбора периода
        /// </summary>
        public ICommand OpenCalendarPopupCommand => new Command(async () =>
        {
            await PopupNavigation.Instance.PushAsync(new CalendarPopupView());
        });
    }
}

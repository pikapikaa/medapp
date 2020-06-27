using System;
using System.Globalization;
using System.Windows.Input;
using MedExpertClientClone.ViewModels.Base;
using Xamarin.Forms;
using Rg.Plugins.Popup.Services;
using MedExpertClientClone.Models;

namespace MedExpertClientClone.ViewModels
{
    public class CalendarPopupViewModel : ViewModelBase
    {
        private DateTime _selectedDate = DateTime.Today;
        private CultureInfo _culture = new CultureInfo("ru", false);
        private CalendarType calendarType;
        private NewAuditViewModel newAuditViewModel;

        public CalendarPopupViewModel()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public NewAuditViewModel NewAuditViewModel
        {
            get { return newAuditViewModel; }
            set
            {
                newAuditViewModel = value;
                SetProperty(ref newAuditViewModel, value);
            }
        }

        /// <summary>
        /// Выбранная дата
        /// </summary>
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                SetProperty(ref _selectedDate, value);
            }
        }

        /// <summary>
        /// Язык
        /// </summary>
        public CultureInfo Culture
        {
            get { return _culture; }
            set
            {
                _culture = value;
                SetProperty(ref _culture, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public CalendarType CalendarType
        {
            get { return calendarType; }
            set
            {
                calendarType = value;
                SetProperty(ref calendarType, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand SelectStartDateCommand => new Command(async () =>
        {
            var r = NewAuditViewModel;
            if ((CalendarType == CalendarType.StartDate && SelectedDate < NewAuditViewModel.PeriodDateOut) ||
            (CalendarType == CalendarType.StartDate && NewAuditViewModel.IsChangedEndDate == false))
            {
                MessagingCenter.Send(this, MessageKeys.StartDateAudit);
                await PopupNavigation.Instance.PopAsync();
            }
            else if ((CalendarType == CalendarType.EndDate && SelectedDate > NewAuditViewModel.PeriodDateIn) ||
            (CalendarType == CalendarType.EndDate && NewAuditViewModel.IsChangedStartDate == false))
            {
                MessagingCenter.Send(this, MessageKeys.EndDateAudit);
                await PopupNavigation.Instance.PopAsync();
            }
           
        });

    }
}

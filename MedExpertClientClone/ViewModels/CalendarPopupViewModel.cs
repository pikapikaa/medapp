using System;
using System.Globalization;
using System.Windows.Input;
using MedExpertClientClone.ViewModels.Base;
using Xamarin.Forms;
using Rg.Plugins.Popup.Services;

namespace MedExpertClientClone.ViewModels
{
    public class CalendarPopupViewModel : ViewModelBase
    {
        private DateTime _selectedDate = DateTime.Today;
        private CultureInfo _culture = new CultureInfo("ru", false);

        public CalendarPopupViewModel()
        {
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
                //OnPropertyChanged(nameof(SelectedDate));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public CultureInfo Culture
        {
            get { return _culture; }
            set
            {
                _culture = value;
                SetProperty(ref _culture, value);
                //OnPropertyChanged(nameof(Culture));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand SelectStartDateCommand => new Command(async () =>
        {
            MessagingCenter.Send(this, MessageKeys.StartDateAudit);
            await PopupNavigation.Instance.PopAsync();
        });

    }
}

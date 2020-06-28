using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MedExpertClientClone.Views;
using MedExpertClientClone.Views.Popups;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MedExpertClientClone.ViewModels
{
    public class MenuCheckListPopupViewModel : INotifyPropertyChanged
    {
        public MenuCheckListPopupViewModel()
        {
        }

        private QualityRatingIndicatorViewModel qualityRatingIndicatorViewModel;

        public QualityRatingIndicatorViewModel QualityRatingIndicatorViewModel
        {
            get { return qualityRatingIndicatorViewModel; }
            set
            {
                qualityRatingIndicatorViewModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand DeleteSelectedCheckListCommand => new Command(() =>
        {

        });

        public ICommand SelectAuditorCommand => new Command(async() =>
        {
            await PopupNavigation.Instance.PopAsync();
            await PopupNavigation.Instance.PushAsync(new AuditorListPopupView(), true);
        });

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

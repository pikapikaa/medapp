using System;
using System.ComponentModel;
using System.Windows.Input;
using MedExpertClientClone.Views;
using Xamarin.Forms;

namespace MedExpertClientClone.ViewModels
{
    public class QualityRatingIndicatorViewModel : INotifyPropertyChanged
    {
        public QualityRatingIndicatorViewModel()
        {
        }

        public INavigation Navigation { get; set; }

        /// <summary>
        /// Команда для открытия списка чек-листов
        /// </summary>
        public ICommand OpenCheckListViewCommand => new Command(() =>
        {
            Navigation.PushModalAsync(new NavigationPage(new CheckListView()), true);
        });

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

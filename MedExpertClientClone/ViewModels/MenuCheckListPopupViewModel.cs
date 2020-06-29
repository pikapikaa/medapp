using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MedExpertClientClone.Models;
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
        private CheckList _selectedCheckList;

        public QualityRatingIndicatorViewModel QualityRatingIndicatorViewModel
        {
            get { return qualityRatingIndicatorViewModel; }
            set
            {
                qualityRatingIndicatorViewModel = value;
                OnPropertyChanged();
            }
        }

        // Выбранный чек-лист
        public CheckList SelectedCheckList
        {
            get { return _selectedCheckList; }
            set
            {
                _selectedCheckList = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда для удаления выбранного чек-листа
        /// </summary>
        public ICommand DeleteSelectedCheckListCommand => new Command(async () =>
        {
            var _checkListsFiltered = new ObservableCollection<CheckList>(
                                              QualityRatingIndicatorViewModel.SelectedCheckLists
                                              .Where(i => (i is CheckList && i.Id != SelectedCheckList.Id))
                                              );

            QualityRatingIndicatorViewModel.SelectedCheckLists = _checkListsFiltered;
            QualityRatingIndicatorViewModel.ListViewSelectedCheckListsHeight = (49 * QualityRatingIndicatorViewModel.SelectedCheckLists.Count);

            if (QualityRatingIndicatorViewModel.SelectedCheckLists.Count == 0)
            {
                QualityRatingIndicatorViewModel.IsListCheckListsVisible = false;
            }
            await PopupNavigation.Instance.PopAsync();
        });

        /// <summary>
        /// Команда для открытия списка аудиторов
        /// </summary>
        public ICommand SelectAuditorCommand => new Command(async () =>
        {
            await PopupNavigation.Instance.PopAsync();

            var auditorListViewModel = new AuditorListPopupViewModel()
            {
                QualityRatingIndicatorViewModel = this.QualityRatingIndicatorViewModel,
                SelectedCheckList = this.SelectedCheckList
            };

            var page = new AuditorListPopupView();
            page.BindingContext = auditorListViewModel;

            await PopupNavigation.Instance.PushAsync(page, true);
        });

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

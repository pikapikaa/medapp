using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MedExpertClientClone.Models;
using MedExpertClientClone.ViewModels.Base;
using MedExpertClientClone.Views;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using Rg.Plugins.Popup.Services;
using MedExpertClientClone.Views.Popups;

namespace MedExpertClientClone.ViewModels
{
    public class QualityRatingIndicatorViewModel : INotifyPropertyChanged
    {
        private bool IsExistInCurrentList(CheckList o)
        {
            var flag = SelectedCheckLists.Any(e => e.Id == o.Id);
            return flag;
        }

        public INavigation Navigation { get; set; }

        private bool isListCheckListsVisible = false;
        private double listViewSelectedCheckListsHeight = 0;

        private ObservableCollection<CheckList> selectedCheckLists =
           new ObservableCollection<CheckList>();

        private AuditPlace auditLocation;

        public AuditPlace AuditLocation
        {
            get { return auditLocation; }
            set
            {
                auditLocation = value;
                OnPropertyChanged();
            }
        }

        public string AuditLocationText
        {
            get
            {
                if (AuditLocation?.Name != null)
                {
                    return $"{AuditLocation.Name}";
                }
                return "Выбрать";
            }
        }

        public ObservableCollection<CheckList> SelectedCheckLists
        {
            get { return selectedCheckLists; }
            set
            {
                selectedCheckLists = value;
                OnPropertyChanged();
            }
        }

        public bool IsListCheckListsVisible
        {
            get { return isListCheckListsVisible; }
            set
            {
                isListCheckListsVisible = value;
                OnPropertyChanged();
            }
        }

        public double ListViewSelectedCheckListsHeight
        {
            get { return listViewSelectedCheckListsHeight; }
            set
            {
                listViewSelectedCheckListsHeight = value;
                OnPropertyChanged(nameof(ListViewSelectedCheckListsHeight));
            }
        }

        /// <summary>
        /// Команда для открытия списка чек-листов
        /// </summary>
        public ICommand OpenCheckListViewCommand => new Command(() =>
        {
            //Navigation.PushModalAsync(new NavigationPage(new CheckListView()), true);
        });

        /// <summary>
        /// Команда для открытия контекстного меню для отдельного чек-листа
        /// </summary>
        public ICommand OpenContextMenuCheckListCommand => new Command(async (e) =>
        {
            if (e is CheckList employee)
            {
                var checkListViewModel = new MenuCheckListPopupViewModel()
                {
                    QualityRatingIndicatorViewModel = this,
                    SelectedCheckList = employee
                };

                var page = new MenuCheckListPopupView();
                page.BindingContext = checkListViewModel;

                await PopupNavigation.Instance.PushAsync(page, false);
            }
        });

        /// <summary>
        /// 
        /// </summary>
        public ICommand OpenAuditPlaceListViewCommand => new Command(() =>
        {
            Navigation.PushModalAsync(new NavigationPage(new AuditPlaceListView()), true);
        });

        public QualityRatingIndicatorViewModel()
        {
            MessagingCenter.Subscribe<CheckListViewModel>(this,
                 MessageKeys.AddCheckLists, sender =>
                 {

                     var t = new ObservableCollection<CheckList>(sender.CheckLists
                                         .Where(i => (i is CheckList && (((CheckList)i)
                                         .IsChecked) && !IsExistInCurrentList(i))));
                     if (t.Count != 0)
                     {
                         foreach (var item in t)
                             SelectedCheckLists.Add(item);
                     }

                     ListViewSelectedCheckListsHeight = (49 * SelectedCheckLists.Count);

                     if (SelectedCheckLists.Count != 0)
                     {
                         IsListCheckListsVisible = true;
                     }
                 });
            SelectedCheckLists = new ObservableCollection<CheckList>();
            ListViewSelectedCheckListsHeight = 0;
        }

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

﻿using System;
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
            Navigation.PushModalAsync(new NavigationPage(new CheckListView()), true);
        });

        /// <summary>
        /// Команда для 
        /// </summary>
        public ICommand DeleteSelectedCheckListCommand => new Command((e) =>
        {
            if (e is CheckList employee)
            {
                var _employeesFiltered = new ObservableCollection<CheckList>(SelectedCheckLists
                                              .Where(i => (i is CheckList && i
                                              .Id != employee.Id)));
                SelectedCheckLists = _employeesFiltered;
                ListViewSelectedCheckListsHeight = (49 * SelectedCheckLists.Count);
                if (SelectedCheckLists.Count == 0)
                {
                    IsListCheckListsVisible = false;
                }
                OnPropertyChanged(nameof(SelectedCheckLists));
                OnPropertyChanged(nameof(IsListCheckListsVisible));
            }
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

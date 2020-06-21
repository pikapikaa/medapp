﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MedExpertClientClone.Models;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using System.Linq;
using MedExpertClientClone.Views;
using MedExpertClientClone.Views.Popups;
using System.Collections.Generic;
using MedExpertClientClone.ViewModels.Base;

namespace MedExpertClientClone.ViewModels
{
    public class EmployeeListViewModel : INotifyPropertyChanged
    {
        private bool isEntryVisible = false;
        private string searchText = "";

        public INavigation Navigation { get; set; }

        private ObservableCollection<Employee> employees =
           new ObservableCollection<Employee>();

        private ObservableCollection<Employee> _employeesFiltered;
        private ObservableCollection<Employee> _employeesUnfiltered;

        public ObservableCollection<Employee> Employees
        {
            get { return employees; }
            set
            {
                employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }

        public bool IsEntryVisible
        {
            get { return isEntryVisible; }
            set
            {
                isEntryVisible = value;
                OnPropertyChanged(nameof(IsEntryVisible));
            }
        }

        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnPropertyChanged(nameof(SearchText));
                OnPropertyChanged(nameof(Employees));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public EmployeeListViewModel()
        {
            var _listOfItems = new DataFactory().GetEmployees();
            Employees = new ObservableCollection<Employee>(_listOfItems);
            _employeesUnfiltered = new ObservableCollection<Employee>(_listOfItems);

            MessagingCenter.Subscribe<SortPopupViewModel>(this,
                 MessageKeys.AscendingSort, sender =>
                 {
                     _employeesFiltered = new ObservableCollection<Employee>(_employeesUnfiltered
                                           .OrderBy(t => t.FullName));
                     Employees = _employeesFiltered;
                 });

            MessagingCenter.Subscribe<SortPopupViewModel>(this,
               MessageKeys.DescendingSort, sender =>
               {
                   _employeesFiltered = new ObservableCollection<Employee>(_employeesUnfiltered
                                         .OrderByDescending(t => t.FullName));
                   Employees = _employeesFiltered;
               });

            MessagingCenter.Subscribe<SortPopupViewModel>(this,
               MessageKeys.DefaultSort, sender =>
               {
                   Employees = _employeesUnfiltered;
               });

            MessagingCenter.Subscribe<SortPopupViewModel>(this,
             MessageKeys.DateSort, sender =>
             {
                 Employees = _employeesUnfiltered;
             });
        }

        /// <summary>
        /// Команда закрытия страницы
        /// </summary>
        public ICommand ClosePageCommand => new Command(async () =>
        {
            await Navigation.PopModalAsync();
        });

        /// <summary>
        /// Команда выбора пользователя из списка
        /// </summary>
        public ICommand ClickCheckBoxCommand => new Command((emp) =>
        {
            if (emp is Employee employee)
            {
                var item = Employees.FirstOrDefault(i => i.FullName == employee.FullName);
                if (item != null)
                {
                    item.IsChecked = !item.IsChecked;
                }
            }
            OnPropertyChanged(nameof(Employees));
        });

        /// <summary>
        /// Команда открытия окна сортировки
        /// </summary>
        public ICommand OpenSortPopupCommand => new Command(async () =>
        {
            await PopupNavigation.Instance.PushAsync(new SortPopupView(), false);
        });

        /// <summary>
        /// Команда открытия окна меню
        /// </summary>
        public ICommand OpenMenuPopupCommand => new Command(async () =>
        {
            await PopupNavigation.Instance.PushAsync(new MenuPopupView(), false);
        });

        /// <summary>
        /// Команда показа строки поиска сотрудника
        /// </summary>
        public ICommand ShowSearchEntryCommand => new Command(() =>
        {
            IsEntryVisible = !IsEntryVisible;
        });

        /// <summary>
        /// Команда поиска пользователя
        /// </summary>
        public ICommand SearchTextChangedCommand => new Command(() =>
        {
            if (string.IsNullOrWhiteSpace(SearchText))
                Employees = _employeesUnfiltered;
            else
            {
                _employeesFiltered = new ObservableCollection<Employee>(_employeesUnfiltered
                                            .Where(i => (i is Employee && (((Employee)i)
                                            .FullName.ToLower()
                                            .Contains(SearchText.ToLower())))));
                Employees = _employeesFiltered;
            }
        });

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    internal class DataFactory
    {
        public List<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee(){FullName = "Будаев Батожаб Надмит-Цыренович"},
                new Employee(){ FullName = "Раднаев Жамбал Олегович"},
                new Employee(){FullName = "Будаев Будажаб Раднаевич"},
                new Employee(){ FullName = "Потапов Александр Григорьевич"},
                new Employee(){FullName = "Миронов Вячеслав Владимирович"},
                new Employee(){ FullName = "Воронин Роман Владимирович"},
                new Employee(){FullName = "Аранзаев Михаил Аранзаевич"},
                new Employee(){ FullName = "Деревянко Александр Леонидович"},
                 new Employee(){FullName = "Баева Полина Раднаевна"},
                new Employee(){ FullName = "Раднаев Нима Петрович"},
                new Employee(){FullName = "Будаева Елена Дмитриевна"},
                new Employee(){ FullName = "Потапова Александра Петровна"},
                new Employee(){FullName = "Миронов Вячеслав Леонидович"},
                new Employee(){ FullName = "Доронин Роман Павлович"},
          
            };
        }
    }
}

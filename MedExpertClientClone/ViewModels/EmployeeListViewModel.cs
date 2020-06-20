using System;
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
        public ICommand ClickCheckBoxCommand => new Command(async (emp) =>
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
        /// Команда
        /// </summary>
        public ICommand ShowSearchEntryCommand => new Command(() =>
        {
            IsEntryVisible = !IsEntryVisible;
        });

        /// <summary>
        /// Команда
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
                new Employee(){FullName = "Батожаб Будаев"},
                new Employee(){ FullName = "Раднаев Жамбал"},
                new Employee(){FullName = "Будаев Будажаб"},
                new Employee(){ FullName = "Потапов Александр"},
                new Employee(){FullName = "Миронов Вячеслав"},
                new Employee(){ FullName = "Воронин Роман"},
                new Employee(){FullName = "Аранзаев Михаил"},
                new Employee(){ FullName = "Деревянко Александр"}
            };
        }
    }
}

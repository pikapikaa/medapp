using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MedExpertClientClone.Models;
using MedExpertClientClone.ViewModels.Base;
using MedExpertClientClone.Views.Popups;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MedExpertClientClone.ViewModels
{
    public class ChairmanListViewModel : INotifyPropertyChanged
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

        public ChairmanListViewModel()
        {
            var _listOfItems = new DataFactory().GetEmployees();
            Employees = new ObservableCollection<Employee>(_listOfItems);
            _employeesUnfiltered = new ObservableCollection<Employee>(_listOfItems);

            MessagingCenter.Subscribe<SortPopupViewModel>(this,
                 MessageKeys.AscendingSort, sender =>
                 {
                     var temp = new ObservableCollection<Employee>(Employees
                                           .OrderBy(t => t.FullName));
                     Employees = temp;
                 });

            MessagingCenter.Subscribe<SortPopupViewModel>(this,
               MessageKeys.DescendingSort, sender =>
               {
                   var temp = new ObservableCollection<Employee>(Employees
                                         .OrderByDescending(t => t.FullName));
                   Employees = temp;
               });

            MessagingCenter.Subscribe<SortPopupViewModel>(this,
               MessageKeys.DefaultSort, sender =>
               {
                   //Employees = Employees;
               });

            MessagingCenter.Subscribe<SortPopupViewModel>(this,
             MessageKeys.DateSort, sender =>
             {
                 //Employees = Employees;
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

        /// <summary>
        /// Команда выбора пользователя из списка
        /// </summary>
        public ICommand ClickCheckBoxCommand => new Command((emp) =>
        {
            if (emp is Employee employee)
            {
                var item = Employees.FirstOrDefault(i => i.Id == employee.Id);
                if (item != null)
                {

                    Employees.ToList().ForEach(c => c.IsChecked = false);
                    item.IsChecked = true;
                }
            }
            OnPropertyChanged(nameof(Employees));
        });

        /// <summary>
        /// Команда добавления председателя
        /// </summary>
        public ICommand AddChairmanCommand => new Command(async () =>
        {
            var item = Employees.FirstOrDefault(i => i.IsChecked);
            if (item != null)
            {
                MessagingCenter.Send(item, MessageKeys.AddChairman);
                await Navigation.PopModalAsync();
            }
        });

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

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

namespace MedExpertClientClone.ViewModels
{
    public class EmployeeListViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }

        private ObservableCollection<Employee> employees =
           new ObservableCollection<Employee>();

        public ObservableCollection<Employee> Employees
        {
            get { return employees; }
            set
            {
                employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public EmployeeListViewModel()
        {
            Employees = new ObservableCollection<Employee>()
            {
                new Employee(){FullName = "Батожаб Будаев"},
                new Employee(){ FullName = "Раднаев Жамбал"},
                new Employee(){FullName = "Будаев Будажаб"},
                new Employee(){ FullName = "Потапов Александр"},
                new Employee(){FullName = "Миронов Вячеслав"},
                new Employee(){ FullName = "Воронин Роман"},
                new Employee(){FullName = "Аранзаев Михаил"},
                new Employee(){ FullName = "Деревянко Александр"},
            };
        }

        /// <summary>
        /// Команда закрытия страницы
        /// </summary>
        public ICommand ClosePageCommand => new Command(async () =>
        {
            await Navigation.PopModalAsync();
        });

        /// <summary>
        /// Команда закрытия страницы
        /// </summary>
        public ICommand ClickCheckBoxCommand => new Command(async (emp) =>
        {
            if(emp is Employee employee)
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
        /// Команда закрытия страницы
        /// </summary>
        public ICommand OpenSortPopupCommand => new Command(async () =>
        {
            await PopupNavigation.Instance.PushAsync(new SortPopupView(), false);
        });

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

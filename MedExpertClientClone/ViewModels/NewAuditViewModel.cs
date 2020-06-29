using System;
using System.ComponentModel;
using System.Windows.Input;
using MedExpertClientClone.ViewModels.Base;
using MedExpertClientClone.Views;
using Xamarin.Forms;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;
using MedExpertClientClone.Models;
using System.Runtime.CompilerServices;
using System.Globalization;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace MedExpertClientClone.ViewModels
{
    public class NewAuditViewModel : INotifyPropertyChanged
    {
        private bool isChangedStartDate = false;
        private bool isChangedEndDate = false;
        private bool isListEmployeesVisible = false;
        private bool isChairmanVisible = false;

        private Employee chairman = new Employee();
        private AuditSubject auditSubject = new AuditSubject();

        private double listViewSelectedEmployeesHeight = 0;

        private ObservableCollection<Employee> selectedEmployees =
           new ObservableCollection<Employee>();

        private NewAudit Audit { get; set; }

        public ObservableCollection<Employee> SelectedEmployees
        {
            get { return selectedEmployees; }
            set
            {
                selectedEmployees = value;
                OnPropertyChanged(nameof(SelectedEmployees));
            }
        }

        public Employee Chairman
        {
            get { return chairman; }
            set
            {
                chairman = value;
                OnPropertyChanged();
            }
        }

        public AuditSubject AuditSubject
        {
            get { return auditSubject; }
            set
            {
                auditSubject = value;
                OnPropertyChanged();
            }
        }

        public string AuditSubjectText
        {
            get
            {
                if (AuditSubject?.Name != null)
                {
                    return $"{AuditSubject.Name}";
                }
                return "Выбрать";
            }
        }

        public string ChairmanText
        {
            get
            {
                if(Chairman?.FullName != null)
                {
                    return $"{Chairman.FullName}";
                }
                return "Выбрать";
            }
        }

        public bool IsChairmanVisible
        {
            get { return isChairmanVisible; }
            set
            {
                isChairmanVisible = value;
                OnPropertyChanged();
            }
        }

        public double ListViewSelectedEmployeesHeight
        {
            get { return listViewSelectedEmployeesHeight; }
            set
            {
                listViewSelectedEmployeesHeight = value;
                OnPropertyChanged(nameof(ListViewSelectedEmployeesHeight));
            }
        }

        public DateTime PeriodDateIn
        {
            get { return Audit.PeriodDateIn; }
            set
            {
                if (Audit.PeriodDateIn != value)
                {
                    Audit.PeriodDateIn = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(PeriodDateInText));
                }
            }
        }

        public DateTime PeriodDateOut
        {
            get { return Audit.PeriodDateOut; }
            set
            {
                if (Audit.PeriodDateOut != value)
                {
                    Audit.PeriodDateOut = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(PeriodDateOutText));
                }
            }
        }

        public bool IsChangedStartDate
        {
            get { return isChangedStartDate; }
            set
            {
                if (isChangedStartDate != value)
                {
                    isChangedStartDate = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(PeriodDateInText));
                }
            }
        }

        public bool IsChangedEndDate
        {
            get { return isChangedEndDate; }
            set
            {
                if (isChangedEndDate != value)
                {
                    isChangedEndDate = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(PeriodDateOutText));
                }
            }
        }

        public bool IsListEmployeesVisible
        {
            get { return isListEmployeesVisible; }
            set
            {
                isListEmployeesVisible = value;
                OnPropertyChanged();
            }
        }

        public string PeriodDateInText
        {
            get
            {
                if (IsChangedStartDate)
                {
                    return $"С {PeriodDateIn:dd.MM.yyyy}";
                }
                return "Начало";
            }
        }

        public string PeriodDateOutText
        {
            get
            {
                if (IsChangedEndDate)
                {
                    return $"По {PeriodDateOut:dd.MM.yyyy}";
                }
                return "Конец";
            }
        }

        public INavigation Navigation { get; set; }

        public NewAuditViewModel()
        {

            Audit = new NewAudit();
            MessagingCenter.Subscribe<CalendarPopupViewModel>(this,
                   MessageKeys.StartDateAudit, sender =>
                   {
                       PeriodDateIn = sender.SelectedDate;
                       IsChangedStartDate = true;
                   });

            MessagingCenter.Subscribe<CalendarPopupViewModel>(this,
                  MessageKeys.EndDateAudit, sender =>
                  {
                      PeriodDateOut = sender.SelectedDate;
                      IsChangedEndDate = true;
                  });

            MessagingCenter.Subscribe<EmployeeListViewModel>(this,
                 MessageKeys.AddEmployeers, sender =>
                 {

                     var t = new ObservableCollection<Employee>(sender.Employees
                                         .Where(i => (i is Employee && (((Employee)i)
                                         .IsChecked) && !IsExistInCurrentList(i))));
                     if (t.Count != 0)
                     {
                         foreach (var item in t)
                             SelectedEmployees.Add(item);
                     }

                     ListViewSelectedEmployeesHeight = (49 * SelectedEmployees.Count);
                     if (SelectedEmployees.Count != 0)
                     {
                         IsListEmployeesVisible = true;
                     }
                 });

            MessagingCenter.Subscribe<Employee>(this,
                MessageKeys.AddChairman, sender =>
                {
                    Chairman = sender;
                    OnPropertyChanged(nameof(ChairmanText));
                });

            MessagingCenter.Subscribe<AuditSubject>(this,
              MessageKeys.AddAuditSubject, sender =>
              {
                  AuditSubject = sender;
                  OnPropertyChanged(nameof(AuditSubjectText));
              });

            SelectedEmployees = new ObservableCollection<Employee>();
            ListViewSelectedEmployeesHeight = 0;
        }

        private bool IsExistInCurrentList(Employee o)
        {
            var flag = SelectedEmployees.Any(e => e.Id == o.Id);
            return flag;
        }

        /// <summary>
        /// Команда для открытия списка предметов проверок
        /// </summary>
        public ICommand OpenAddSubjectAuditCommand => new Command(() =>
            {
                Navigation.PushModalAsync(new NavigationPage(new AuditSubjectListView()), true);
            });

        /// <summary>
        /// Команда для открытия списка оснований проверок
        /// </summary>
        public ICommand OpenAuditBaseListViewCommand => new Command(() =>
        {
            Navigation.PushModalAsync(new NavigationPage(new AuditBaseListView()), true);
        });

        /// <summary>
        /// Команда для открытия видов проверок
        /// </summary>
        public ICommand OpenAuditTypeViewCommand => new Command(async () =>
            {
                await PopupNavigation.Instance.PushAsync(new AuditTypePopupView());
            });

        /// <summary>
        /// Команда для выбора начала периода проверки
        /// </summary>
        public ICommand OpenStartCalendarPopupCommand => new Command(async () =>
        {
            var calendarViewModel = new CalendarPopupViewModel
            {
                CalendarType = CalendarType.StartDate,
                NewAuditViewModel = this
            };

            var page = new CalendarPopupView();
            page.BindingContext = calendarViewModel;
            await PopupNavigation.Instance.PushAsync(page);
        });

        /// <summary>
        /// Команда для выбора конца периода проверки
        /// </summary>
        public ICommand OpenEndCalendarPopupCommand => new Command(async () =>
        {
            var calendarViewModel = new CalendarPopupViewModel
            {
                CalendarType = CalendarType.EndDate,
                NewAuditViewModel = this
            };

            var page = new CalendarPopupView();
            page.BindingContext = calendarViewModel;
            await PopupNavigation.Instance.PushAsync(page);
        });

        /// <summary>
        /// Команда для открытия списка сотрудников
        /// </summary>
        public ICommand OpenEmployeeListViewCommand => new Command(() =>
        {
            Navigation.PushModalAsync(new NavigationPage(new EmployeeListView()), true);
        });

        /// <summary>
        /// Команда для удаления выбранного пользователя
        /// </summary>
        public ICommand DeleteSelectedEmployeeCommand => new Command((e) =>
        {
            if (e is Employee employee)
            {
                var _employeesFiltered = new ObservableCollection<Employee>(SelectedEmployees
                                              .Where(i => (i is Employee && i
                                              .Id != employee.Id)));
                SelectedEmployees = _employeesFiltered;
                ListViewSelectedEmployeesHeight = (49 * SelectedEmployees.Count);
                if (SelectedEmployees.Count == 0)
                {
                    IsListEmployeesVisible = false;
                }
                OnPropertyChanged(nameof(SelectedEmployees));
                OnPropertyChanged(nameof(IsListEmployeesVisible));
            }
        });

        /// <summary>
        /// Команда для открытия списка сотрудников
        /// </summary>
        public ICommand OpenChairmanListViewCommand => new Command(() =>
        {
            Navigation.PushModalAsync(new NavigationPage(new ChairmanListView()), true);
        });

        /// <summary>
        /// Команда для удаления выбранного председателя
        /// </summary>
        public ICommand DeleteSelectedChairmanCommand => new Command((e) =>
        {
            Chairman = new Employee();
            IsChairmanVisible = false;
        });

        /// <summary>
        /// Команда для открытия показателя оценки качества
        /// </summary>
        public ICommand OpenQualityRatingIndicatorCommand => new Command(() =>
        {
            Navigation.PushModalAsync(new NavigationPage(new QualityRatingIndicatorView()), true);
        });


        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

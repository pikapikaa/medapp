﻿using System;
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

namespace MedExpertClientClone.ViewModels
{
    public class NewAuditViewModel : INotifyPropertyChanged
    {
        private bool isChangedStartDate = false;
        private bool isChangedEndDate = false;
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

            var _listOfItems = new DataFactory().GetEmployees();
            SelectedEmployees = new ObservableCollection<Employee>(_listOfItems);
            ListViewSelectedEmployeesHeight = (50 * _listOfItems.Count);
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
                CalendarType = CalendarType.StartDate
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
                CalendarType = CalendarType.EndDate
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

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

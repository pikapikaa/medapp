using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MedExpertClientClone.ViewModels.Base;
using MedExpertClientClone.Views;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MedExpertClientClone.ViewModels
{
    public class SortPopupViewModel : INotifyPropertyChanged
    {
        public SortPopupViewModel()
        {
        }

        private bool isDefaultSort = true;
        private bool isAscendingSort = false;
        private bool isDescendingSort = false;
        private bool isDateSort = false;

        public bool IsDefaultSort
        {
            get { return isDefaultSort; }
            set
            {
                isDefaultSort = value;
                OnPropertyChanged();
            }
        }

        public bool IsAscendingSort
        {
            get { return isAscendingSort; }
            set
            {
                isAscendingSort = value;
                OnPropertyChanged();
            }
        }

        public bool IsDescendingSort
        {
            get { return isDescendingSort; }
            set
            {
                isDescendingSort = value;
                OnPropertyChanged();
            }
        }

        public bool IsDateSort
        {
            get { return isDateSort; }
            set
            {
                isDateSort = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда выбора сортировки по возрастанию
        /// </summary>
        public ICommand ClickAscendingSortCommand => new Command(async () =>
        {
            IsAscendingSort = true;
            IsDefaultSort = false;
            IsDescendingSort = false;
            IsDateSort = false;
        });

        /// <summary>
        /// Команда выбора сортировки по убыванию
        /// </summary>
        public ICommand ClickDescendingSortCommand => new Command(() =>
        {
            IsAscendingSort = false;
            IsDefaultSort = false;
            IsDescendingSort = true;
            IsDateSort = false;
        });

        /// <summary>
        /// Команда выбора сортировки по умолчанию 
        /// </summary>
        public ICommand ClickDefaultSortCommand => new Command(() =>
        {
            IsAscendingSort = false;
            IsDefaultSort = true;
            IsDescendingSort = false;
            IsDateSort = false;
        });

        /// <summary>
        /// Команда выбора сортировки по дате
        /// </summary>
        public ICommand ClickDateSortCommand => new Command(() =>
        {
            IsAscendingSort = false;
            IsDefaultSort = false;
            IsDescendingSort = false;
            IsDateSort = true;
        });


        /// <summary>
        /// Команда для закрытия окна сортировки
        /// </summary>
        public ICommand CloseSortPopupCommand => new Command(async () =>
        {
            await PopupNavigation.Instance.PopAsync();
        });

        /// <summary>
        /// Команда для сортировки списка пользователей
        /// </summary>
        public ICommand SortEmployeesCommand => new Command(async () =>
        {
            if (IsAscendingSort)
            {
                MessagingCenter.Send(this, MessageKeys.AscendingSort);
            }
            else if (IsDescendingSort)
            {
                MessagingCenter.Send(this, MessageKeys.DescendingSort);
            }
            else if (IsDateSort)
            {
                MessagingCenter.Send(this, MessageKeys.DateSort);
            }
            else if(IsDefaultSort)
            {
                MessagingCenter.Send(this, MessageKeys.DefaultSort);
            }
            await PopupNavigation.Instance.PopAsync();
        });


        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

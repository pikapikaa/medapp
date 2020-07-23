using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Linq;
using MedExpertClientClone.Models;
using Syncfusion.SfCalendar.XForms;
using Xamarin.Forms;
using SelectionChangedEventArgs = Syncfusion.SfCalendar.XForms.SelectionChangedEventArgs;
using MedExpertClientClone.Views.Audits;

namespace MedExpertClientClone.ViewModels.Audits
{
    public class AuditListWithDateTabbedViewModel : INotifyPropertyChanged
    {
        private double listViewHeight = 0;
        private int numberOfAudits = 0;
        private ObservableCollection<NewAudit> audits;
        private ObservableCollection<NewAudit> _auditsFiltered = new ObservableCollection<NewAudit>();
        private ObservableCollection<NewAudit> _auditsUnfiltered = new ObservableCollection<NewAudit>();

        public INavigation Navigation { get; set; }

        /// <summary>
        /// Выбранный диапазон дат
        /// </summary>
        public SelectionRange SelectedRange { get; set; }

        /// <summary>
        /// Высота ListView(списка проверок)
        /// </summary>
        public double ListViewHeight
        {
            get { return listViewHeight; }
            set
            {
                listViewHeight = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Количество проверок
        /// </summary>
        public int NumberOfAudits
        {
            get { return numberOfAudits; }
            set
            {
                numberOfAudits = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Список всех проверок
        /// </summary>
        public ObservableCollection<NewAudit> Audits
        {
            get { return audits; }
            set
            {
                audits = value;
                OnPropertyChanged();
            }
        }

        public AuditListWithDateTabbedViewModel()
        {
            SelectedRange = new SelectionRange();

            var _listOfItems = new DataAuditFactory().GetAudits();
            Audits = new ObservableCollection<NewAudit>(_listOfItems);
            _auditsUnfiltered = new ObservableCollection<NewAudit>(_listOfItems);

            NumberOfAudits = Audits.Count;
            setHeightListView();
        }

        /// <summary>
        /// Команда выбора диапазона дат в календаре
        /// </summary>
        [Obsolete]
        public ICommand OnSelectionChanged => new Command<SelectionChangedEventArgs>((SelectionChangedEventArgs obj) =>
        {
            SelectedRange = (SelectionRange)obj.Calendar.SelectedRange;
            _auditsFiltered = new ObservableCollection<NewAudit>();

            var queryList = from i in _auditsUnfiltered
                            where i.PeriodDateIn >= SelectedRange.StartDate && i.PeriodDateIn.Date <= SelectedRange.EndDate
                            select i;

            foreach (var item in queryList)
            {
                _auditsFiltered.Add(item);
            }

            Audits = _auditsFiltered;

            NumberOfAudits = Audits.Count;
            setHeightListView();
        });

        /// <summary>
        /// Команда открытия окна????????????????????????
        /// </summary>
        public ICommand OpenCheckListGroupCommand => new Command<CheckList>((CheckList list) =>
        {
            Navigation.PushAsync(new CheckListGroupView());
        });

        /// <summary>
        /// Метод вычисления высоты ListView(списка проверок)
        /// </summary>
        private void setHeightListView()
        {
            double countOfCheckLists = 0;
            if (Audits.Count != 0)
            {
                foreach (var item in Audits)
                    countOfCheckLists += item.CheckListHeight;

            }
            ListViewHeight = Audits.Count * 130 + countOfCheckLists;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
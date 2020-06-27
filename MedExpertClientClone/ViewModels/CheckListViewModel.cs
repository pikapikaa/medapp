using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MedExpertClientClone.Models;
using Xamarin.Forms;

namespace MedExpertClientClone.ViewModels
{
    public class CheckListViewModel : INotifyPropertyChanged
    {
        public CheckListViewModel()
        {
            var _listOfItems = new DataCheckList().GetCheckLists();
            CheckLists = new ObservableCollection<CheckList>(_listOfItems);
            _checkListsUnfiltered = new ObservableCollection<CheckList>(_listOfItems);
        }

        public ObservableCollection<CheckList> checkLists = new ObservableCollection<CheckList>();
        private ObservableCollection<CheckList> _checkListsFiltered;
        private ObservableCollection<CheckList> _checkListsUnfiltered;
        private bool isEntryVisible;
        private string searchText;

        public ObservableCollection<CheckList> CheckLists
        {
            get { return checkLists; }
            set
            {
                checkLists = value;
                OnPropertyChanged();
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
                OnPropertyChanged();
                OnPropertyChanged(nameof(CheckLists));
            }
        }

        public INavigation Navigation { get; set; }

        public ICommand CloseCheckListViewCommand => new Command(() =>
        {
            Navigation.PopModalAsync();
        });

        public ICommand ClickCheckBoxCommand => new Command((emp) =>
        {
            if (emp is CheckList checkList)
            {
                var item = CheckLists.FirstOrDefault(i => i.Id == checkList.Id);
                if (item != null)
                {
                    item.IsChecked = !item.IsChecked;
                }
            }
            OnPropertyChanged(nameof(CheckLists));
        });

        public ICommand ShowSearchEntryCommand => new Command((emp) =>
        {
            IsEntryVisible = !IsEntryVisible;
        });

        public ICommand SearchTextChangedCommand => new Command((emp) =>
        {
            if (string.IsNullOrWhiteSpace(SearchText))
                CheckLists = _checkListsUnfiltered;
            else
            {
                _checkListsFiltered = new ObservableCollection<CheckList>(_checkListsUnfiltered
                                            .Where(i => (i is CheckList && (((CheckList)i)
                                            .Name.ToLower()
                                            .Contains(SearchText.ToLower())))));
                CheckLists = _checkListsFiltered;
            }
        }); 

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    internal class DataCheckList
    {
        public List<CheckList> GetCheckLists()
        {
            return new List<CheckList>()
            {
                new CheckList(){Id=1,Name = "УПРАВЛЕНИЕ ПЕРСОНАЛОМ. МЕДИЦИНСКИЕ КАДРЫ. КОМПЕТЕНТНОСТЬ И КОМПЕТЕНЦИИ"},
                new CheckList(){Id=2,Name = "ОРГАНИЗАЦИЯ ПРОФИЛАКТИЧЕСКОЙ РАБОТЫ. ФОРМИРОВАНИЕ ЗДОРОВОГО ОБРАЗА ЖИЗНИ СРЕДИ НАСЕЛЕНИЯ"},
                new CheckList(){Id=3,Name = "Организация работы регистратуры"},
                new CheckList(){Id=4, Name = "Управление потоками пациентов"},
                new CheckList(){Id=5,Name = "ИДЕНТИФИКАЦИЯ ЛИЧНОСТИ ПАЦИЕНТА"},
                new CheckList(){Id=6, Name = "БЕЗОПАСНОСТЬ СРЕДЫ В МЕДИЦИНСКОЙ ОРГАНИЗАЦИИ. ОРГАНИЗАЦИЯ УХОДА ЗА ПАЦИЕНТАМИ. ПРОФИЛАКТИКА ПРОЛЕЖНЕЙ. ПРОФИЛАКТИКА ПАДЕНИЙ"},
                new CheckList(){Id=7,Name = "Хранение лекарственных препаратов для медицинского применения в медицинской организации и иных организациях, имеющих лицензию на медицинскую деятельность (Приложение 2)"},
                new CheckList(){Id=8, Name = "Хранение лекарственных препаратов для медицинского применения в аптеке готовых форм (Приложение3)"},
                new CheckList(){Id=9,Name = "Хранение лекарственных препаратов для медицинского применения в аптечном пункте (Приложение 4)"},
                new CheckList(){Id=10, Name = "Хранение лекарственных препаратов для медицинского применения в аптечном киоске (Приложение 5)"},
                new CheckList(){Id=11,Name = "Хранение лекарственных препаратов для медицинского применени в аптеке производственной (приложение 6)"},
                new CheckList(){Id=12, Name = "Хранение лекарственных препаратов для медицинского применения в аптеке производственной с правом изготовления асептических лекарственных препаратов (Приложение 7)"},
                new CheckList(){Id=13,Name = "Хранение лекарственных препаратов для медицинского применения в медицинских организациях и их обособленных подразделениях (центры (отделения) общей врачебной (семейной) практики, амбулатории, фельдшерские и фельдшерско-акушерские пункты), расположенные в сельских населенных пунктах (Приложение 8)"},
                new CheckList(){Id=14, Name = "Хранение лекарственных препаратов для медицинского применения индивидуальными предпринимателями (Приложение 9)"}
            };
        }
    }
}

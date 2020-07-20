using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MedExpertClientClone.Models;
using Syncfusion.SfCalendar.XForms;
using Xamarin.Forms;
using SelectionChangedEventArgs = Syncfusion.SfCalendar.XForms.SelectionChangedEventArgs;

namespace MedExpertClientClone.ViewModels.Audits
{
    public class AuditListWithDateTabbedViewModel : INotifyPropertyChanged
    {
        public SelectionRange SelectedRange { get; set; }

        private double listViewHeight = 0;

        public double ListViewHeight
        {
            get { return listViewHeight; }
            set
            {
                listViewHeight = value;
                OnPropertyChanged(nameof(ListViewHeight));
            }
        }

        private ObservableCollection<NewAudit> audits;

        public ObservableCollection<NewAudit> Audits
        {
            get { return audits; }
            set
            {
                audits = value;
                OnPropertyChanged(nameof(Audits));
            }
        }

        private string selectionChangedCommandText;

        public string SelectionChangedCommandText
        {
            get { return selectionChangedCommandText; }
            set
            {
                selectionChangedCommandText = value;
                OnPropertyChanged();
            }
        }

        public AuditListWithDateTabbedViewModel()
        {
            SelectedRange = new SelectionRange();
            SelectedRange.StartDate = new DateTime(2020, 07, 10);
            SelectedRange.EndDate = new DateTime(2020, 07, 20);
            var _listOfItems = new DataAuditFactory().GetAudits();
            Audits = new ObservableCollection<NewAudit>(_listOfItems);

            double countOfCheckLists = 0;
            if (Audits.Count != 0)
            {
                foreach (var item in Audits)
                    countOfCheckLists += item.CheckListHeight;
                   
            }
            ListViewHeight = Audits.Count * 130 + countOfCheckLists;
        }

        public ICommand OnSelectionChanged => new Command<SelectionChangedEventArgs>((SelectionChangedEventArgs obj) =>
        {
            SelectionChangedCommandText = " DateAdded- " + obj.DateAdded?.Count.ToString() + "  " + " DateRemoved- " + obj.DateRemoved?.Count.ToString() + "  " + " NewRangeAdded -"
      + obj.NewRangeAdded?.Count.ToString();
        });

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
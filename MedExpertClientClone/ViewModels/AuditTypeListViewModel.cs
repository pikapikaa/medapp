using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using MedExpertClientClone.Models;
using Xamarin.Forms;

namespace MedExpertClientClone.ViewModels
{
    public class AuditTypeListViewModel
    {
        public ObservableCollection<AuditType> AuditTypes { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand OpenAddAuditPageCommand { protected set; get; }
        public INavigation Navigation { get; set; }
        public AuditTypeListViewModel()
        {
            AuditTypes = new ObservableCollection<AuditType>()
            {
                new AuditType(){Name = "Плановая"},
                new AuditType(){ Name = "Внеплановая"}
            };
        }
    }
}

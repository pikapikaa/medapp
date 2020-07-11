using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MedExpertClientClone.Models;

namespace MedExpertClientClone.ViewModels
{
    public class AuditTabbedViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<NewAudit> audits;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<NewAudit> Audits
        {
            get { return audits; }
            set
            {
                audits = value;
                OnPropertyChanged(nameof(Audits));
            }
        }

        public AuditTabbedViewModel()
        {
            var _listOfItems = new DataAuditFactory().GetAudits();
            Audits = new ObservableCollection<NewAudit>(_listOfItems);
        }

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    internal class DataAuditFactory
    {
        public List<NewAudit> GetAudits()
        {
            return new List<NewAudit>()
            {
                new NewAudit(){
                    Id=1,
                    Num=443,
                    Location="Проверка №1 ГБУЗ «Городская поликлиника № 1», г. Улан-Удэ, ул. Каландарашвили, 27",
                    PeriodDateIn=new DateTime(2020,5,5),
                    PeriodDateOut=new DateTime(2020,6,5),
                    Status = AuditOperationStatus.Created,
                    CheckLists = new List<CheckList>{
                          new CheckList()
                        {
                            Id=1,
                            Auditor=null,
                            IsChecked=false,
                            Name="Соблюдение прав граждан"
                        },
                        new CheckList()
                        {
                            Id=2,
                            Auditor=null,
                            IsChecked=false,
                            Name="Проверка кабинетов, в том числе соблюдение условий хранения ЛС и МИ"
                        },
                        new CheckList()
                        {
                            Id=3,
                            Auditor=null,
                            IsChecked=false,
                            Name="Размещение информации на информационных стендах и сайте организации"
                        },
                    } },
                new NewAudit(){
                    Id=2,
                    Num=24,
                    Location="Проверка №1 ГБУЗ «Городская поликлиника № 1», г. Улан-Удэ, ул. Каландарашвили, 27",
                    PeriodDateIn=new DateTime(2020,5,5),
                    PeriodDateOut=new DateTime(2020,6,5),
                    Status = AuditOperationStatus.Executed,
                    CheckLists = new List<CheckList>{
                        new CheckList()
                        {
                            Id=1,
                            Auditor=null,
                            IsChecked=false,
                            Name="Соблюдение прав граждан"
                        },
                        new CheckList()
                        {
                            Id=2,
                            Auditor=null,
                            IsChecked=false,
                            Name="Соблюдение прав животных"
                        },
                    } },
                 new NewAudit(){
                    Id=3,
                    Num=56,
                    Location="Проверка №1 ГБУЗ «Городская поликлиника № 1», г. Улан-Удэ, ул. Каландарашвили, 27",
                    PeriodDateIn=new DateTime(2020,5,5),
                    PeriodDateOut=new DateTime(2020,6,5),
                    Status = AuditOperationStatus.Running,
                    CheckLists = new List<CheckList>{
                        new CheckList()
                        {
                            Id=1,
                            Auditor=null,
                            IsChecked=false,
                            Name="Соблюдение прав граждан"
                        },
                        new CheckList()
                        {
                            Id=2,
                            Auditor=null,
                            IsChecked=false,
                            Name="Проверка кабинетов, в том числе соблюдение условий хранения ЛС и МИ"
                        },
                        new CheckList()
                        {
                            Id=3,
                            Auditor=null,
                            IsChecked=false,
                            Name="Размещение информации на информационных стендах и сайте организации"
                        },
                    } },
                 new NewAudit(){
                    Id=4,
                    Num=57,
                    Location="Проверка №1 ГБУЗ «Городская поликлиника № 1», г. Улан-Удэ, ул. Каландарашвили, 27",
                    PeriodDateIn=new DateTime(2020,5,5),
                    PeriodDateOut=new DateTime(2020,6,5),
                    Status = AuditOperationStatus.Signed,
                    CheckLists = new List<CheckList>{
                        new CheckList()
                        {
                            Id=1,
                            Auditor=null,
                            IsChecked=false,
                            Name="Соблюдение прав граждан"
                        },
                        new CheckList()
                        {
                            Id=2,
                            Auditor=null,
                            IsChecked=false,
                            Name="Соблюдение прав животных"
                        },
                    } },
                new NewAudit(){
                    Id=5,
                    Num=38,
                    Location="Проверка №1 ГБУЗ «Городская поликлиника № 1», г. Улан-Удэ, ул. Каландарашвили, 27",
                    PeriodDateIn=new DateTime(2020,5,5),
                    PeriodDateOut=new DateTime(2020,6,5),
                    Status = AuditOperationStatus.Signing,
                    CheckLists = new List<CheckList>{
                         new CheckList()
                        {
                            Id=1,
                            Auditor=null,
                            IsChecked=false,
                            Name="Соблюдение прав граждан"
                        },
                        new CheckList()
                        {
                            Id=2,
                            Auditor=null,
                            IsChecked=false,
                            Name="Проверка кабинетов, в том числе соблюдение условий хранения ЛС и МИ"
                        },
                        new CheckList()
                        {
                            Id=3,
                            Auditor=null,
                            IsChecked=false,
                            Name="Размещение информации на информационных стендах и сайте организации"
                        },
                    } }


            };
        }
    }
}

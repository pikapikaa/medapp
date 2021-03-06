﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MedExpertClientClone.Models;
using MedExpertClientClone.Views.Popups;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MedExpertClientClone.ViewModels
{
    public class AuditListTabbedViewModel : INotifyPropertyChanged
    {
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

        public AuditListTabbedViewModel()
        {
            var _listOfItems = new DataAuditFactory().GetAudits();
            Audits = new ObservableCollection<NewAudit>(_listOfItems);
        }

        public ICommand SelectToolbar => new Command(async () =>
        {
            await PopupNavigation.Instance.PushAsync(new MenuAuditListPopupView(), false);
        });

        public event PropertyChangedEventHandler PropertyChanged;

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
                    Location="ГБУЗ «Городская поликлиника № 1», г. Улан-Удэ, ул. Каландарашвили, 27",
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
                    Location="ГБУЗ «Городская поликлиника № 1», г. Улан-Удэ, ул. Каландарашвили, 27",
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
                    Location="ГБУЗ «Городская поликлиника № 1», г. Улан-Удэ, ул. Каландарашвили, 27",
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
                    Location="ГБУЗ «Городская поликлиника № 1», г. Улан-Удэ, ул. Каландарашвили, 27",
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
                    Location="ГБУЗ «Городская поликлиника № 1», г. Улан-Удэ, ул. Каландарашвили, 27",
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
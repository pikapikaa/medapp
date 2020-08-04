using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Input;
using MedExpertClientClone.Models;
using MedExpertClientClone.Views.Audits;
using Xamarin.Forms;
using Syncfusion.XForms.TreeView;

namespace MedExpertClientClone.ViewModels.Audits
{
    public class FileManagerViewModel
    {
        private ObservableCollection<FileManager> imageNodeInfo;
  
        public INavigation Navigation { get; set; }

        public FileManagerViewModel()
        {
            GenerateSource();
        }

        public ObservableCollection<FileManager> ImageNodeInfo
        {
            get { return imageNodeInfo; }
            set { this.imageNodeInfo = value; }
        }

        /// <summary>
        /// Команда открытия детального представления чек-листа
        /// </summary>
        public ICommand OpenCheckListDetailViewCommand => new Command<object>((object list) =>
        {
            Navigation.PushAsync(new CheckListDetailView());
        });

        private void GenerateSource()
        {
            var nodeImageInfo = new ObservableCollection<FileManager>();
            Assembly assembly = typeof(CheckListGroupsView).GetTypeInfo().Assembly;

            var check1 = new FileManager()
            {
                ItemName = "Уровень 1: Соблюдение осуществляющими медицинскую деятельность организациями и индивидуальными предпринимателями порядков проведения медицинских экспертиз, медицинских осмотров и медицинских освидетельствований (Приложение 3)",
            };

            var check1_level2 = new FileManager()
            {
                ItemName = "Уровень 2: Соблюдение медицинскими организациями и индивидуальными предпринимателями, осуществляющими медицинскую деятельность, порядка проведения судебно-медицинской экспертизы",
            };

            var check1_level2_1 = new FileManager()
            {
                ItemName = "Уровень 2: Соблюдение медицинскими организациями и индивидуальными предпринимателями, осуществляющими медицинскую деятельность, порядков проведения военно-врачебной экспертизы",
            };

            var check1_level3 = new FileManager()
            {
                ItemName = "Уровень 3: Имеется ли у государственного судебно-экспертного учреждения (далее - ГСЭУ) лицензия на осуществление медицинской деятельности по соответствующим работам (услугам) (судебно-медицинская экспертиза)?",
            };

            var check1_level3_1 = new FileManager()
            {
                ItemName = "Уровень 3: Соответствует ли штатное расписание ГСЭУ требованиям, установленным для соответствующих медицинских организаций (структурных подразделений)?",
                AnswerType = AnswerType.Yes,
            };

            var check1_level3_2 = new FileManager()
            {
                ItemName = "Уровень 3: Соблюдаются ли квалификационные требования к образованию и занимаемой должности эксперта ГСЭУ с целью производства судебной экспертизы?",
                AnswerType = AnswerType.InApplicable,
            };

            var check1_level3_3 = new FileManager()
            {
                ItemName = "Уровень 3: Порядок действий персонала при чрезвычайных ситуациях",
                AnswerType = AnswerType.No,
            };

            var check1_level3_4 = new FileManager()
            {
                ItemName = "Уровень 3: Имеется ли у государственного судебно-экспертного учреждения (далее - ГСЭУ) лицензия на осуществление медицинской деятельности по соответствующим работам (услугам) (судебно-медицинская экспертиза)?",
            };

            var check1_level3_5 = new FileManager()
            {
                ItemName = "Уровень 3: Соответствует ли штатное расписание ГСЭУ требованиям, установленным для соответствующих медицинских организаций (структурных подразделений)?",
                AnswerType = AnswerType.Yes,
            };

            var check1_level3_6 = new FileManager()
            {
                ItemName = "Уровень 3: Соблюдаются ли квалификационные требования к образованию и занимаемой должности эксперта ГСЭУ с целью производства судебной экспертизы?",
                AnswerType = AnswerType.InApplicable,
            };

            var check1_level3_7 = new FileManager()
            {
                ItemName = "Уровень 3: Порядок действий персонала при чрезвычайных ситуациях",
                AnswerType = AnswerType.No,
            };

            var check2 = new FileManager()
            {
                ItemName = "Уровень 1: ОРГАНИЗАЦИЯ ПРОФИЛАКТИЧЕСКОЙ РАБОТЫ. ФОРМИРОВАНИЕ ЗДОРОВОГО ОБРАЗА ЖИЗНИ СРЕДИ НАСЕЛЕНИЯ",
            };

            var check2_level2 = new FileManager()
            {
                ItemName = "Организация работы профилактического отделения, мероприятий по формированию здорового образа жизни",
            };

            var check2_level3 = new FileManager()
            {
                ItemName = "Наличие приказов главного врача включая определение отвественных, комиссии, рабочей группы  по:",
            };

            var check2_level3_1 = new FileManager()
            {
                ItemName = "Наличие ведомственных,  региональных приказов",
                AnswerType = AnswerType.InApplicable,
            };

            var check2_level3_2 = new FileManager()
            {
                ItemName = "Наличие приказов главного врача по организации работы Центра медицинской профилактики (если применимо)",
                AnswerType = AnswerType.Yes,
            };

            var check2_level3_3 = new FileManager()
            {
                ItemName = "Проведение регулярного аудита мероприятий профилактики хронических неинфекционных заболеваний",
                AnswerType = AnswerType.No,
            };

            var check2_level4 = new FileManager()
            {
                ItemName = "наличие национального календаря от текущего года;",
                AnswerType = AnswerType.InApplicable,
            };

            var check2_level4_1 = new FileManager()
            {
                ItemName = "наличие плана мероприятий МО вовлечения прикрепленного населения к проведению вакцинации на текущий год.",
                AnswerType = AnswerType.No,
            };

            check1.SubFiles = new ObservableCollection<FileManager>
            {
                check1_level2,
                check1_level2_1
            };

            check1_level2.SubFiles = new ObservableCollection<FileManager>
            {
                check1_level3,
                check1_level3_1,
                check1_level3_2,
                check1_level3_3,
            };

            check1_level2_1.SubFiles = new ObservableCollection<FileManager>
            {
                check1_level3_4,
                check1_level3_5,
                check1_level3_6,
                check1_level3_7,
            };

            check2.SubFiles = new ObservableCollection<FileManager>
            {
                check2_level2,
            };

            check2_level2.SubFiles = new ObservableCollection<FileManager>
            {
                check2_level3,
                check2_level3_1,
                check2_level3_2,
                check2_level3_3,
            };

            check2_level3.SubFiles = new ObservableCollection<FileManager>
            {
                check2_level4,
                check2_level4_1
            };

            nodeImageInfo.Add(check1);
            nodeImageInfo.Add(check2);

            imageNodeInfo = nodeImageInfo;
        }
    }
}

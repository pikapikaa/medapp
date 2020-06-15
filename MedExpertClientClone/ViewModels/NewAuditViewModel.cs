using System;
using System.ComponentModel;
using System.Windows.Input;
using MedExpertClientClone.ViewModels.Base;
using MedExpertClientClone.Views;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace MedExpertClientClone.ViewModels
{
    public class NewAuditViewModel : ViewModelBase
    {
        public INavigation Navigation { get; set; }
        public NewAuditViewModel()
        {
            
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
        public ICommand OpenAuditTypeViewCommand => new Command(
            async () =>
            {
                string[] arr = { "Плановая", "Внеплановая" };
                await DialogService.DisplayActionSheet("Вид проверки", "Отмена", null, arr);
            });
    }
}

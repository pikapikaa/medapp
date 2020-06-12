using System;
using MedExpertClientClone.Views;
using Xamarin.Forms;

namespace MedExpertClientClone
{
    public class MedExpertMasterDetailPage : MasterDetailPage
    {
        public MedExpertMasterDetailPage()
        {
            var master = new MenuMasterPage();
            if (Device.RuntimePlatform == Device.iOS)
            {
                master.IconImageSource = ImageSource.FromFile("nav-menu-icon");
            }
            master.PageSelected += OnPageSelected;

            this.Master = master;
            this.MasterBehavior = MasterBehavior.Popover;

            OnPageSelected(null, PageType.Audits);
        }

        private void OnPageSelected(object e, PageType pageType)
        {
            Page page;

            switch (pageType)
            {
                case PageType.Audits:
                    page = new AuditOperationGroupsView();
                    break;
                case PageType.Tasks:
                case PageType.Projects:
                case PageType.Profile:
                case PageType.Settings:
                case PageType.Updating:
                default:
                    page = new BlablablaView();
                    break;
            }

            Detail = new NavigationPage(page);
            IsPresented = false;
        }
    }
}

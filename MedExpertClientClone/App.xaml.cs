using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedExpertClientClone
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjg4NDU2QDMxMzgyZTMyMmUzMG82a3ZvOTZQblBRdmNJYm92NjhKbEpuTWFuOFI4bVAxRVY5RFRPYitrZVE9");
            InitializeComponent();

            MainPage = new MedExpertMasterDetailPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

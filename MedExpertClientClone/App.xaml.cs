using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedExpertClientClone
{
    public partial class App : Application
    {
        public App()
        {
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

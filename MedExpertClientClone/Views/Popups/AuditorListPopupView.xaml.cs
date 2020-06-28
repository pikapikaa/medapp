using System;
using System.Collections.Generic;
using MedExpertClientClone.ViewModels;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace MedExpertClientClone.Views.Popups
{
    public partial class AuditorListPopupView : PopupPage
    {
        public AuditorListPopupView()
        {
            InitializeComponent();
        }

        private async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}

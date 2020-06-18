using System;
using System.Collections.Generic;
using MedExpertClientClone.ViewModels;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MedExpertClientClone.Views
{
    public partial class CalendarPopupView : PopupPage
    {
        public CalendarPopupView()
        {
            InitializeComponent();
            BindingContext = new CalendarPopupViewModel();
        }

        private async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}

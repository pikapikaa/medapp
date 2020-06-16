using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MedExpertClientClone.Views
{
    public partial class AuditTypePopupView : PopupPage
    {
        public AuditTypePopupView()
        {
            InitializeComponent();
        }

        private async void Button_ClickedAsync(System.Object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}

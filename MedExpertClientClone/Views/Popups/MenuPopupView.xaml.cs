using System;
using System.Collections.Generic;
using MedExpertClientClone.ViewModels;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MedExpertClientClone.Views.Popups
{
    public partial class MenuPopupView : PopupPage
    {
        public MenuPopupView()
        {
            InitializeComponent();
            this.BindingContext = new MenuPopupViewModel();
        }
    }
}

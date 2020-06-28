using System;
using System.Collections.Generic;
using MedExpertClientClone.ViewModels;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MedExpertClientClone.Views.Popups
{
    public partial class MenuCheckListPopupView : PopupPage
    {
        public MenuCheckListPopupView()
        {
            InitializeComponent();
            this.BindingContext = new MenuCheckListPopupViewModel();
        }
    }
}
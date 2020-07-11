using System;
using System.Collections.Generic;
using MedExpertClientClone.ViewModels;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace MedExpertClientClone.Views.Popups
{
    public partial class MenuAuditListPopupView : PopupPage
    {
        public MenuAuditListPopupView()
        {
            InitializeComponent();
            this.BindingContext = new MenuAuditListPopupViewModel();
        }
    }
}

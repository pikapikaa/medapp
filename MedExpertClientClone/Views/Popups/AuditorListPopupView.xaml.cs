using System;
using System.Collections.Generic;
using MedExpertClientClone.ViewModels;
using Rg.Plugins.Popup.Pages;

namespace MedExpertClientClone.Views.Popups
{
    public partial class AuditorListPopupView : PopupPage
    {
        public AuditorListPopupView()
        {
            InitializeComponent();
            this.BindingContext = new AuditorListPopupViewModel();
        }
    }
}
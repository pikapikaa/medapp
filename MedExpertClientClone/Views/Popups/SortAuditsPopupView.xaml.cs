using System;
using System.Collections.Generic;
using MedExpertClientClone.ViewModels;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace MedExpertClientClone.Views.Popups
{
    public partial class SortAuditsPopupView : PopupPage
    {
        public SortAuditsPopupView()
        {
            InitializeComponent();
            this.BindingContext = new SortAuditsPopupViewModel();
        }
    }
}

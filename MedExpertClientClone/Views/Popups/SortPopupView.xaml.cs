using System;
using System.Collections.Generic;
using MedExpertClientClone.ViewModels;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MedExpertClientClone.Views
{
    public partial class SortPopupView : PopupPage
    {
        public SortPopupView()
        {
            InitializeComponent();
            this.BindingContext = new SortPopupViewModel();
        }
    }
}

using System;
using System.Collections.Generic;
using MedExpertClientClone.ViewModels;
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
            this.BindingContext = new AuditTypeListViewModel
            {
                Navigation = this.Navigation
            };
        }
    }
}

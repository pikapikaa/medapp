using System;
using System.Collections.Generic;
using MedExpertClientClone.ViewModels;
using Xamarin.Forms;

namespace MedExpertClientClone.Views
{
    public partial class NewAuditView : ContentPage
    {
        public NewAuditView()
        {
            InitializeComponent();
            BindingContext = new NewAuditViewModel()
            {
                Navigation = this.Navigation
            };
        }
    }
}

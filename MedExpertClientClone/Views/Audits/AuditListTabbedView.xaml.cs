using System;
using System.Collections.Generic;
using MedExpertClientClone.ViewModels;
using Xamarin.Forms;

namespace MedExpertClientClone.Views.Audits
{
    public partial class AuditListTabbedView : ContentPage
    {
        public AuditListTabbedView()
        {
            InitializeComponent();
            this.BindingContext = new AuditListTabbedViewModel();
        }
    }
}

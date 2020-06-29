using System;
using System.Collections.Generic;
using MedExpertClientClone.ViewModels;
using Xamarin.Forms;

namespace MedExpertClientClone.Views
{
    public partial class AuditBaseListView : ContentPage
    {
        public AuditBaseListView()
        {
            InitializeComponent();
            BindingContext = new AuditBaseListViewModel()
            {
                Navigation = this.Navigation
            };
        }
    }
}
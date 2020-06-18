using System;
using System.Collections.Generic;
using MedExpertClientClone.ViewModels;
using Xamarin.Forms;

namespace MedExpertClientClone.Views
{
    public partial class EmployeeListView : ContentPage
    {
        public EmployeeListView()
        {
            InitializeComponent();
            this.BindingContext = new EmployeeListViewModel
            {
                Navigation = this.Navigation
            };
        }
    }
}

﻿using System;
using System.Collections.Generic;
using MedExpertClientClone.ViewModels;
using Xamarin.Forms;

namespace MedExpertClientClone.Views
{
    public partial class AuditTypeListView : ContentPage
    {
        public AuditTypeListView()
        {
            InitializeComponent();
            BindingContext = new AuditTypeListViewModel()
            {
                Navigation = this.Navigation
            };
        }

        void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using MedExpertClientClone.ViewModels;
using Xamarin.Forms;

namespace MedExpertClientClone.Views
{
    public partial class AuditOperationGroupsView : ContentPage
    {
        public AuditOperationGroupsView()
        {
            InitializeComponent();
            BindingContext = new AuditOperationGroupsViewModel()
            {
                Navigation = this.Navigation
            };
        }
    }
}

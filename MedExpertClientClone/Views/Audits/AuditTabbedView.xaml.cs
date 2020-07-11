﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedExpertClientClone.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedExpertClientClone.Views.Audits
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuditTabbedView : TabbedPage
    {
        public AuditTabbedView()
        {
            InitializeComponent();
            this.BindingContext = new AuditTabbedViewModel();
        }
    }
}
using System;
using System.Collections.Generic;
using MedExpertClientClone.ViewModels.Audits;
using Xamarin.Forms;

namespace MedExpertClientClone.Views.Audits
{
    public partial class AuditListWithDateTabbedView : ContentPage
    {
        public AuditListWithDateTabbedView()
        {
            InitializeComponent();
            this.BindingContext = new AuditListWithDateTabbedViewModel();
            calendar.Locale = new System.Globalization.CultureInfo("ru-RU");
        }
    }
}

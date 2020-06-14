using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MedExpertClientClone.Views
{
    public partial class AuditSubjectListView : ContentPage
    {
        public AuditSubjectListView()
        {
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}

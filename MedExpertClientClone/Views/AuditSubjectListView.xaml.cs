using System;
using System.Collections.Generic;
using MedExpertClientClone.ViewModels;
using Xamarin.Forms;

namespace MedExpertClientClone.Views
{
    public partial class AuditSubjectListView : ContentPage
    {
        public AuditSubjectListView()
        {
            InitializeComponent();
            BindingContext = new AuditSubjectListViewModel()
            {
                Navigation = this.Navigation
            };
            auditSubjectlistView.ItemSelected += (sender, e) =>
            {
                if (e.SelectedItem == null) return;
              
                ((ListView)sender).SelectedItem = null;
            };
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}

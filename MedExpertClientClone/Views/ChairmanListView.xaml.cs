using System;
using System.Collections.Generic;
using MedExpertClientClone.ViewModels;
using Xamarin.Forms;

namespace MedExpertClientClone.Views
{
    public partial class ChairmanListView : ContentPage
    {
        public ChairmanListView()
        {
            InitializeComponent();
            this.BindingContext = new ChairmanListViewModel()
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

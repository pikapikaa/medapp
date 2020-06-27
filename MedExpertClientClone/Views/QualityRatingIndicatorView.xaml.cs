using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MedExpertClientClone.Views
{
    public partial class QualityRatingIndicatorView : ContentPage
    {
        public QualityRatingIndicatorView()
        {
            InitializeComponent();
        }

        void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}
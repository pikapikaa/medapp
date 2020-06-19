using System;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using MedExpertClientClone.Droid;
using MedExpertClientClone.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntryRenderer), typeof(EntrySearchRenderer))]
namespace MedExpertClientClone.Droid
{
    public class EntrySearchRenderer : EntryRenderer
    {
        public EntrySearchRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null || e.NewElement == null) return;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                Control.BackgroundTintList = ColorStateList.ValueOf(Xamarin.Forms.Color.White.ToAndroid());
            }
            else
            {
                Control.Background.SetColorFilter(Xamarin.Forms.Color.White.ToAndroid(), PorterDuff.Mode.SrcAtop);
            }
        }
    }
}

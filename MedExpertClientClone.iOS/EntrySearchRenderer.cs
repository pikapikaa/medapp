using System;
using MedExpertClientClone.iOS;
using MedExpertClientClone.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntryRenderer), typeof(EntrySearchRenderer))]
namespace MedExpertClientClone.iOS
{
    public class EntrySearchRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if(Control != null)
            {
                Control.BorderStyle = UIKit.UITextBorderStyle.None;
            }
        }
    }
}

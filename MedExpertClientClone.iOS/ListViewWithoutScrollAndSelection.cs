using System;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("MyCompany")]
[assembly: ExportEffect(typeof(MedExpertClientClone.iOS.ListViewWithoutScrollAndSelection), nameof(MedExpertClientClone.iOS.ListViewWithoutScrollAndSelection))]
namespace MedExpertClientClone.iOS
{
    public class ListViewWithoutScrollAndSelection : PlatformEffect
    {
        private UITableView uITableView => Control as UITableView;

        protected override void OnAttached()
        {
            try
            {
                if (uITableView != null)
                {
                    uITableView.ScrollEnabled = false;
                    uITableView.AllowsSelection = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        { }
    }
}

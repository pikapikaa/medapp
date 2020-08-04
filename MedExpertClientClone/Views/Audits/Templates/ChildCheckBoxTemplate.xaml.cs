using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.TreeView.Engine;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedExpertClientClone.Views.Audits.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChildCheckBoxTemplate : ViewCell
    {
        public ChildCheckBoxTemplate()
        {
            InitializeComponent();
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            var imageIcon = sender as Image;
            var context = imageIcon.BindingContext;

            Console.WriteLine(context);
        }
    }
}

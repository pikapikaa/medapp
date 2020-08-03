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

        public static readonly BindableProperty ParentContextProperty =
            BindableProperty.Create("ParentContext", typeof(object), typeof(ChildCheckBoxTemplate), null, propertyChanged: OnParentContextPropertyChanged);

        public object ParentContext
        {
            get { return GetValue(ParentContextProperty); }
            set { SetValue(ParentContextProperty, value); }
        }

        private static void OnParentContextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != oldValue && newValue != null)
            {
                (bindable as ChildCheckBoxTemplate).ParentContext = newValue;
            }
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            //var imageIcon = sender as Image;
            //var treeViewNode = imageIcon.BindingContext as TreeViewNode;

            Console.WriteLine();
        }
    }
}

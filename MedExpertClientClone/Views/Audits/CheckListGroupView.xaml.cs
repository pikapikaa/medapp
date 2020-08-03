using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MedExpertClientClone.Views.Audits
{
    public partial class CheckListGroupView : ContentPage
    {
        public CheckListGroupView()
        {
            InitializeComponent();
            treeView.ItemTapped += TreeView_ItemTapped;
        }

        private void TreeView_ItemTapped(object sender, Syncfusion.XForms.TreeView.ItemTappedEventArgs e)
        {
            if (!e.Node.HasChildNodes)
            {
                Navigation.PushAsync(new CheckListDetailView());
            }
        }

        void treeView_QueryNodeSize(System.Object sender, Syncfusion.XForms.TreeView.QueryNodeSizeEventArgs e)
        {
            e.Height = e.GetActualNodeHeight();
            e.Handled = true;
        }
    }
}

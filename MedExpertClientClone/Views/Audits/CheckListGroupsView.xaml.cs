using System;
using System.Collections.Generic;
using MedExpertClientClone.ViewModels.Audits;
using MedExpertClientClone.Views.Popups;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MedExpertClientClone.Views.Audits
{
    public partial class CheckListGroupsView : ContentPage
    {
        public CheckListGroupsView()
        {
            InitializeComponent();
           
            var viewModel = new FileManagerViewModel();
            viewModel.Navigation = this.Navigation;
            this.BindingContext = viewModel;
           

            //treeView.ItemTapped += TreeView_ItemTapped;
            //treeView.ItemHolding += TreeView_ItemHolding;
        }

        private void TreeView_ItemHolding(object sender, Syncfusion.XForms.TreeView.ItemHoldingEventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new SortPopupView(), false);
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
using System;
using MedExpertClientClone.Views.Audits.Templates;
using Syncfusion.TreeView.Engine;
using Xamarin.Forms;

namespace MedExpertClientClone.Helpers
{
    public class TemplateSelector : DataTemplateSelector
    {
        public DataTemplate HeaderTemplate { get; set; }
        public DataTemplate ChildTemplate { get; set; }
        public DataTemplate ChildCheckBoxTemplate { get; set; }

        public TemplateSelector()
        {
            this.HeaderTemplate = new DataTemplate(typeof(HeaderTemplate));
            this.ChildTemplate = new DataTemplate(typeof(ChildTemplate));
            this.ChildCheckBoxTemplate = new DataTemplate(typeof(ChildCheckBoxTemplate));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var treeviewNode = item as TreeViewNode;
            if (treeviewNode == null)
                return null;
            if (treeviewNode.Level == 0)
                return HeaderTemplate;
            else if (treeviewNode.HasChildNodes)
                return ChildTemplate;
            else
                return ChildCheckBoxTemplate;
        }
    }
}
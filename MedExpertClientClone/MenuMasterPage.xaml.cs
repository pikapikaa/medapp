using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MedExpertClientClone
{
    public partial class MenuMasterPage : ContentPage
    {
        public event EventHandler<PageType> PageSelected;
        public MenuMasterPage()
        {
            InitializeComponent();
            btnAudits.Clicked += (s, e) => PageSelected?.Invoke(this, PageType.Audits);
            btnTasks.Clicked += (s, e) => PageSelected?.Invoke(this, PageType.Tasks);
            btnProjects.Clicked += (s, e) => PageSelected?.Invoke(this, PageType.Projects);
            btnProfile.Clicked += (s, e) => PageSelected?.Invoke(this, PageType.Profile);
            btnSettings.Clicked += (s, e) => PageSelected?.Invoke(this, PageType.Settings);
            btnUpdating.Clicked += (s, e) => PageSelected?.Invoke(this, PageType.Updating);
            btnHelp.Clicked += (s, e) => PageSelected?.Invoke(this, PageType.Help);
            btnExit.Clicked += (s, e) => PageSelected?.Invoke(this, PageType.Exit);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedExpertClientClone.Renderers;
using MedExpertClientClone.ViewModels;
using MedExpertClientClone.ViewModels.Audits;
using Naxam.Controls.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedExpertClientClone.Views.Audits
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuditTabbedView : TopTabbedPage
    {
        public AuditTabbedView()
        {
            InitializeComponent();
            this.BindingContext = new AuditTabbedViewModel();
        }
    }
}
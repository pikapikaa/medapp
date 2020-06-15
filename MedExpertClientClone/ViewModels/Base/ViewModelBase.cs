using System;
using MedExpertClientClone.Services.Dialog;
using Xamarin.Forms;

namespace MedExpertClientClone.ViewModels.Base
{
    public abstract class ViewModelBase : BindableObject
    {
        protected readonly IDialogService DialogService;
        public ViewModelBase()
        {
            DialogService = ViewModelLocator.Resolve<IDialogService>();
        }
    }
}

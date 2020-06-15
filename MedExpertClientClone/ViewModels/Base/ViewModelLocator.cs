using System;
using System.ComponentModel;
using Autofac;
using MedExpertClientClone.Services.Dialog;

namespace MedExpertClientClone.ViewModels.Base
{
    public static class ViewModelLocator
    {
        private static readonly Autofac.IContainer container;

        static ViewModelLocator()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<DialogService>().As<IDialogService>().SingleInstance();
            container = builder.Build();
        }

        public static T Resolve<T>() where T : class
        {
            return container.Resolve<T>();
        }
    }
}

using Autofac;
using MvvmCross.Core.ViewModels;
using System.Reflection;

namespace MvvmTemplate.Common.Infastructure
{
    public class ViewModelModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var viewModelAssembly = typeof(ViewModelModule).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(viewModelAssembly)
                .AssignableTo<MvxViewModel>()
                .As<IMvxViewModel, MvxViewModel>()
                .AsSelf();
        }
    }
}
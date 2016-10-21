using Autofac;
using MvvmCross.Core.Views;
using MvvmCross.Forms.Presenter.Core;

namespace MvvmTemplate.Platform.Infastructure
{
    public class FormsPlatformModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // register any types that live in the platform PCL

            builder
                .RegisterType<CustomPageLoader>()
                .As<IMvxFormsPageLoader>();
            builder
                .Register((ctx) => Xamarin.Forms.Application.Current)
                .As<Xamarin.Forms.Application>();
        }
    }
}
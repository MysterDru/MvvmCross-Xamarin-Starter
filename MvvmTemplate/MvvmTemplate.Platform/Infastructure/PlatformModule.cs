using Autofac;
using MvvmCross.Forms.Presenter.Core;

namespace MvvmTemplate.Platform.Infastructure
{
    public class PlatformModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // register any types that live in the platform PCL

            builder.RegisterType<CustomPageLoader>()
                .As<IMvxFormsPageLoader>();
        }
    }
}
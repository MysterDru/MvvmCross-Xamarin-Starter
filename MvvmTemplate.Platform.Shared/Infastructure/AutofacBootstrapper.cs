using Autofac;
using MvvmTemplate.Common.Infastructure;
using MvvmTemplate.Platform.Infastructure;

namespace MvvmTemplate.Platform
{
    public static class AutofacBootstrapper
    {
        public static IContainer Initialize()
        {
            var cb = new ContainerBuilder();

            // I like to structure my app using Autofac modules.
            // It keeps everything very DRY and SRP compliant.
            // Ideally, these Autofac modules would be held in a separate PCL so they can be used
            // by Android / iOS / WP platforms without violating DRY.
            cb.RegisterModule<ViewModelModule>();
            cb.RegisterModule<ServicesModule>();

            cb.RegisterModule<PlatformModule>();

#if __ANDROID__
            cb.RegisterModule<Droid.Infastructure.DroidPlatformModule>();
#elif __IOS__
            cb.RegisterModule<iOS.Infastructure.IosPlatformModule>();
#endif      
           return cb.Build();
        }
    }
}
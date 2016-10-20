using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Views;
using MvvmCross.Forms.Presenter.Droid;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using MvvmCross.Platform.Platform;

namespace MvvmTemplate.Platform.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext)
            : base(applicationContext)
        {
        }

        protected override IMvxViewModelLoader CreateViewModelLoader()
        {
            return base.CreateViewModelLoader();
        }

        protected override IMvxApplication CreateApp()
        {
            return new MvxApp();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var presenter = new MvxFormsDroidPagePresenter();
            Mvx.RegisterSingleton<IMvxViewPresenter>(presenter);

            return presenter;
        }

        protected override IMvxIoCProvider CreateIocProvider()
        {
            return new AutofacMvxIocProvider(AutofacBootstrapper.Initialize());
        }
    }
}
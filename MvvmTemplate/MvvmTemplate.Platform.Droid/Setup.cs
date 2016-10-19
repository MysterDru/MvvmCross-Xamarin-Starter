using Android.Content;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Views;
using MvvmCross.Forms.Presenter.Droid;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;

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
    }
}
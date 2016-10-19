using MvvmCross.Forms.Presenter.Core;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MvvmTemplate.Platform
{
    public class MvxApp : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.RegisterType(typeof(IMvxFormsPageLoader), typeof(CustomPageLoader));

            RegisterAppStart<ViewModels.Main.MainViewModel>();
        }
    }
}

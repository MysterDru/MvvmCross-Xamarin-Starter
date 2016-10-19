using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.Presenter.Core;
using MvvmCross.Platform.IoC;
using System;
using System.Linq;
using System.Reflection;

namespace MvvmTemplate.Platform
{
    public class CustomPageLoader : MvxFormsPageLoader, IMvxFormsPageLoader
    {
        protected override string GetPageName(MvxViewModelRequest request)
        {
            var viewModelName = request.ViewModelType.Name;
            return viewModelName.Replace("ViewModel", "Page");
        }

        protected override Type GetPageType(MvxViewModelRequest request)
        {
            var pageName = GetPageName(request);

            return typeof(CustomPageLoader).GetTypeInfo().Assembly.CreatableTypes()
                 .FirstOrDefault(t => t.Name == pageName);
        }
    }
}
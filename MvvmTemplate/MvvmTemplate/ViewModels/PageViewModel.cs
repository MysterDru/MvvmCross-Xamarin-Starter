using MvvmCross.Core.ViewModels;

namespace MvvmTemplate.ViewModels
{
    /// <summary>
    /// Used as the base class for a view model that should be bound to a Xamarin.Froms page or other "page" type view
    /// </summary>
    public abstract class PageViewModel : MvxViewModel
    {
        public string Title { get; protected set; }
    }
}
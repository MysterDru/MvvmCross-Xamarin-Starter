using MvvmCross.Core.ViewModels;
using PropertyChanged;
using System.Windows.Input;
using System;

namespace MvvmTemplate.ViewModels.Main
{
    [ImplementPropertyChanged]
    public class MainViewModel : PageViewModel
    {
        public string ClickCount { get; private set; }

        public ICommand Click { get; }

        public MainViewModel()
        {
            ClickCount = "0";
            Title = "Main View";

            Click = new MvxCommand(this.ExecuteClick);
        }

        private void ExecuteClick()
        {
            int count = int.Parse(ClickCount);

            ClickCount = (count += 1).ToString();
        }
    }
}
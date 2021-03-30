using System;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Imba.Core.ViewModels
{
    public class TabsViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        public IMvxAsyncCommand ShowTodoViewCommand { get; private set; }

        public TabsViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            ShowTodoViewCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<TodoViewModel>());
        }

        public override void Prepare()
        {
            base.Prepare();
        }

        // MvvmCross Lifecycle

        // MVVM Properties

        // MVVM Commands



    }
}

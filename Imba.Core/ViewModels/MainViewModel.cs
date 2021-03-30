using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Imba.Core.DataModels;
using Imba.Core.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Imba.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        readonly IBroadcastStateService _broadcastStateService;
        private readonly IMvxNavigationService _navigationService;

        public IMvxAsyncCommand ShowTabsViewCommand { get; private set; }


        public MainViewModel(IMvxNavigationService navigationService, IBroadcastStateService broadcastStateService)
        {
            _broadcastStateService = broadcastStateService;
            _navigationService = navigationService;
            ShowTabsViewCommand = new MvxAsyncCommand(MoveToTabsViewCommand);
        }

        private async Task MoveToTabsViewCommand()
        {
            var result = await _navigationService.Navigate<TabsViewModel>();
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            _state = 0;
        }

        public override void Prepare()
        {
            base.Prepare();

        }

        public MvxNotifyTask LoadTabsViewModel { get; private set; }

      
        private int _state;
        public int State
        {
            get => _state;
            set
            {
                _state = value;
                RaisePropertyChanged(() => State);

                ChangeState();
            }
        }

     

        private void ChangeState()
        {
            State = _broadcastStateService.IncrementState(State);

        }
    }
}

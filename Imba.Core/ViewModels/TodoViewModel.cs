using System.Collections.Generic;
using System.Threading.Tasks;
using Imba.Core.DataModels;
using Imba.Core.Services.Interfaces;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmCross.Plugin.Messenger;
using Imba.Core.MvxMessages;
using System;
using MvvmCross.Commands;

namespace Imba.Core.ViewModels
{
    public class TodoViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private IFirebaseDatabaseService _databaseService { get; }

        private IMvxMessenger _mvxMessenger { get; }
        private readonly MvxSubscriptionToken _tokenTodoList;
        private int _subscriptionTokenCount;
        private IMvxAsyncCommand _refreshCommand;
        public IMvxAsyncCommand RefreshCommand => _refreshCommand ?? (_refreshCommand = new MvxAsyncCommand(ExecuteRefreshCommand));

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        private async Task ExecuteRefreshCommand()
        {
            IsBusy = true;

            // refresh work 
            RefreshTodoListTask = MvxNotifyTask.Create(RefreshTodoList);
            // refresh work

            IsBusy = false;
        }
        public TodoViewModel(IMvxNavigationService navigationService, IFirebaseDatabaseService databaseService, IMvxMessenger mvxMessenger)
        {
            _navigationService = navigationService;
            _databaseService = databaseService;
            _mvxMessenger = mvxMessenger;
            _tokenTodoList = _mvxMessenger.Subscribe<TodoListMvxMessage>(HandleTodoList);
            TodoList = new MvxObservableCollection<Todo>();

        }
        public override Task Initialize()
        {
            LoadTodoListTask = MvxNotifyTask.Create(LoadMockTodoList);
            _databaseService.GetTodoList();
            return base.Initialize();

        }

        public MvxNotifyTask RefreshTodoListTask { get; private set; }
        private Task RefreshTodoList()
        {
            _todoList.Clear();
            _databaseService.GetTodoList();
            return Task.FromResult(0);
        }

        public override void ViewDestroy(bool viewFinishing = true)
        {
            base.ViewDestroy(viewFinishing);
            _databaseService.RemoveListeners();
            _tokenTodoList.Dispose();
        }

        private void HandleTodoList(TodoListMvxMessage obj)
        {
            _subscriptionTokenCount = _mvxMessenger.CountSubscriptionsFor<TodoListMvxMessage>();
            TodoList.AddRange(obj._todoList);
          
        }

        public MvxNotifyTask LoadTodoListTask { get; private set; }

        private Task LoadTodoList()
        {
            return Task.FromResult(0);

        }
        private Task LoadMockTodoList()
        {
            var result = _databaseService.GetMockedTodos();

            //_databaseService.GetTodoList();
            List<Todo> todosToAdd = new List<Todo>();
            todosToAdd = result;

            TodoList.AddRange(todosToAdd);
            return Task.FromResult(0);
        }

        private MvxObservableCollection<Todo> _todoList;

        public MvxObservableCollection<Todo> TodoList
        {
            get
            {
                return _todoList;
            }
            set
            {
                _todoList = value;
                RaisePropertyChanged(() => TodoList);
            }
        }

    }
}

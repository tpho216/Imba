using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Util;
using Firebase.Database;
using Imba.Core.DataModels;
using Imba.Core.Services.Implementation;
using Firebase;
using Imba.Core.Services.Interfaces;
using System.Linq;
using MvvmCross.Plugin.Messenger;
using Imba.Core.MvxMessages;
using System.Threading;

namespace Imba.Droid
{
    public class AndroidFirebaseDatabaseService : Java.Lang.Object, IFirebaseDatabaseService
    {
        private readonly string _tag;
        private FirebaseDatabase _rootDatabase;
        private Query _todoListNode;
        private TodoListValueListener _todoListValueListener;
        private EventHandler _todoListNodeHandler;
        private IMvxMessenger _mvxMessenger;
        
        public AndroidFirebaseDatabaseService(IMvxMessenger mvxMessenger)
        {
            _tag = this.ToString();
            _rootDatabase = FirebaseDatabase.Instance;
            _mvxMessenger = mvxMessenger;

            _todoListNode  = _rootDatabase.GetReference("todo");
            _todoListNodeHandler = (s, e) => handleTodoListNode(s, e);
            _todoListValueListener = new TodoListValueListener(_todoListNodeHandler);



        }

        private void handleTodoListNode(object readSender, EventArgs readEvent)
        {
            var readResult = readEvent as AnyListEventArgs<Todo>;
            var message = new TodoListMvxMessage(this, readResult.AnyList);
            _mvxMessenger.Publish<TodoListMvxMessage>(message);
        }

        public List<Todo> GetMockedTodos()
        {
            return new List<Todo>
            {
                    new Todo
                    {
                        Title = "Item 1",
                        Description = "Buy milk"
                    },
                    new Todo
                    {
                        Title = "Item 2",
                        Description = "Collect mail"
                    },
                    new Todo
                    {
                        Title = "Item 3",
                        Description = "Take out trash"

                    }
            };
        }

        public void RemoveListeners()
        {
            _todoListNode.RemoveEventListener(_todoListValueListener);
        }

        public void GetTodoList()
        {
            _todoListNode.AddListenerForSingleValueEvent(_todoListValueListener);

            Log.Debug(_tag, "GetTodoList called");
        }

        public class TodoListValueListener : Java.Lang.Object, IValueEventListener
        {
            EventHandler _onChange;
            public TodoListValueListener(EventHandler onChange)
            {
                _onChange = onChange;
            }

            public void OnCancelled(DatabaseError error)
            {
                //throw new NotImplementedException();
            }

            public void OnDataChange(DataSnapshot snapshot)
            {
                List<Todo> todoList = new List<Todo>();
          
                if (snapshot != null)
                {
                    foreach (DataSnapshot item in snapshot.Children.ToEnumerable())
                    {
                        if (item.Child("itemId").GetValue(true) != null)
                        {
                            var itemTitle = item.Child("Title").GetValue(true)?.ToString();
                            var itemDescription = item.Child("Description").GetValue(true)?.ToString();

                            todoList.Add(new Todo(itemTitle, itemDescription));
                        }
                    }
                }
               
                _onChange.Invoke(this, new AnyListEventArgs<Todo>(todoList));
            }
        }


        public class AnyListEventArgs<T> : EventArgs
        {
            public List<T> AnyList { get; }
            public AnyListEventArgs(List<T> list)
            { AnyList = list; }
        }
    }


}

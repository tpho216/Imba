using System.Collections.Generic;
using Imba.Core.DataModels;
using MvvmCross.Plugin.Messenger;

namespace Imba.Core.MvxMessages
{
    public class TodoListMvxMessage : MvxMessage
    {
        public List<Todo> _todoList;
        public TodoListMvxMessage(object sender, List<Todo> list) : base(sender)
        {
            _todoList = list;
        }
    }
}

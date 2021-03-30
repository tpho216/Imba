using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Imba.Core.DataModels;

namespace Imba.Core.Services.Interfaces
{
    public interface IFirebaseDatabaseService 
    {
        List<Todo> GetMockedTodos();

        void GetTodoList();

        void RemoveListeners();
    }
}

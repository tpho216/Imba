using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Imba.Core.DataModels;
using Imba.Core.Services.Interfaces;

namespace Imba.Core.Services.Implementation
{
    public class FirebaseDatabaseService : IFirebaseDatabaseService
    {
        public FirebaseDatabaseService()
        { 
        }

       

        public List<Todo> GetMockedTodos()
        {
            return new List<Todo>
            {
               
            };
        }

        public Task<Todo> GetTodoAsync()
        {
            return null;
            //throw new NotImplementedException();
        }

        public virtual void GetTodoList()
        {
            
        }

        public void RemoveListeners()
        {

        }
    }
}

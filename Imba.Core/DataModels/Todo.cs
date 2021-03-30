using System;
namespace Imba.Core.DataModels
{
    public class Todo
    {
        public Todo()
        {

        }
        public Todo(string title, string description)
        {
            _title = title;
            _description = description;
        }

        private string _title;

        public string Title { get => _title; set => _title = value; }

        private string _description;

        public string Description { get => _description; set => _description = value; }
    }
}

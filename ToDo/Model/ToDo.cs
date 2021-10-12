using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Model
{
    public class ToDo
    {
        private readonly int todoId;
        public int ToDoId { get { return todoId; } }
        private readonly string description;
        public string Desciption { get { return description; } }
        private readonly bool done;
        private readonly Person assignee;

        public ToDo(int toDoId, string description)
        {
            todoId = toDoId;
            this.description = description;
        }
    }
}

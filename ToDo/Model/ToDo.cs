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
        private bool done = false;
        public bool Done {
            get { 
                return done;
            }
            set
            {
                done = value;
            }
        }
        private Person assignee = null;
        public Person Assignee {
            get {
                return assignee;
            }
            set
            {
                assignee = value;
            }
        }

        public ToDo(int toDoId, string description)
        {
            todoId = toDoId;
            this.description = description;
        }
    }
}

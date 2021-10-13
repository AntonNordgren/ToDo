using System;
using System.Collections.Generic;
using System.Text;
using Model;
using ToDo.Model;

namespace ToDo.Data
{
    public class ToDoItems
    {
        private static Model.ToDo[] todos = new Model.ToDo[0];

        public int Size()
        {
            return todos.Length;
        }

        public Model.ToDo[] FindAll()
        {
            return todos;
        }

        public ToDo.Model.ToDo FindById(int toDoId)
        {
            for (int i = 0; i < todos.Length; i++)
            {
                if (todos[i].ToDoId == toDoId)
                {
                    return todos[i];
                }
            }

            return null;
        }

        public Model.ToDo CreateToDo(string description)
        {
            Model.ToDo newToDo = new Model.ToDo(TodoSequencer.NextToDoId(), description);

            Array.Resize(ref todos, todos.Length + 1);
            todos[todos.Length - 1] = newToDo;

            return newToDo;
        }

        public void Clear()
        {
            todos = new Model.ToDo[0];
            TodoSequencer.Reset();
        }
    }
}

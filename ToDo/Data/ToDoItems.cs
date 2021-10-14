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

        public Model.ToDo[] FindByDoneStatus(bool doneStatus)
        {
            int statusCounter = 0;
            int statusIndex = 0;

            foreach (Model.ToDo todo in todos)
            {
                if (todo.Done == doneStatus)
                {
                    ++statusCounter;
                }
            }

            Model.ToDo[] allDoneStatusTodos = new Model.ToDo[statusCounter];

            for (int i = 0; i < todos.Length; i++)
            {
                if (todos[i].Done == doneStatus)
                {
                    allDoneStatusTodos[statusIndex] = todos[i];
                    statusIndex += 1;
                }
            }

            return allDoneStatusTodos;
        }

        public Model.ToDo[] FindByAssignee(int personId)
        {
            int personIdCounter = 0;
            int allPersonIdTodosCounter = 0;

            foreach (Model.ToDo todo in todos)
            {
                if (todo.ToDoId == personId)
                {
                    personIdCounter += 1;
                }
            }

            Model.ToDo[] allPersonIdTodos = new Model.ToDo[personIdCounter];

            for (int i = 0; i < todos.Length; i++)
            {
                if (todos[i].ToDoId == personId)
                {
                    allPersonIdTodos[allPersonIdTodosCounter] = todos[i];
                    allPersonIdTodosCounter += 1;
                }
            }

            return allPersonIdTodos;
        }

        public Model.ToDo[] FindByAssignee(Person assignee)
        {
            int assigneeCounter = 0;
            int allByAssigneeTodosCounter = 0;

            foreach (Model.ToDo todo in todos)
            {
                if (todo.Assignee == assignee)
                {
                    assigneeCounter += 1;
                }
            }

            Model.ToDo[] allByAssigneeTodos = new Model.ToDo[assigneeCounter];

            for (int i = 0; i < todos.Length; i++)
            {
                if (todos[i].Assignee == assignee)
                {
                    allByAssigneeTodos[allByAssigneeTodosCounter] = todos[i];
                    allByAssigneeTodosCounter += 1;
                }
            }

            return allByAssigneeTodos;
        }

        public Model.ToDo[] FindUnassignedTodoItems()
        {
            int notAssigneeCounter = 0;
            int allNullAssigneeCounter = 0;

            foreach (Model.ToDo todo in todos)
            {
                if (todo.Assignee == null)
                {
                    notAssigneeCounter += 1;
                }
            }

            Model.ToDo[] allWithNotAssigneeTodos = new Model.ToDo[notAssigneeCounter];

            for (int i = 0; i < todos.Length; i++)
            {
                if (todos[i].Assignee == null)
                {
                    allWithNotAssigneeTodos[allNullAssigneeCounter] = todos[i];
                    allNullAssigneeCounter += 1;
                }
            }

            return allWithNotAssigneeTodos;
        }

    }
}

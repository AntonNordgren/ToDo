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

        // Returns the size of the todo array
        public int Size()
        {
            return todos.Length;
        }

        // Returns the todo array
        public Model.ToDo[] FindAll()
        {
            return todos;
        }

        // Returns the first todo with the right todoId
        // If not found throws exception
        public Model.ToDo FindById(int toDoId)
        {
            for (int i = 0; i < todos.Length; i++)
            {
                if (todos[i].ToDoId == toDoId)
                {
                    return todos[i];
                }
            }

            throw new ArgumentException("Couldn't find todo with that id");
        }

        // Create new todo resize the todos array and put the new todo last in the array
        public Model.ToDo CreateToDo(string description)
        {
            Model.ToDo newToDo = new Model.ToDo(TodoSequencer.NextToDoId(), description);

            Array.Resize(ref todos, todos.Length + 1);
            todos[todos.Length - 1] = newToDo;

            return newToDo;
        }

        // Create new todo that is empty
        // Reset TodoSequenser too
        public void Clear()
        {
            todos = new Model.ToDo[0];
            TodoSequencer.Reset();
        }

        // Finds out the number of the same doneStatuses in  the TodoArray
        // Create a new array with the size of the done statuses
        // It goes through the todos array and puts the todos with the done status in it
        // Return the array with all of the same donestatus
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

        // Finds out the number of the same personId in  the TodoArray
        // Create a new array with the size of the same personId
        // It goes through the todos array and puts the todos with the same assigne in it
        // Return the array with all the assignees
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

        // Finds out the number of the same Assignee in  the TodoArray
        // Create a new array with the size of the same Assignee
        // It goes through the todos array and puts the todos with the same assigne in it
        // Return the array with all the assignees
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

        // Finds out the number of todos that are null
        // Create a new array with the size of the null todos
        // It goes through the todos array and puts the todos that are null in the new array
        // Return the array with all the todos that are null
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

        // First it tries to find the id in the array
        // If not found throw exception
        // Create new array that is one shorter in length
        // Fill the new array with the elements that dont have the same id
        // replace the old person array with the new
        public void RemoveTodo(int toDoId)
        {
            bool todoFound = false;
            foreach (ToDo.Model.ToDo todo in todos)
            {
                if (todo.ToDoId == toDoId)
                {
                    todoFound = true;
                    break;
                }
            }

            if (!todoFound)
            {
                throw new ArgumentException("Couldn't find todo with that id");
            }

            ToDo.Model.ToDo[] newToDos = new ToDo.Model.ToDo[todos.Length - 1];
            int newToDosIndex = 0;

            foreach (Model.ToDo todo in todos)
            {
                if (todo.ToDoId != toDoId)
                {
                    newToDos[newToDosIndex] = todo;
                    newToDosIndex++;
                }
            }

            todos = newToDos;
        }
    }
}

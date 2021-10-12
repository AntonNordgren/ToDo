using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Data
{
    public static class TodoSequencer
    {
        private static int toDoId = 0;
        public static int ToDoId { get { return toDoId; } }

        public static int nextToDoId()
        {
            return ++toDoId;
        }

        public static void reset()
        {
            toDoId = 0;
        }
    }
}

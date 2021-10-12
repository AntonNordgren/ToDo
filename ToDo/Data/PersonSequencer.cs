using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Data
{
    public static class PersonSequencer
    {
        private static int personId = 0;
        public static int PersonId { get { return personId; } }

        public static int nextPersonId()
        {
            return ++personId;
        }

        public static void reset()
        {
            personId = 0;
        }
    }
}

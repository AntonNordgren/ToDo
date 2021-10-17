using System;
using System.Collections.Generic;
using System.Text;

using ToDo.Data;

namespace Model
{
    public class Person
    {
        private readonly int personId = PersonSequencer.NextPersonId();
        public int PersonId {
            get { return personId; }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if(value is null || value.Equals(""))
                {
                    throw new ArgumentException("Firstname can not be empty or null.");
                }

                firstName = value;
            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value is null || value.Equals(""))
                {
                    throw new ArgumentException("Lastname can not be empty or null.");
                }

                lastName = value;
            }
        }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}

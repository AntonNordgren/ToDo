using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace ToDo.Data
{
    public class People
    {
        private static Person[] people = new Person[0];

        public int Size()
        {
            return people.Length;
        }

        public Person[] FindAll()
        {
            return people;
        }

        public Person FindById(int personId)
        {
            for(int i = 0; i < people.Length; i++)
            {
                if(people[i].PersonId == personId)
                {
                    return people[i];
                }
            }

            return null;
        }

        public Person CreateNewPerson(string firstName, string lastName)
        {
            Person newPerson = new Person(PersonSequencer.NextPersonId(), firstName, lastName);

            Array.Resize(ref people, people.Length + 1);
            people[people.Length - 1] = newPerson;

            return newPerson;
        }

        public void Clear()
        {
            people = new Person[0];
            PersonSequencer.Reset();
        }
    }
}

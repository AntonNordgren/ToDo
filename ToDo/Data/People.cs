using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace ToDo.Data
{
    public class People
    {
        private static Person[] people = new Person[0];

        // Returns the size of the people array
        public int Size()
        {
            return people.Length;
        }

        // Returns the people array
        public Person[] FindAll()
        {
            return people;
        }

        // Returns the first person with the right persinId
        // If not found throws exception
        public Person FindById(int personId)
        {
            for(int i = 0; i < people.Length; i++)
            {
                if(people[i].PersonId == personId)
                {
                    return people[i];
                }
            }

            throw new ArgumentException("Couldn't find person by that id");
        }

        // Create new person resize the persons array and put the new person last in the array
        public Person CreateNewPerson(string firstName, string lastName)
        {
            Person newPerson = new Person(firstName, lastName);

            Array.Resize(ref people, people.Length + 1);
            people[people.Length - 1] = newPerson;

            return newPerson;
        }

        // Create new array that is empty
        // Reset PersonSequenser too
        public void Clear()
        {
            people = new Person[0];
            PersonSequencer.Reset();
        }

        // First it tries to find the id in the array
        // If not found throw exception
        // Create new array that is one shorter in length
        // Fill the new array with the elements that dont have the same id
        // replace the old person array with the new
        public void RemovePerson(int personId)
        {
            bool personFound = false;
            foreach(Person p in people)
            {
                if(p.PersonId == personId)
                {
                    personFound = true;
                    break;
                }
            }

            if(!personFound)
            {
                throw new ArgumentException("Couldn't find person with that id");
            }

            Person[] newPeople = new Person[people.Length - 1];
            int newPeopleIndex = 0;

            foreach(Person person in people)
            {
                if (person.PersonId != personId)
                {
                    newPeople[newPeopleIndex] = person;
                    newPeopleIndex++;
                }
            }

            people = newPeople;
        }
    }
}

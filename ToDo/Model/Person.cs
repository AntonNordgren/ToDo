﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Person
    {
        private readonly int personId;
        public int PersonId {
            get { return personId; }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if(value == null || value.Equals(""))
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
                if (value == null || value.Equals(""))
                {
                    throw new ArgumentException("Lastname can not be empty or null.");
                }

                lastName = value;
            }
        }

        public Person(int personId, string firstName, string lastName)
        {
            this.personId = personId;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}

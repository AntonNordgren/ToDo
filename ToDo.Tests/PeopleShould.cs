using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ToDo.Data;
using Model;

namespace ToDo.Tests
{
    public class PeopleShould
    {
        People sut = new People();

        [Fact]
        public void GetAllInArray()
        {
            sut.Clear();
            sut.CreateNewPerson("Kalle", "Anka");
            sut.CreateNewPerson("Musse", "Pigg");

            Person[] expected = new Person[2];
            expected[0] = new Person(1, "Kalle", "Anka");
            expected[1] = new Person(2, "Musse", "Pigg");

            Assert.Equal(expected[0].PersonId, sut.FindAll()[0].PersonId);
            Assert.Equal(expected[0].FirstName, sut.FindAll()[0].FirstName);
            Assert.Equal(expected[0].LastName, sut.FindAll()[0].LastName);

            Assert.Equal(expected[1].PersonId, sut.FindAll()[1].PersonId);
            Assert.Equal(expected[1].FirstName, sut.FindAll()[1].FirstName);
            Assert.Equal(expected[1].LastName, sut.FindAll()[1].LastName);

            sut.Clear();
        }

        [Theory]
        [InlineData(2)]
        public void FindById(int personId)
        {
            sut.Clear();
            sut.CreateNewPerson("Kalle", "Anka");
            sut.CreateNewPerson("Musse", "Pigg");
            sut.CreateNewPerson("Anton", "Nordgren");

            Person result = sut.FindById(personId);
            Person expected = new Person(2, "Musse", "Pigg");

            Assert.Equal(expected.PersonId, result.PersonId);
            Assert.Equal(expected.FirstName, result.FirstName);
            Assert.Equal(expected.LastName, result.LastName);

        }

        [Theory]
        [InlineData(4)]
        public void NotFoundById(int personId)
        {
            sut.Clear();
            sut.CreateNewPerson("Kalle", "Anka");
            sut.CreateNewPerson("Musse", "Pigg");
            sut.CreateNewPerson("Anton", "Nordgren");

            Person result = sut.FindById(personId);
            Person expected = new Person(2, "Musse", "Pigg");

            Assert.Null(result);
        }

        [Fact]
        public void GetSize()
        {
            sut.Clear();

            sut.CreateNewPerson("TestFirstName", "TestLastName");
            sut.CreateNewPerson("TestFirstName", "TestLastName");

            Assert.Equal(2, sut.Size());
        }

        [Fact]
        public void ClearAllPeople()
        {
            sut.Clear();
            Person[] s = new Person[0];

            sut.Clear();

            Assert.Equal(s, sut.FindAll());
        }

    }
}

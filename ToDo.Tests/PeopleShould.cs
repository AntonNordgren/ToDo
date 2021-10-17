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
            sut.CreateNewPerson("FirstName1", "LastName1");
            sut.CreateNewPerson("FirstName2", "LastName2");

            Assert.Equal(2, sut.Size());
            Assert.Equal(1, sut.FindAll()[0].PersonId);
            Assert.Equal("FirstName1", sut.FindAll()[0].FirstName);
            Assert.Equal("LastName1", sut.FindAll()[0].LastName);

            Assert.Equal(2, sut.FindAll()[1].PersonId);
            Assert.Equal("FirstName2", sut.FindAll()[1].FirstName);
            Assert.Equal("LastName2", sut.FindAll()[1].LastName);
        }

        [Theory]
        [InlineData(2)]
        public void FindById(int personId)
        {
            sut.Clear();
            sut.CreateNewPerson("FirstName1", "LastName1");
            sut.CreateNewPerson("FirstName2", "LastName2");
            sut.CreateNewPerson("FirstName3", "LastName3");

            Person result = sut.FindById(personId);

            Assert.Equal(personId, result.PersonId);
            Assert.Equal("FirstName2", result.FirstName);
            Assert.Equal("LastName2", result.LastName);

        }

        [Theory]
        [InlineData(4)]
        public void NotFoundById(int personId)
        {
            sut.Clear();
            sut.CreateNewPerson("FirstName1", "LastName1");
            sut.CreateNewPerson("FirstName2", "LastName2");
            sut.CreateNewPerson("FirstName3", "LastName3");

            ArgumentException result = Assert.Throws<ArgumentException>(
                () => sut.FindById(personId));

            Assert.Equal("Couldn't find person by that id", result.Message);
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
            Person[] emptyArray = new Person[0];

            sut.Clear();

            Assert.Equal(emptyArray, sut.FindAll());
        }

        [Fact]
        public void DeletePersonCorrectly()
        {
            sut.Clear();
            ToDo.Data.People x = new ToDo.Data.People();

            x.CreateNewPerson("firstName1", "lastName1");
            x.CreateNewPerson("firstName2", "lastName2");
            x.CreateNewPerson("firstName3", "lastName3");
            x.CreateNewPerson("firstName4", "lastName4");
            x.CreateNewPerson("firstName5", "lastName5");

            x.RemovePerson(1);
            x.RemovePerson(3);
            x.RemovePerson(5);

            Assert.Equal(2, x.FindAll().Length);

            Person[] newArray = x.FindAll();

            Assert.Equal("firstName2", newArray[0].FirstName);
            Assert.Equal("lastName2", newArray[0].LastName);

            Assert.Equal("firstName4", newArray[1].FirstName);
            Assert.Equal("lastName4", newArray[1].LastName);

        }

        [Fact]
        public void DeleteInvalidPersonShouldThrowExcepion()
        {
            sut.Clear();
            ToDo.Data.People x = new ToDo.Data.People();

            x.CreateNewPerson("firstName1", "lastName1");
            x.CreateNewPerson("firstName2", "lastName2");
            x.CreateNewPerson("firstName3", "lastName3");

            ArgumentException result = Assert.Throws<ArgumentException>(
                () => sut.RemovePerson(4));

            Assert.Equal("Couldn't find person with that id", result.Message);
        }

    }
}

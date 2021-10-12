using System;
using Xunit;
using Model;

namespace ToDo.Tests
{
    public class PersonShould
    {
       Person sut;

        [Theory]
        [InlineData("Kalle", "Anka")]
        [InlineData("Anton", "Nordgren")]
        public void CreatePersonCorrectly(string firstName, string lastName)
        {
            sut = new Person(firstName, lastName);

            Assert.Equal(sut.FirstName, firstName);
            Assert.Equal(sut.LastName, lastName);
        }

        [Theory]
        [InlineData("", "asd")]
        [InlineData(null, "asd")]
        [InlineData("asd", "")]
        [InlineData("asd", null)]
        public void ThrowExeptionWithInvalidParameters(string firstName, string lastName)
        {
            Assert.Throws<ArgumentException>(() => sut = new Person(firstName, lastName));
        }
    }
}

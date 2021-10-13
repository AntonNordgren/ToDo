using System;
using Xunit;
using Model;

namespace ToDo.Tests
{
    public class PersonShould
    {
       Person sut;

        [Theory]
        [InlineData(1, "Kalle", "Anka")]
        [InlineData(2, "Anton", "Nordgren")]
        public void CreatePersonCorrectly(int personId, string firstName, string lastName)
        {
            sut = new Person(personId, firstName, lastName);

            Assert.Equal(sut.FirstName, firstName);
            Assert.Equal(sut.LastName, lastName);
        }

        [Theory]
        [InlineData(1, "", "asd")]
        [InlineData(2, null, "asd")]
        [InlineData(3, "asd", "")]
        [InlineData(4, "asd", null)]
        public void ThrowExeptionWithInvalidParameters(int personId, string firstName, string lastName)
        {
            Assert.Throws<ArgumentException>(() => sut = new Person(personId, firstName, lastName));
        }
    }
}

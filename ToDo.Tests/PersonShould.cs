using System;
using Xunit;
using Model;

namespace ToDo.Tests
{
    public class PersonShould
    {
       Person sut;

        [Theory]
        [InlineData("FirstName1", "LastName1")]
        [InlineData("FirstName2", "LastName2")]
        public void CreatePersonCorrectly(string firstName, string lastName)
        {
            sut = new Person(firstName, lastName);

            Assert.Equal(sut.FirstName, firstName);
            Assert.Equal(sut.LastName, lastName);
        }

        [Theory]
        [InlineData("", "LastName1")]
        [InlineData(null, "LastName2")]
        [InlineData("FirstName3", "")]
        [InlineData("FirstName4", null)]
        public void ThrowExeptionWithInvalidParameters(string firstName, string lastName)
        {
            Assert.Throws<ArgumentException>(() => sut = new Person(firstName, lastName));
        }
    }
}

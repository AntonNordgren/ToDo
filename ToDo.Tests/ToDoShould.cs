using Model;
using System;
using Xunit;

namespace ToDo.Tests
{
    public class ToDoShould
    {
        Model.ToDo sut;

        [Theory]
        [InlineData(1, "Do Something")]
        [InlineData(2, "Do Something else")]
        public void CreateNewTodoCorrectly(int id, string description)
        {
            sut = new Model.ToDo(id, description);

            Assert.Equal(id, sut.ToDoId);
            Assert.Equal(description, sut.Desciption);
        }
    }
}

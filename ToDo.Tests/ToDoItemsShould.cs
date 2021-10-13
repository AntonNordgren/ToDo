using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Data;
using ToDo.Model;
using Xunit;

namespace ToDo.Tests
{
    public class ToDoItemsShould
    {
        ToDoItems sut = new ToDoItems();

        [Fact]
        public void GetAllInArray()
        {
            sut.Clear();
            sut.CreateToDo("Do something 1");
            sut.CreateToDo("Do something 2");

            ToDo.Model.ToDo[] expected = new ToDo.Model.ToDo[2];
            expected[0] = new ToDo.Model.ToDo(1, "Do something 1");
            expected[1] = new ToDo.Model.ToDo(2, "Do something 2");

            Assert.Equal(expected[0].ToDoId, sut.FindAll()[0].ToDoId);
            Assert.Equal(expected[0].Desciption, sut.FindAll()[0].Desciption);

            Assert.Equal(expected[1].ToDoId, sut.FindAll()[1].ToDoId);
            Assert.Equal(expected[1].Desciption, sut.FindAll()[1].Desciption);

            sut.Clear();
        }

        [Theory]
        [InlineData(2)]
        public void FindById(int personId)
        {
            sut.Clear();
            sut.CreateToDo("Add Something");
            sut.CreateToDo("Delete Something");
            sut.CreateToDo("Edit Something");

            ToDo.Model.ToDo result = sut.FindById(personId);
            ToDo.Model.ToDo expected = new ToDo.Model.ToDo(personId, "Delete Something");

            Assert.Equal(expected.Desciption, result.Desciption);
            Assert.Equal(expected.ToDoId, result.ToDoId);

        }

        [Theory]
        [InlineData(4)]
        public void NotFoundById(int toDoId)
        {
            sut.Clear();
            sut.CreateToDo("Add Something");
            sut.CreateToDo("Delete Something");

            ToDo.Model.ToDo result = sut.FindById(toDoId);
            ToDo.Model.ToDo expected = new ToDo.Model.ToDo(toDoId, "Add Something");

            Assert.Null(result);
        }

        [Fact]
        public void GetSize()
        {
            sut.Clear();

            sut.CreateToDo("Add Something");
            sut.CreateToDo("Delete Something");

            Assert.Equal(2, sut.Size());
        }

        [Fact]
        public void ClearAllPeople()
        {
            sut.Clear();
            Model.ToDo[] newArray = new Model.ToDo[0];

            sut.Clear();

            Assert.Equal(newArray, sut.FindAll());
        }
    }
}

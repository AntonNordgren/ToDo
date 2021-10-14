using Model;
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

        [Fact]
        public void FindAllByDoneStatus()
        {
            sut.Clear();
            Model.ToDo newToDo1 = sut.CreateToDo("Do Something");
            Model.ToDo newToDo2 = sut.CreateToDo("Do Something Else");
            Model.ToDo newToDo3 = sut.CreateToDo("Do Something Good");

            newToDo1.Done = false;
            newToDo2.Done = true;
            newToDo3.Done = true;

            Model.ToDo[] result = sut.FindByDoneStatus(true);

            foreach (Model.ToDo todo in result)
            {
                Assert.True(todo.Done);
            }
        }

        [Fact]
        public void FindAllByPersonId()
        {
            sut.Clear();
            Model.ToDo newToDo1 = sut.CreateToDo("Do Something");
            Model.ToDo newToDo2 = sut.CreateToDo("Do Something Else");
            Model.ToDo newToDo3 = sut.CreateToDo("Do Something Good");

            Person person1 = new Person(1, "Kalle", "Anka");
            Person person2 = new Person(2, "Musse", "Pigg");

            newToDo1.Assignee = person1;
            newToDo2.Assignee = person2;
            newToDo3.Assignee = person2;

            Model.ToDo[] result = sut.FindByAssignee(2);

            foreach (Model.ToDo todo in result)
            {
                Assert.Equal(2, todo.Assignee.PersonId);
            }
        }

        [Fact]
        public void FindAllByAssignee()
        {
            sut.Clear();
            Model.ToDo newToDo1 = sut.CreateToDo("Do Something");
            Model.ToDo newToDo2 = sut.CreateToDo("Do Something Else");
            Model.ToDo newToDo3 = sut.CreateToDo("Do Something Good");

            Person person1 = new Person(1, "Kalle", "Anka");
            Person person2 = new Person(2, "Musse", "Pigg");

            newToDo1.Assignee = person1;
            newToDo2.Assignee = person2;
            newToDo3.Assignee = person2;

            Model.ToDo[] result = sut.FindByAssignee(person2);

            foreach(Model.ToDo todo in result)
            {
                Assert.Equal(person2, todo.Assignee);
            }
        }

        [Fact]
        public void FindUnassignedTodoItems()
        {
            sut.Clear();
            Model.ToDo newToDo1 = sut.CreateToDo("Do Something");
            sut.CreateToDo("Do Something Else");
            Model.ToDo newToDo3 = sut.CreateToDo("Do Something Good");

            Person person1 = new Person(1, "Kalle", "Anka");
            Person person2 = new Person(2, "Musse", "Pigg");

            newToDo1.Assignee = person1;
            newToDo3.Assignee = person2;

            Model.ToDo[] result = sut.FindUnassignedTodoItems();

            foreach (Model.ToDo todo in result)
            {
                Assert.Null(todo.Assignee);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ToDo.Data;

namespace ToDo.Tests
{
    public class ToDoSequencerShould
    {
        [Fact]
        public void GetNextToDoId()
        {
            TodoSequencer.Reset();
            int result = TodoSequencer.NextToDoId();
            Assert.Equal(1, result);
        }

        [Fact]
        public void ResetId()
        {
            TodoSequencer.Reset();
            Assert.Equal(0, TodoSequencer.ToDoId);
        }
    }
}

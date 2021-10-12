using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ToDo.Data;

namespace ToDo.Tests
{
    public class PersonSequencerShould
    {
        [Fact]
        public void GetNextPersonId()
        {
            int result = PersonSequencer.nextPersonId();
            Assert.Equal(1, result);
        }

        [Fact]
        public void ResetId()
        {
            PersonSequencer.reset();
            Assert.Equal(0, PersonSequencer.PersonId);
        }
    }
}
